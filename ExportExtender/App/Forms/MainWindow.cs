using log4net;
using log4net.Appender;
using log4net.Layout;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ExportExtender.App.Forms
{
	public partial class MainWindow : Form
	{
		private static readonly ILog log
			= LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		private static string scrollback = "";

		private MemoryAppender memoryAppender;
		private PatternLayout patternLayout;

		private bool started = false;
		private Properties.Settings settings;

		public MainWindow()
		{
			InitializeComponent();

			memoryAppender = Logging.MemoryAppender;
			patternLayout = Logging.MemoryAppenderPatternLayout;
			settings = Properties.Settings.Default;

			// restore log scrollback
			textBoxLogView.Text = scrollback;
			PopulateFormFields();
			started = settings.WatcherStarted;
			UpdateUI();

			if (started)
			{
				StartWatcher();
			}
		}

		private void PopulateFormFields()
		{
			textBoxExecutable.Text = settings.Executable;
			textBoxCommandArgs.Text = settings.CommandArgs;
			textBoxWatchFolder.Text = settings.WatchFolder;
			textBoxFileFilter.Text = settings.FileFilter;
			numericFileIdleSeconds.Value = settings.FileIdleSeconds;
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			// save log scrollback
			scrollback = textBoxLogView.Text;
			settings.Save();
			base.OnFormClosing(e);
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			base.OnFormClosed(e);
		}

		private void buttonStartStop_Click(object sender, EventArgs e)
		{
			started = !started;
			settings.WatcherStarted = started;
			settings.Save();
			UpdateUI();

			//TODO call event handler from main app?

			if (started)
			{
				StartWatcher();
			}
			else
			{
				StopWatcher();
			}
		}

		private void StartWatcher()
		{
			Controller.Instance.SetJobCommand(
				settings.Executable,
				settings.CommandArgs);
			Controller.Instance.StartWatcher(
				settings.WatchFolder,
				settings.FileFilter,
				settings.FileIdleSeconds,
				1f);
		}

		private void StopWatcher()
		{
			Controller.Instance.StopWatcher();
		}

		private void UpdateUI()
		{
			buttonStartStop.Text = started ? "Stop watching" : "Start watching";

			textBoxExecutable.ReadOnly = started;
			textBoxCommandArgs.ReadOnly = started;
			textBoxWatchFolder.ReadOnly = started;
			textBoxFileFilter.ReadOnly = started;
			numericFileIdleSeconds.ReadOnly = started;

			buttonBrowseExecutable.Enabled = !started;
			buttonBrowseWatchFolder.Enabled = !started;
		}

		private void UpdateLogView()
		{
			foreach (var loggingEvent in memoryAppender.PopAllEvents())
			{
				textBoxLogView.AppendText(patternLayout.Format(loggingEvent));
			}
		}

		private void timerLogRefresh_Tick(object sender, EventArgs e)
		{
			UpdateLogView();
		}

		private void textBoxExecutable_TextChanged(object sender, EventArgs e)
		{
			settings.Executable = textBoxExecutable.Text;
		}

		private void textBoxCommandArgs_TextChanged(object sender, EventArgs e)
		{
			settings.CommandArgs = textBoxCommandArgs.Text;
		}

		private void textBoxWatchFolder_TextChanged(object sender, EventArgs e)
		{
			settings.WatchFolder = textBoxWatchFolder.Text;
		}

		private void textBoxFileFilter_TextChanged(object sender, EventArgs e)
		{
			settings.FileFilter = textBoxFileFilter.Text;
		}

		private void numericFileIdleSeconds_ValueChanged(object sender, EventArgs e)
		{
			settings.FileIdleSeconds = (int)numericFileIdleSeconds.Value;
		}

		private void buttonBrowseExecutable_Click(object sender, EventArgs e)
		{
			if (!started && openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string path = openFileDialog.FileName;
				textBoxExecutable.Text = path;
				settings.Executable = path;
				settings.Save();
			}
		}

		private void buttonBrowseWatchFolder_Click(object sender, EventArgs e)
		{
			if (!started && folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				string path = folderBrowserDialog.SelectedPath;
				textBoxWatchFolder.Text = path;
				settings.WatchFolder = path;
				settings.Save();
			}
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
