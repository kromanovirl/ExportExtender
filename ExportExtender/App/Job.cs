using log4net;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ExportExtender.App
{
	public class Job : IDisposable
	{
		private static readonly ILog log
			= LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public string Filename { get; }
		public string Path { get; }
		public string CommandFilename { get; }
		public string CommandArgs { get; }

		public JobStatus Status { get; private set; }
		public StreamReader ConsoleStream { get; private set; }
		public TimeSpan TimeTaken { get; private set; }
		public TimeSpan ProcessorTimeTaken { get; private set; }

		public event EventHandler JobFinished;

		private readonly object statusLock = new object();
		private Process process;

		public enum JobStatus
		{
			Waiting,
			Running,
			Finished,
			Failed,
			Canceled,
			Stopped,
		}

		public Job(string filename, string path, string commandFilename, string commandArgs)
		{
			Filename = filename;
			Path = path;
			CommandFilename = commandFilename;
			CommandArgs = commandArgs;
			Status = JobStatus.Waiting;
		}

		public void Dispose()
		{
			if (ConsoleStream != null)
			{
				ConsoleStream.Dispose();
				ConsoleStream = null;
			}

			if (process != null)
			{
				process.Dispose();
				process = null;
			}
		}

		public void Start()
		{
			lock (statusLock)
			{
				if (Status != JobStatus.Waiting)
				{
					log.Warn("Tried to start job in non-waiting state.");
					return;
				}

				Status = JobStatus.Running;
				StartProcess();
			}
		}

		private void StartProcess()
		{
			if (process != null)
			{
				throw new InvalidStateException();
			}

			process = new Process();
			ProcessStartInfo info = process.StartInfo;

			info.FileName = CommandFilename;
			info.Arguments = CommandArgs;

			info.UseShellExecute = true;
			info.CreateNoWindow = false;

			info.RedirectStandardOutput = false;
			info.RedirectStandardError = false;

			process.Exited += Process_Exited;
			process.EnableRaisingEvents = true;

			process.Start();
		}

		private void StopProcess()
		{
			if (process == null)
			{
				return;
			}

			// FIXME send ctrl-c instead
			process.Kill();
		}

		private void OnJobFinished()
		{
			JobFinished?.Invoke(this, EventArgs.Empty);
		}

		private void Process_Exited(object sender, EventArgs e)
		{
			// job could be canceled before aquiring lock
			// but that shouldn't cause problems
			lock (statusLock)
			{
				// note: actual meaning of exit code can vary by application
				if (process.ExitCode == 0)
				{
					Status = JobStatus.Finished;
				}
				else if (Status == JobStatus.Running) // if not manually stopped
				{
					Status = JobStatus.Failed;
				}
			}

			TimeTaken = process.ExitTime - process.StartTime;
			ProcessorTimeTaken = process.TotalProcessorTime;

			log.Info($"Job process exited with code {process.ExitCode}, " +
				$"finished in {TimeTaken}");

			OnJobFinished();
		}

		public void Stop()
		{
			bool stopProcess = false;

			lock (statusLock)
			{
				switch (Status)
				{
					case JobStatus.Waiting:
						Status = JobStatus.Canceled;
						break;
					case JobStatus.Running:
						stopProcess = true;
						Status = JobStatus.Stopped;
						break;
					default:
						break;
				}
			}

			if (stopProcess)
			{
				StopProcess();
			}
		}

	}
}
