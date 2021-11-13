using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ExportExtender.App
{
	public abstract class ConsumerThread : IDisposable
	{
		protected bool ThreadStarted { get; private set; }

		private Thread thread;
		private BlockingCollection<Action> queue;

		protected ConsumerThread(string threadName, bool isBackground)
		{
			thread = new Thread(RunThread)
			{
				Name = threadName,
				IsBackground = isBackground
			};
			queue = new BlockingCollection<Action>();
		}

		public virtual void Dispose()
		{
			if (queue != null)
			{
				queue.Dispose();
				queue = null;
			}
		}

		protected void StartThread()
		{
			if (ThreadStarted)
			{
				throw new InvalidOperationException("Thread already started.");
			}

			ThreadStarted = true;

			thread.Start();
		}

		protected void StopThread()
		{
			// TODO stop thread
			throw new NotImplementedException();
		}

		protected void Queue(Action action)
		{
			queue.Add(action);
		}

		private void RunThread()
		{
			// consumer loop
			while (!queue.IsCompleted)
			{
				Action action = null;

				try
				{
					action = queue.Take();
				}
				catch (InvalidOperationException)
				{
					// queue completed after we checked IsCompleted
					// do nothing, let loop break
				}

				if (action != null)
				{
					action();
				}
			}
		}

	}
}
