
namespace ExportExtender.App.Forms
{
	partial class MainWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.textBoxWatchFolder = new System.Windows.Forms.TextBox();
			this.buttonBrowseWatchFolder = new System.Windows.Forms.Button();
			this.buttonStartStop = new System.Windows.Forms.Button();
			this.textBoxLogView = new System.Windows.Forms.TextBox();
			this.timerLogRefresh = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanelSettings = new System.Windows.Forms.TableLayoutPanel();
			this.buttonExit = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxFileFilter = new System.Windows.Forms.TextBox();
			this.textBoxCommandArgs = new System.Windows.Forms.TextBox();
			this.buttonBrowseExecutable = new System.Windows.Forms.Button();
			this.textBoxExecutable = new System.Windows.Forms.TextBox();
			this.numericFileIdleSeconds = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.tableLayoutPanelSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericFileIdleSeconds)).BeginInit();
			this.tableLayoutPanelMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxWatchFolder
			// 
			this.textBoxWatchFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxWatchFolder.Location = new System.Drawing.Point(94, 59);
			this.textBoxWatchFolder.Name = "textBoxWatchFolder";
			this.textBoxWatchFolder.Size = new System.Drawing.Size(400, 20);
			this.textBoxWatchFolder.TabIndex = 2;
			this.textBoxWatchFolder.TextChanged += new System.EventHandler(this.textBoxWatchFolder_TextChanged);
			// 
			// buttonBrowseWatchFolder
			// 
			this.buttonBrowseWatchFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonBrowseWatchFolder.Location = new System.Drawing.Point(500, 58);
			this.buttonBrowseWatchFolder.Name = "buttonBrowseWatchFolder";
			this.buttonBrowseWatchFolder.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowseWatchFolder.TabIndex = 4;
			this.buttonBrowseWatchFolder.Text = "Browse";
			this.buttonBrowseWatchFolder.UseVisualStyleBackColor = true;
			this.buttonBrowseWatchFolder.Click += new System.EventHandler(this.buttonBrowseWatchFolder_Click);
			// 
			// buttonStartStop
			// 
			this.buttonStartStop.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonStartStop.Location = new System.Drawing.Point(384, 139);
			this.buttonStartStop.Name = "buttonStartStop";
			this.buttonStartStop.Size = new System.Drawing.Size(110, 24);
			this.buttonStartStop.TabIndex = 6;
			this.buttonStartStop.Text = "Start watching";
			this.buttonStartStop.UseVisualStyleBackColor = true;
			this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
			// 
			// textBoxLogView
			// 
			this.textBoxLogView.AcceptsReturn = true;
			this.textBoxLogView.AcceptsTab = true;
			this.textBoxLogView.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxLogView.CausesValidation = false;
			this.textBoxLogView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxLogView.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxLogView.Location = new System.Drawing.Point(3, 3);
			this.textBoxLogView.Multiline = true;
			this.textBoxLogView.Name = "textBoxLogView";
			this.textBoxLogView.ReadOnly = true;
			this.textBoxLogView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxLogView.Size = new System.Drawing.Size(578, 163);
			this.textBoxLogView.TabIndex = 8;
			this.textBoxLogView.TabStop = false;
			// 
			// timerLogRefresh
			// 
			this.timerLogRefresh.Enabled = true;
			this.timerLogRefresh.Tick += new System.EventHandler(this.timerLogRefresh_Tick);
			// 
			// tableLayoutPanelSettings
			// 
			this.tableLayoutPanelSettings.AutoSize = true;
			this.tableLayoutPanelSettings.ColumnCount = 3;
			this.tableLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelSettings.Controls.Add(this.buttonExit, 2, 5);
			this.tableLayoutPanelSettings.Controls.Add(this.label7, 0, 4);
			this.tableLayoutPanelSettings.Controls.Add(this.label5, 0, 3);
			this.tableLayoutPanelSettings.Controls.Add(this.buttonStartStop, 1, 5);
			this.tableLayoutPanelSettings.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanelSettings.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanelSettings.Controls.Add(this.textBoxFileFilter, 1, 3);
			this.tableLayoutPanelSettings.Controls.Add(this.textBoxCommandArgs, 1, 1);
			this.tableLayoutPanelSettings.Controls.Add(this.buttonBrowseExecutable, 2, 0);
			this.tableLayoutPanelSettings.Controls.Add(this.textBoxExecutable, 1, 0);
			this.tableLayoutPanelSettings.Controls.Add(this.buttonBrowseWatchFolder, 2, 2);
			this.tableLayoutPanelSettings.Controls.Add(this.textBoxWatchFolder, 1, 2);
			this.tableLayoutPanelSettings.Controls.Add(this.numericFileIdleSeconds, 1, 4);
			this.tableLayoutPanelSettings.Controls.Add(this.label4, 0, 2);
			this.tableLayoutPanelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelSettings.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
			this.tableLayoutPanelSettings.Location = new System.Drawing.Point(3, 172);
			this.tableLayoutPanelSettings.Name = "tableLayoutPanelSettings";
			this.tableLayoutPanelSettings.RowCount = 6;
			this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelSettings.Size = new System.Drawing.Size(578, 166);
			this.tableLayoutPanelSettings.TabIndex = 9;
			// 
			// buttonExit
			// 
			this.buttonExit.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonExit.Location = new System.Drawing.Point(500, 139);
			this.buttonExit.Name = "buttonExit";
			this.buttonExit.Size = new System.Drawing.Size(75, 24);
			this.buttonExit.TabIndex = 19;
			this.buttonExit.Text = "Exit";
			this.buttonExit.UseVisualStyleBackColor = true;
			this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 116);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "File idle seconds";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(43, 90);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "File filter";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Command args";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Executable";
			// 
			// textBoxFileFilter
			// 
			this.textBoxFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFileFilter.Location = new System.Drawing.Point(94, 87);
			this.textBoxFileFilter.Name = "textBoxFileFilter";
			this.textBoxFileFilter.Size = new System.Drawing.Size(400, 20);
			this.textBoxFileFilter.TabIndex = 10;
			this.textBoxFileFilter.TextChanged += new System.EventHandler(this.textBoxFileFilter_TextChanged);
			// 
			// textBoxCommandArgs
			// 
			this.textBoxCommandArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCommandArgs.Location = new System.Drawing.Point(94, 32);
			this.textBoxCommandArgs.Name = "textBoxCommandArgs";
			this.textBoxCommandArgs.Size = new System.Drawing.Size(400, 20);
			this.textBoxCommandArgs.TabIndex = 8;
			this.textBoxCommandArgs.TextChanged += new System.EventHandler(this.textBoxCommandArgs_TextChanged);
			// 
			// buttonBrowseExecutable
			// 
			this.buttonBrowseExecutable.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonBrowseExecutable.Location = new System.Drawing.Point(500, 3);
			this.buttonBrowseExecutable.Name = "buttonBrowseExecutable";
			this.buttonBrowseExecutable.Size = new System.Drawing.Size(75, 23);
			this.buttonBrowseExecutable.TabIndex = 7;
			this.buttonBrowseExecutable.Text = "Browse";
			this.buttonBrowseExecutable.UseVisualStyleBackColor = true;
			this.buttonBrowseExecutable.Click += new System.EventHandler(this.buttonBrowseExecutable_Click);
			// 
			// textBoxExecutable
			// 
			this.textBoxExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxExecutable.Location = new System.Drawing.Point(94, 4);
			this.textBoxExecutable.Name = "textBoxExecutable";
			this.textBoxExecutable.Size = new System.Drawing.Size(400, 20);
			this.textBoxExecutable.TabIndex = 6;
			this.textBoxExecutable.TextChanged += new System.EventHandler(this.textBoxExecutable_TextChanged);
			// 
			// numericFileIdleSeconds
			// 
			this.numericFileIdleSeconds.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.numericFileIdleSeconds.Location = new System.Drawing.Point(94, 113);
			this.numericFileIdleSeconds.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
			this.numericFileIdleSeconds.Name = "numericFileIdleSeconds";
			this.numericFileIdleSeconds.Size = new System.Drawing.Size(61, 20);
			this.numericFileIdleSeconds.TabIndex = 12;
			this.numericFileIdleSeconds.ValueChanged += new System.EventHandler(this.numericFileIdleSeconds_ValueChanged);
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 63);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Watch folder";
			// 
			// tableLayoutPanelMain
			// 
			this.tableLayoutPanelMain.ColumnCount = 1;
			this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelMain.Controls.Add(this.textBoxLogView, 0, 0);
			this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelSettings, 0, 1);
			this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
			this.tableLayoutPanelMain.RowCount = 2;
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanelMain.Size = new System.Drawing.Size(584, 341);
			this.tableLayoutPanelMain.TabIndex = 10;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 341);
			this.Controls.Add(this.tableLayoutPanelMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainWindow";
			this.Text = "ExportExtender";
			this.tableLayoutPanelSettings.ResumeLayout(false);
			this.tableLayoutPanelSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericFileIdleSeconds)).EndInit();
			this.tableLayoutPanelMain.ResumeLayout(false);
			this.tableLayoutPanelMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.TextBox textBoxWatchFolder;
		private System.Windows.Forms.Button buttonBrowseWatchFolder;
		private System.Windows.Forms.Button buttonStartStop;
		private System.Windows.Forms.TextBox textBoxLogView;
		private System.Windows.Forms.Timer timerLogRefresh;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSettings;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxFileFilter;
		private System.Windows.Forms.TextBox textBoxCommandArgs;
		private System.Windows.Forms.Button buttonBrowseExecutable;
		private System.Windows.Forms.TextBox textBoxExecutable;
		private System.Windows.Forms.NumericUpDown numericFileIdleSeconds;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Button buttonExit;
	}
}