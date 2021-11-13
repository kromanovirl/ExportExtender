using ExportExtender.App.Forms;
using log4net;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ExportExtender.App
{
	public class MyApplicationContext : ApplicationContext
	{
		private static readonly ILog log
			= LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private NotifyIcon trayIcon;
		private MainWindow mainWindow;

		public MyApplicationContext()
		{
			trayIcon = new NotifyIcon()
			{
				Icon = Properties.Resources.TrayIcon,
				ContextMenu = new ContextMenu(new MenuItem[] {
				//new MenuItem("Delete converted files", MenuDeleteConvertedFiles),
				//new MenuItem("Open program folder", MenuOpenProgramFolder),
				//new MenuItem("Open input folder", MenuOpenWatchFolder),
				//new MenuItem("Open output folder", MenuOpenOutputFolder),
				//new MenuItem("Start", MenuStart),
				//new MenuItem("Stop", MenuStop),
				new MenuItem("Exit", MenuExit),
			}),
				Visible = true,
				//Text = "Started\n1 converted (99 GB)\n2 failed",
			};

			trayIcon.MouseDoubleClick += TrayIconDoubleClick;

			OpenMainWindow();
		}

		protected override void Dispose(bool disposing)
		{
			// TODO
			if (trayIcon != null)
			{
				// prevent ghost icon
				trayIcon.Visible = false;
				trayIcon.Dispose();
				trayIcon = null;
			}

			base.Dispose(disposing);
		}

		private void TrayIconDoubleClick(object sender, MouseEventArgs e)
		{
			OpenMainWindow();
		}

		private void OpenMainWindow()
		{
			if (mainWindow == null)
			{
				CreateMainWindow();
				mainWindow.Show();
			}
			else
			{
				mainWindow.Activate();
				if (mainWindow.WindowState == FormWindowState.Minimized)
				{
					mainWindow.WindowState = FormWindowState.Normal;
				}
			}
		}

		private void CreateMainWindow()
		{
			mainWindow = new MainWindow();
			mainWindow.FormClosed += MainWindowClosed;
		}

		private void MainWindowClosed(object sender, FormClosedEventArgs e)
		{
			// FIXME closed isn't the same as disposed?
			mainWindow = null;
		}

		private void MenuDeleteConvertedFiles(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void MenuOpenProgramFolder(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void MenuOpenWatchFolder(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void MenuOpenOutputFolder(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void MenuStart(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void MenuStop(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		void MenuExit(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
