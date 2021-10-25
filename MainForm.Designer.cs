
namespace ClearStandbyMemoryScheduler
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TimeIntervalLabel = new System.Windows.Forms.Label();
            this.TimeIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ExecuteImmediatelyCheckBox = new System.Windows.Forms.CheckBox();
            this.HideToSystemTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.RunAtStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.TimerProgressBar = new System.Windows.Forms.ProgressBar();
            this.StartStopTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.StopButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainNotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TimeIntervalTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.TimeIntervalNumericUpDown)).BeginInit();
            this.StartStopTableLayoutPanel.SuspendLayout();
            this.MainNotifyIconContextMenuStrip.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.TimeIntervalTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimeIntervalLabel
            // 
            this.TimeIntervalLabel.AutoSize = true;
            this.TimeIntervalLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeIntervalLabel.Location = new System.Drawing.Point(0, 0);
            this.TimeIntervalLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TimeIntervalLabel.Name = "TimeIntervalLabel";
            this.TimeIntervalLabel.Size = new System.Drawing.Size(171, 30);
            this.TimeIntervalLabel.TabIndex = 0;
            this.TimeIntervalLabel.Text = "Time interval (m)";
            this.TimeIntervalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeIntervalNumericUpDown
            // 
            this.TimeIntervalNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeIntervalNumericUpDown.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeIntervalNumericUpDown.Location = new System.Drawing.Point(171, 0);
            this.TimeIntervalNumericUpDown.Margin = new System.Windows.Forms.Padding(0);
            this.TimeIntervalNumericUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.TimeIntervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeIntervalNumericUpDown.Name = "TimeIntervalNumericUpDown";
            this.TimeIntervalNumericUpDown.Size = new System.Drawing.Size(115, 27);
            this.TimeIntervalNumericUpDown.TabIndex = 4;
            this.TimeIntervalNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TimeIntervalNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TimeIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.TimeIntervalNumericUpDown_ValueChanged);
            // 
            // ExecuteImmediatelyCheckBox
            // 
            this.ExecuteImmediatelyCheckBox.AutoSize = true;
            this.ExecuteImmediatelyCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExecuteImmediatelyCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExecuteImmediatelyCheckBox.Location = new System.Drawing.Point(9, 45);
            this.ExecuteImmediatelyCheckBox.Name = "ExecuteImmediatelyCheckBox";
            this.ExecuteImmediatelyCheckBox.Size = new System.Drawing.Size(286, 30);
            this.ExecuteImmediatelyCheckBox.TabIndex = 3;
            this.ExecuteImmediatelyCheckBox.Text = "Execute immediately";
            this.ExecuteImmediatelyCheckBox.UseVisualStyleBackColor = true;
            this.ExecuteImmediatelyCheckBox.CheckedChanged += new System.EventHandler(this.ExecuteImmediatelyCheckBox_CheckedChanged);
            // 
            // HideToSystemTrayCheckBox
            // 
            this.HideToSystemTrayCheckBox.AutoSize = true;
            this.HideToSystemTrayCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HideToSystemTrayCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HideToSystemTrayCheckBox.Location = new System.Drawing.Point(9, 81);
            this.HideToSystemTrayCheckBox.Name = "HideToSystemTrayCheckBox";
            this.HideToSystemTrayCheckBox.Size = new System.Drawing.Size(286, 30);
            this.HideToSystemTrayCheckBox.TabIndex = 4;
            this.HideToSystemTrayCheckBox.Text = "Hide to system tray";
            this.HideToSystemTrayCheckBox.UseVisualStyleBackColor = true;
            this.HideToSystemTrayCheckBox.CheckedChanged += new System.EventHandler(this.HideToSystemTrayCheckBox_CheckedChanged);
            // 
            // RunAtStartupCheckBox
            // 
            this.RunAtStartupCheckBox.AutoSize = true;
            this.RunAtStartupCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RunAtStartupCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunAtStartupCheckBox.Location = new System.Drawing.Point(9, 117);
            this.RunAtStartupCheckBox.Name = "RunAtStartupCheckBox";
            this.RunAtStartupCheckBox.Size = new System.Drawing.Size(286, 30);
            this.RunAtStartupCheckBox.TabIndex = 8;
            this.RunAtStartupCheckBox.Text = "Run at startup";
            this.RunAtStartupCheckBox.UseVisualStyleBackColor = true;
            this.RunAtStartupCheckBox.CheckedChanged += new System.EventHandler(this.RunAtStartupCheckBox_CheckedChanged);
            // 
            // TimerProgressBar
            // 
            this.TimerProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimerProgressBar.Location = new System.Drawing.Point(10, 166);
            this.TimerProgressBar.Margin = new System.Windows.Forms.Padding(4, 16, 4, 8);
            this.TimerProgressBar.Name = "TimerProgressBar";
            this.TimerProgressBar.Size = new System.Drawing.Size(284, 12);
            this.TimerProgressBar.TabIndex = 12;
            // 
            // StartStopTableLayoutPanel
            // 
            this.StartStopTableLayoutPanel.ColumnCount = 2;
            this.StartStopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StartStopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StartStopTableLayoutPanel.Controls.Add(this.StopButton, 0, 0);
            this.StartStopTableLayoutPanel.Controls.Add(this.StartButton, 0, 0);
            this.StartStopTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartStopTableLayoutPanel.Location = new System.Drawing.Point(6, 190);
            this.StartStopTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.StartStopTableLayoutPanel.Name = "StartStopTableLayoutPanel";
            this.StartStopTableLayoutPanel.RowCount = 1;
            this.StartStopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StartStopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.StartStopTableLayoutPanel.Size = new System.Drawing.Size(292, 37);
            this.StartStopTableLayoutPanel.TabIndex = 19;
            // 
            // StopButton
            // 
            this.StopButton.AutoSize = true;
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StopButton.Location = new System.Drawing.Point(149, 3);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(140, 31);
            this.StopButton.TabIndex = 17;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.AutoSize = true;
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartButton.Location = new System.Drawing.Point(3, 3);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(140, 31);
            this.StartButton.TabIndex = 15;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MainNotifyIcon
            // 
            this.MainNotifyIcon.ContextMenuStrip = this.MainNotifyIconContextMenuStrip;
            this.MainNotifyIcon.Text = "ClearStandbyMemoryScheduler";
            this.MainNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainNotifyIcon_MouseDoubleClick);
            // 
            // MainNotifyIconContextMenuStrip
            // 
            this.MainNotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.StartToolStripMenuItem,
            this.StopToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.MainNotifyIconContextMenuStrip.Name = "MainNotifyIconContextMenuStrip";
            this.MainNotifyIconContextMenuStrip.Size = new System.Drawing.Size(104, 92);
            this.MainNotifyIconContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.MainNotifyIconContextMenuStrip_Opening);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenStripMenuItem_Click);
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("StartToolStripMenuItem.Image")));
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.StartToolStripMenuItem.Text = "Start";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // StopToolStripMenuItem
            // 
            this.StopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("StopToolStripMenuItem.Image")));
            this.StopToolStripMenuItem.Name = "StopToolStripMenuItem";
            this.StopToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.StopToolStripMenuItem.Text = "Stop";
            this.StopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExitToolStripMenuItem.Image")));
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.TimeIntervalTableLayoutPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.StartStopTableLayoutPanel, 0, 5);
            this.MainTableLayoutPanel.Controls.Add(this.TimerProgressBar, 0, 4);
            this.MainTableLayoutPanel.Controls.Add(this.RunAtStartupCheckBox, 0, 3);
            this.MainTableLayoutPanel.Controls.Add(this.HideToSystemTrayCheckBox, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.ExecuteImmediatelyCheckBox, 0, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(6);
            this.MainTableLayoutPanel.RowCount = 6;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(304, 233);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // TimeIntervalTableLayoutPanel
            // 
            this.TimeIntervalTableLayoutPanel.ColumnCount = 2;
            this.TimeIntervalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TimeIntervalTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TimeIntervalTableLayoutPanel.Controls.Add(this.TimeIntervalNumericUpDown, 1, 0);
            this.TimeIntervalTableLayoutPanel.Controls.Add(this.TimeIntervalLabel, 0, 0);
            this.TimeIntervalTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeIntervalTableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.TimeIntervalTableLayoutPanel.Name = "TimeIntervalTableLayoutPanel";
            this.TimeIntervalTableLayoutPanel.RowCount = 1;
            this.TimeIntervalTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TimeIntervalTableLayoutPanel.Size = new System.Drawing.Size(286, 30);
            this.TimeIntervalTableLayoutPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(304, 233);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 272);
            this.MinimumSize = new System.Drawing.Size(320, 272);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClearStandbyMemoryScheduler";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimeIntervalNumericUpDown)).EndInit();
            this.StartStopTableLayoutPanel.ResumeLayout(false);
            this.StartStopTableLayoutPanel.PerformLayout();
            this.MainNotifyIconContextMenuStrip.ResumeLayout(false);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.TimeIntervalTableLayoutPanel.ResumeLayout(false);
            this.TimeIntervalTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TimeIntervalLabel;
        private System.Windows.Forms.NumericUpDown TimeIntervalNumericUpDown;
        private System.Windows.Forms.NotifyIcon MainNotifyIcon;
        private System.Windows.Forms.CheckBox ExecuteImmediatelyCheckBox;
        private System.Windows.Forms.CheckBox HideToSystemTrayCheckBox;
        private System.Windows.Forms.CheckBox RunAtStartupCheckBox;
        private System.Windows.Forms.ProgressBar TimerProgressBar;
        private System.Windows.Forms.TableLayoutPanel StartStopTableLayoutPanel;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ContextMenuStrip MainNotifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel TimeIntervalTableLayoutPanel;
    }
}
