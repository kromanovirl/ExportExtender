using System;
using System.Windows.Forms;
using System.Reflection;
using log4net;
using System.Threading;

namespace ExportExtender.App
{
	static class Program
	{
		private static readonly ILog log
			= LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		public static readonly string programName = "ExportExtender";

		[STAThread]
		static void Main()
		{
			using (var singleInstance = SingleGlobalInstance.Acquire())
			{
				if (singleInstance == null)
				{
					MessageBox.Show("Another instance is already running.",
						programName);
					return; // exit
				}

				if (!Logging.Init())
				{
					MessageBox.Show("Couldn't configure logger:\n\n" + Logging.FirstError(),
						programName + " Error");
					return; // exit
				}

				// disable logic-breaking "continue?" dialog
				Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

				// intercept uncaught exceptions for logging
				AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

				try
				{
					log.Info("Launching.");

					// order is important here

					// must be done before creating a window
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);

					// prepare Controller instance to receive commands
					Controller.InitInstance();

					// this should create a window
					// which sets a synchronization context for the ui thread
					var context = new MyApplicationContext();

					// pass synchronization context to Controller to finish initializing it
					Controller.Instance.RegisterSyncContext(SynchronizationContext.Current);

					Application.Run(context);
				}
				finally
				{
					log.Info("Exiting.");

					Controller.DisposeInstance();
				}
			}
		}

		private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
		{
			Exception e = (Exception)args.ExceptionObject;
			log.Fatal("Unhandled exception.", e);
			MessageBox.Show("Unexpected error. See log file for details.",
				programName + " Error");
		}
	}
}
