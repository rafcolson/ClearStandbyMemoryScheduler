using System;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace ClearStandbyMemoryScheduler
{
    internal partial class MainForm : Form
    {
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;

        private static System.Timers.Timer SystemTimer { get; set; }
        private static Timer Timer { get; set; }
        private static bool IsProcessing { get; set; }

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr window, int index, int value);
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr window, int index);

        #region Initialization

        internal MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            Icon = MainNotifyIcon.Icon = Properties.Resources.MainIcon;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_SYSCOMMAND:
                    if (Properties.Settings.Default.HideToSystemTray && (m.WParam.ToInt32() & 0xFFF0) == SC_MINIMIZE)
                    {
                        HiddenInSystemTray(true);
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown && Properties.Settings.Default.HideToSystemTray)
            {
                HiddenInSystemTray(true);
                e.Cancel = true;
            }
            else
            {
                ClearStandbyMemory.Dispose();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeSettings();
            UpdateControls();
            if (Properties.Settings.Default.HideToSystemTray)
            {
                HiddenInSystemTray(true);
            }
            if (Properties.Settings.Default.RunAtStartup)
            {
                Start();
            }
        }

        private void InitializeSettings()
        {
            ThresholdComboBox.SelectedIndex = Properties.Settings.Default.ThresholdIndex;
            ThresholdNumericUpDown.Value = Properties.Settings.Default.ThresholdValue;
            TimeIntervalNumericUpDown.Value = Properties.Settings.Default.TimeInterval;
            ExecuteImmediatelyCheckBox.Checked = Properties.Settings.Default.ExecuteImmediately;
            HideToSystemTrayCheckBox.Checked = Properties.Settings.Default.HideToSystemTray;
            RunAtStartupCheckBox.Checked = Properties.Settings.Default.RunAtStartup;
        }

        #endregion

        #region Update

        private void UpdateControls()
        {
            ThresholdComboBox.Enabled = !IsProcessing;
            ThresholdNumericUpDown.Enabled = !IsProcessing && ThresholdComboBox.SelectedIndex != 0;
            TimeIntervalTableLayoutPanel.Enabled = !IsProcessing;
            ExecuteImmediatelyCheckBox.Enabled = !IsProcessing;
            HideToSystemTrayCheckBox.Enabled = !IsProcessing;
            RunAtStartupCheckBox.Enabled = !IsProcessing;
            StartButton.Enabled = !IsProcessing;
            StopButton.Enabled = IsProcessing;
        }

        #endregion

        #region Main

        private static void ExecuteClearStandbyMemory(object source, System.Timers.ElapsedEventArgs e)
        {
            MemoryInfo.Threshold threshold = (MemoryInfo.Threshold)Properties.Settings.Default.ThresholdIndex;
            decimal megabytes = Properties.Settings.Default.ThresholdValue;
            ClearStandbyMemory.Execute(threshold, megabytes);
        }

        private void HiddenInSystemTray(bool enabled)
        {
            Opacity = 0;
            if (enabled)
            {
                Hide();
            }
            else
            {
                Show();
            }
            Opacity = 1;
            ShowInTaskbar = !enabled;
            MainNotifyIcon.Visible = enabled;
            int windowStyle = GetWindowLong(Handle, GWL_EXSTYLE);
            if (enabled)
            {
                windowStyle |= WS_EX_TOOLWINDOW;
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                windowStyle &= ~WS_EX_TOOLWINDOW;
                WindowState = FormWindowState.Normal;
            }
            SetWindowLong(Handle, GWL_EXSTYLE, windowStyle);
        }

        private void Start()
        {
            if (Properties.Settings.Default.ExecuteImmediately)
            {
                ExecuteClearStandbyMemory(null, null);
            }
            int seconds = decimal.ToInt32(TimeIntervalNumericUpDown.Value);
            TimerProgressBar.Maximum = seconds * 1000;
            Timer = GetTimer(seconds);
            IsProcessing = true;

            UpdateControls();
        }

        private void Stop()
        {
            SystemTimer.Stop();
            SystemTimer.Elapsed -= ExecuteClearStandbyMemory;
            Timer.Stop();
            TimerProgressBar.Value = 0;
            IsProcessing = false;

            UpdateControls();
        }

        private Timer GetTimer(double seconds)
        {
            Timer timer = new Timer
            {
                Interval = 1000,
                Enabled = true
            };
            timer.Tick += ProgressBarTick;

            SystemTimer = new System.Timers.Timer
            {
                Interval = seconds * 1000,
                Enabled = true
            };
            SystemTimer.Elapsed += ExecuteClearStandbyMemory;

            return timer;
        }

        #endregion

        #region Events

        private void ProgressBarTick(object sender, EventArgs e)
        {
            if (TimerProgressBar.Value < TimerProgressBar.Maximum)
            {
                TimerProgressBar.Value += Timer.Interval;
            }
            else
            {
                TimerProgressBar.Value = 0;
            }
        }

        private void ThresholdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThresholdNumericUpDown.Enabled = ThresholdComboBox.SelectedIndex != 0;
            Properties.Settings.Default.ThresholdIndex = ThresholdComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void ThresholdNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ThresholdValue = ThresholdNumericUpDown.Value;
            Properties.Settings.Default.Save();
        }

        private void TimeIntervalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TimeInterval = TimeIntervalNumericUpDown.Value;
            Properties.Settings.Default.Save();
        }

        private void ExecuteImmediatelyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ExecuteImmediately = ExecuteImmediatelyCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void HideToSystemTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HideToSystemTray = HideToSystemTrayCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void RunAtStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RunAtStartup = RunAtStartupCheckBox.Checked;
            Properties.Settings.Default.Save();
            Program.RunAtStartup(RunAtStartupCheckBox.Checked);
        }

        private void MainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) => HiddenInSystemTray(false);

        private void StartButton_Click(object sender, EventArgs e) => Start();

        private void StopButton_Click(object sender, EventArgs e) => Stop();

        private void OpenStripMenuItem_Click(object sender, EventArgs e) => HiddenInSystemTray(false);

        private void StartToolStripMenuItem_Click(object sender, EventArgs e) => Start();

        private void StopToolStripMenuItem_Click(object sender, EventArgs e) => Stop();

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void MainNotifyIconContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StartToolStripMenuItem.Enabled = !IsProcessing;
            StopToolStripMenuItem.Enabled = IsProcessing;
        }

        #endregion
    }
}
