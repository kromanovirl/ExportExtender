using log4net;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ExportExtender.App.Forms
{
	public partial class JobWindow : Form
	{
		private static readonly ILog log
			= LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		// note: changed by other threads
		private Job job;

		public JobWindow()
		{
			InitializeComponent();
		}

		public void SetJob(Job job)
		{
			this.job = job;

			// window title
			Text = job.Filename;

			labelFilename.Text = job.Filename;
			labelPath.Text = job.Path;
			UpdateView();
		}

		// status may change after calling
		private bool CanClose(Job.JobStatus status)
		{
			switch (status)
			{
				case Job.JobStatus.Waiting:
				case Job.JobStatus.Running:
					return false;
				default:
					return true;
			}
		}

		private void UpdateView()
		{
			var status = job.Status;

			if (status == Job.JobStatus.Finished && checkboxCloseWhenFinished.Checked)
			{
				Close();
				return;
			}

			buttonStop.Enabled = !CanClose(status);
			buttonClose.Enabled = CanClose(status);
			labelStatus.Text = status.ToString();

			//UpdateConsole();
		}

		public void StartConsole(StreamReader stream)
		{
		}

		public void StopConsole()
		{
			//UpdateConsole();
		}

		/*
		private void UpdateConsole()
		{
			var stream = job.ConsoleStream;
			if (stream == null)
			{
				return;
			}

			while (true)
			{
				string line = stream.ReadLine();
				if (line == null)
				{
					break;
				}
				textBoxConsole.Lines.Append(line);
			}
		}
		*/

		private void buttonClose_Click(object sender, EventArgs e)
		{
			if (CanClose(job.Status))
			{
				Close();
			}
		}

		private void buttonOpenFolder_Click(object sender, EventArgs e)
		{
			try
			{
				if (Directory.Exists(job.Path))
				{
					ProcessStartInfo startInfo = new ProcessStartInfo
					{
						Arguments = job.Path,
						FileName = "explorer.exe",
					};

					Process.Start(startInfo);
				}
				else
				{
					log.Error("Directory does not exist: " + job.Path);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex);
			}
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			job.Stop();
		}

		private void timerUpdateView_Tick(object sender, EventArgs e)
		{
			UpdateView();
		}
	}
}
