using ExportExtender.App.Forms;
using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ExportExtender.App
{
	public class Controller : ConsumerThread, IDisposable
	{
		private static readonly ILog log
			= LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public static Controller Instance { get; private set; }

		private SynchronizationContext uiSyncContext;
		private Watcher watcher;
		private Job job;
		private JobWindow jobWindow;

		private string executablePath;
		private string commandArgs;

		public static void InitInstance()
		{
			if (Instance != null)
			{
				throw new InvalidOperationException("Controller already inited.");
			}
			Instance = new Controller();
		}

		public static void DisposeInstance()
		{
			if (Instance != null)
			{
				Instance.Dispose();
				Instance = null;
			}
		}

		private Controller()
			: base("Controller", true)
		{
			watcher = new Watcher();
			watcher.FileFound += Watcher_FileFound;
			watcher.FileLost += Watcher_FileLost;
			watcher.FileReady += Watcher_FileReady;
		}

		public override void Dispose()
		{
			// TODO
			if (watcher != null)
			{
				watcher.Dispose();
				watcher = null;
			}
			base.Dispose();
		}

		public void RegisterSyncContext(SynchronizationContext uiSyncContext)
		{
			if (this.uiSyncContext != null)
			{
				throw new InvalidOperationException("Already registered sync context.");
			}

			if (uiSyncContext == null)
			{
				throw new ArgumentNullException("uiSyncContext");
			}

			this.uiSyncContext = uiSyncContext;

			// ready to start thread
			// TODO stop?
			StartThread();
		}

		public void StartWatcher(
			string path,
			string fileFilter,
			float minFileReadyAge,
			float pollingInterval)
		{
			Queue(() =>
			{
				watcher.WatchPath = path;
				watcher.FileFilter = fileFilter;
				watcher.MinFileReadyAge = minFileReadyAge;
				watcher.PollingInterval = pollingInterval;

				watcher.Start();
			});
		}

		public void StopWatcher()
		{
			Queue(() =>
			{
				watcher.Stop();
			});
		}

		public void SetJobCommand(string executablePath, string commandArgs)
		{
			Queue(() =>
			{
				this.executablePath = executablePath;
				this.commandArgs = commandArgs;
			});
		}

		private void Watcher_FileFound(object sender, string path)
		{
			Queue(() =>
			{
				job = MakeJob(path);

				uiSyncContext.Post((state) =>
				{
					jobWindow = new JobWindow();
					jobWindow.SetJob(job);
					jobWindow.Show();
				}, null);
			});
		}

		private void Watcher_FileLost(object sender, string path)
		{
			Queue(() =>
			{
				if (jobWindow == null)
				{
					log.Warn("Received FileLost event for which no JobWindow exists.");
					return;
				}

				uiSyncContext.Post((state) =>
				{
					jobWindow.Close();
				}, null);
			});
		}

		private void Watcher_FileReady(object sender, string path)
		{
			Queue(() =>
			{
				job.Start();

				uiSyncContext.Post((state) =>
				{
					jobWindow.SetJob(job);
				}, null);
			});
		}

		private Job MakeJob(string fullPath)
		{
			Job job = new Job(
				Path.GetFileName(fullPath),
				Path.GetDirectoryName(fullPath),
				executablePath,
				CommandArgsFromTemplate(commandArgs, fullPath));

			return job;
		}

		private string CommandArgsFromTemplate(string template, string fullPath)
		{
			return template.Replace("$file$", fullPath);
		}
	}
}
