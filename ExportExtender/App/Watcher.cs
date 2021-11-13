using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ExportExtender.App
{
	[System.Serializable]
	public class WatcherException : System.Exception
	{
		public WatcherException() { }
		public WatcherException(string message) : base(message) { }
		public WatcherException(string message, System.Exception inner) : base(message, inner) { }
		protected WatcherException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}

	public class Watcher : ConsumerThread, IDisposable
	{
		private static readonly ILog log
			= LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public string WatchPath { get; set; }
		public string FileFilter { get; set; }
		public float MinFileReadyAge { get; set; } // seconds
		public float PollingInterval { get; set; } // seconds

		public event EventHandler<string> FileFound;
		public event EventHandler<string> FileLost;
		public event EventHandler<string> FileReady;

		private bool started;
		private Timer pollingTimer;
		private FileSystemWatcher fsw;

		// track timestamp of last change
		private Dictionary<string, DateTime> watchedFiles = new Dictionary<string, DateTime>();

		public Watcher() : base("Watcher", true)
		{
			WatchPath = null;
			FileFilter = "*.*";
			MinFileReadyAge = 0f;
			PollingInterval = 1f;

			started = false;
			pollingTimer = new Timer(PollingTimer_Poll);
		}

		public override void Dispose()
		{
			// TODO not thread safe?
			if (fsw != null)
			{
				fsw.Dispose();
				fsw = null;
			}
			if (pollingTimer != null)
			{
				pollingTimer.Dispose();
				pollingTimer = null;
			}
			base.Dispose();
		}

		public void Start()
		{
			if (started)
			{
				log.Error("Watcher already started.");
				return;
			}

			if (WatchPath == null)
			{
				throw new InvalidOperationException("Set WatchPath before calling Start().");
			}

			log.Info("Starting watcher.");
			started = true;

			// if old timestamps sneak in, we could misjudge file readiness
			// cuz our algorithm is naive
			Trace.Assert(watchedFiles.Count == 0);

			// start thread before events can start firing
			// TODO stop?
			if (!ThreadStarted)
			{
				StartThread();
			}

			if (fsw == null)
			{
				fsw = new FileSystemWatcher();

				fsw.NotifyFilter = NotifyFilters.FileName
					| NotifyFilters.LastWrite
					| NotifyFilters.LastAccess;

				fsw.Changed += Fsw_Changed;
				fsw.Created += Fsw_Created;
				fsw.Deleted += Fsw_Deleted;
				fsw.Renamed += Fsw_Renamed;
				fsw.Error += Fsw_Error;
			}

			fsw.Path = WatchPath;
			fsw.Filter = FileFilter;

			// activate events
			fsw.EnableRaisingEvents = true;

			// start recurring timer
			pollingTimer.Change(0, (int)(PollingInterval * 1000));
		}

		public void Stop()
		{
			// TODO thread safe
			log.Info("Stopping watcher.");
			fsw.EnableRaisingEvents = false;
			pollingTimer.Change(Timeout.Infinite, Timeout.Infinite);
			watchedFiles.Clear();
			//StopThread();
			started = false;
		}

		private void PollingTimer_Poll(object state)
		{
			Queue(() =>
			{
				var ageThreshold = DateTime.Now.Subtract(TimeSpan.FromSeconds(MinFileReadyAge));

				// iterate on copy since we're gonna modify it
				var watchedFilesCopy = new Dictionary<string, DateTime>(watchedFiles);

				foreach (var item in watchedFilesCopy)
				{
					string path = item.Key;
					DateTime timestamp = item.Value;

					if (IsFileLocked(path))
					{
						MarkFileUpdated(path);
					}
					else if (timestamp < ageThreshold)
					{
						OnFileReady(path);
					}
				}
			});
		}

		// not a guarantee; file may get locked again after calling this
		private bool IsFileLocked(string path)
		{
			try
			{
				// try opening
				using (FileStream stream = new FileInfo(path).OpenRead())
				{
					stream.Close();
				}
			}
			catch (IOException)
			{
				// unopenable
				return true;
			}

			return false;
		}

		private void MarkFileUpdated(string path)
		{
			watchedFiles[path] = DateTime.Now + TimeSpan.FromSeconds(PollingInterval);
		}

		private void OnFileFound(string path)
		{
			log.Info("Found file: " + path);
			MarkFileUpdated(path);
			FileFound?.Invoke(this, path);
		}

		private void OnFileLost(string path)
		{
			if (watchedFiles.Remove(path))
			{
				log.Info("Lost file: " + path);
				FileLost?.Invoke(this, path);
			}
		}

		private void OnFileReady(string path)
		{
			log.Info("File ready: " + path);
			watchedFiles.Remove(path);
			FileReady?.Invoke(this, path);
		}

		private void Fsw_Changed(object sender, FileSystemEventArgs e)
		{
			Queue(() =>
			{
				log.Debug("Watcher: " + e.ChangeType + " " + e.Name);
				MarkFileUpdated(e.FullPath);
			});
		}

		private void Fsw_Created(object sender, FileSystemEventArgs e)
		{
			Queue(() =>
			{
				log.Debug("Watcher: " + e.ChangeType + " " + e.Name);
				OnFileFound(e.FullPath);
			});
		}

		private void Fsw_Deleted(object sender, FileSystemEventArgs e)
		{
			Queue(() =>
			{
				log.Debug("Watcher: " + e.ChangeType + " " + e.Name);
				OnFileLost(e.FullPath);
			});
		}

		private void Fsw_Renamed(object sender, RenamedEventArgs e)
		{
			Queue(() =>
			{
				log.Debug("Watcher: " + e.ChangeType + " " + e.OldName + " -> " + e.Name);
				OnFileLost(e.OldFullPath);
				OnFileFound(e.FullPath);
			});
		}

		private void Fsw_Error(object sender, ErrorEventArgs e)
		{
			// TODO what does this do if it's on another thread?
			throw new WatcherException("Directory watcher error.", e.GetException());
		}

	}
}