using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ClearStandbyMemoryScheduler
{
    internal partial class MainForm : Form
    {
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr window, int index, int value);
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr window, int index);

        private static System.Timers.Timer SystemTimer { get; set; }
        private static Timer Timer { get; set; }
        private static bool IsProcessing { get; set; }

        #region Initialization

        internal MainForm()
        {
            InitializeComponent();
            Resize += MainForm_Resize;
            FormClosing += MainForm_FormClosing;
            Icon = MainNotifyIcon.Icon = Properties.Resources.MainIcon;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.WindowsShutDown && Properties.Settings.Default.HideToSystemTray)
            {
                WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeSettings();
            UpdateControls();
            if (Properties.Settings.Default.HideToSystemTray)
            {
                WindowState = FormWindowState.Minimized;
            }
            if (Properties.Settings.Default.RunAtStartup)
            {
                Start();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            bool minimizedAndHidden = WindowState == FormWindowState.Minimized && Properties.Settings.Default.HideToSystemTray;
            ShowInTaskbar = !minimizedAndHidden;
            MainNotifyIcon.Visible = minimizedAndHidden;
            int windowStyle = GetWindowLong(Handle, GWL_EXSTYLE);
            if (minimizedAndHidden)
            {
                windowStyle |= WS_EX_TOOLWINDOW;
                Hide();
            }
            else
            {
                windowStyle &= ~WS_EX_TOOLWINDOW;
            }
            SetWindowLong(Handle, GWL_EXSTYLE, windowStyle);
        }

        private void InitializeSettings()
        {
            TimeIntervalNumericUpDown.Value = Properties.Settings.Default.TimeInterval;
            ExecuteImmediatelyCheckBox.Checked = Properties.Settings.Default.ExecuteImmediately;
            HideToSystemTrayCheckBox.Checked = Properties.Settings.Default.HideToSystemTray;
            RunAtStartupCheckBox.Checked = Properties.Settings.Default.RunAtStartup;
        }

        #endregion

        #region Update

        private void UpdateControls()
        {
            StartButton.Enabled = !IsProcessing;
            StopButton.Enabled = IsProcessing;
            TimeIntervalTableLayoutPanel.Enabled = !IsProcessing;
            ExecuteImmediatelyCheckBox.Enabled = !IsProcessing;
            HideToSystemTrayCheckBox.Enabled = !IsProcessing;
            RunAtStartupCheckBox.Enabled = !IsProcessing;
        }

        #endregion

        #region Main

        private static void ExecuteClearStandbyMemory(object source, System.Timers.ElapsedEventArgs e)
        {
            ClearStandbyMemory.Execute();
        }

        private void Start()
        {
            if (Properties.Settings.Default.ExecuteImmediately)
            {
                ExecuteClearStandbyMemory(null, null);
            }
            int seconds = decimal.ToInt32(TimeIntervalNumericUpDown.Value * 60);
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

        private void PopUp()
        {
            Opacity = 0;
            Show();
            Opacity = 1;
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

        private void MainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PopUp();
            WindowState = FormWindowState.Normal;
        }

        private void StartButton_Click(object sender, EventArgs e) => Start();

        private void StopButton_Click(object sender, EventArgs e) => Stop();

        private void OpenStripMenuItem_Click(object sender, EventArgs e)
        {
            PopUp();
            WindowState = FormWindowState.Normal;
        }

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
