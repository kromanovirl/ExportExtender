
namespace ExportExtender.App.Forms
{
	partial class JobWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.labelStatus = new System.Windows.Forms.Label();
			this.labelPath = new System.Windows.Forms.Label();
			this.labelFilename = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonOpenFolder = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.checkboxCloseWhenFinished = new System.Windows.Forms.CheckBox();
			this.timerUpdateView = new System.Windows.Forms.Timer(this.components);
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatus.Location = new System.Drawing.Point(9, 75);
			this.labelStatus.Margin = new System.Windows.Forms.Padding(6);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(89, 24);
			this.labelStatus.TabIndex = 2;
			this.labelStatus.Text = "WAITING";
			// 
			// labelPath
			// 
			this.labelPath.AutoSize = true;
			this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPath.Location = new System.Drawing.Point(9, 47);
			this.labelPath.Margin = new System.Windows.Forms.Padding(6, 3, 6, 6);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(182, 16);
			this.labelPath.TabIndex = 1;
			this.labelPath.Text = "c:\\users\\etc\\desktop\\projects";
			// 
			// labelFilename
			// 
			this.labelFilename.AutoSize = true;
			this.labelFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFilename.Location = new System.Drawing.Point(9, 9);
			this.labelFilename.Margin = new System.Windows.Forms.Padding(6);
			this.labelFilename.Name = "labelFilename";
			this.labelFilename.Size = new System.Drawing.Size(154, 29);
			this.labelFilename.TabIndex = 0;
			this.labelFilename.Text = "inputFile.wav";
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(291, 3);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 3;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonOpenFolder
			// 
			this.buttonOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOpenFolder.Location = new System.Drawing.Point(129, 3);
			this.buttonOpenFolder.Name = "buttonOpenFolder";
			this.buttonOpenFolder.Size = new System.Drawing.Size(75, 23);
			this.buttonOpenFolder.TabIndex = 2;
			this.buttonOpenFolder.Text = "Open folder";
			this.buttonOpenFolder.UseVisualStyleBackColor = true;
			this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStop.Location = new System.Drawing.Point(210, 3);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 1;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// checkboxCloseWhenFinished
			// 
			this.checkboxCloseWhenFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkboxCloseWhenFinished.AutoSize = true;
			this.checkboxCloseWhenFinished.Location = new System.Drawing.Point(3, 7);
			this.checkboxCloseWhenFinished.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
			this.checkboxCloseWhenFinished.Name = "checkboxCloseWhenFinished";
			this.checkboxCloseWhenFinished.Size = new System.Drawing.Size(120, 17);
			this.checkboxCloseWhenFinished.TabIndex = 0;
			this.checkboxCloseWhenFinished.Text = "Close when finished";
			this.checkboxCloseWhenFinished.UseVisualStyleBackColor = true;
			// 
			// timerUpdateView
			// 
			this.timerUpdateView.Enabled = true;
			this.timerUpdateView.Interval = 1000;
			this.timerUpdateView.Tick += new System.EventHandler(this.timerUpdateView_Tick);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.labelFilename);
			this.flowLayoutPanel1.Controls.Add(this.labelPath);
			this.flowLayoutPanel1.Controls.Add(this.labelStatus);
			this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(387, 152);
			this.flowLayoutPanel1.TabIndex = 2;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel2.AutoSize = true;
			this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel2.Controls.Add(this.checkboxCloseWhenFinished);
			this.flowLayoutPanel2.Controls.Add(this.buttonOpenFolder);
			this.flowLayoutPanel2.Controls.Add(this.buttonStop);
			this.flowLayoutPanel2.Controls.Add(this.buttonClose);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(9, 111);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(369, 29);
			this.flowLayoutPanel2.TabIndex = 3;
			this.flowLayoutPanel2.WrapContents = false;
			// 
			// JobWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(387, 152);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "JobWindow";
			this.Text = "Job";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonOpenFolder;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.CheckBox checkboxCloseWhenFinished;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.Label labelFilename;
		private System.Windows.Forms.Timer timerUpdateView;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
	}
}