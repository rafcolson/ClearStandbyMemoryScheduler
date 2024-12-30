using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Principal;
using System.Deployment.Application;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;

namespace ClearStandbyMemoryScheduler
{
    internal class SingleInstanceApplication : WindowsFormsApplicationBase
    {
        private readonly Form mainForm;

        internal SingleInstanceApplication(Form form)
        {
            mainForm = form;
            IsSingleInstance = true;
            StartupNextInstance += This_StartupNextInstance;
        }

        private void This_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            e.BringToForeground = true;
            mainForm.ShowInTaskbar = true;
            mainForm.WindowState = FormWindowState.Minimized;
            mainForm.Show();
            mainForm.WindowState = FormWindowState.Normal;
        }

        protected override void OnCreateMainForm()
        {
            MainForm = mainForm;
        }
    }

    internal static class Program
    {
        private const string CURRENT_VERSION_PATH = @"SOFTWARE\Microsoft\Windows\CurrentVersion";

        private static readonly string RUN_KEY = Path.Combine(CURRENT_VERSION_PATH, "Run");

        internal static readonly string AppName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);

        [STAThread]
        private static void Main()
        {
            using (WindowsIdentity wi = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal wp = new WindowsPrincipal(wi);
                if (!wp.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    try
                    {
                        ProcessStartInfo processInfo = new ProcessStartInfo(Application.ExecutablePath)
                        {
                            UseShellExecute = true,
                            Verb = "runas"
                        };
                        Process.Start(processInfo);
                        if (ApplicationDeployment.IsNetworkDeployed)
                        {
                            Application.Exit();
                        }
                        return;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Failed running deployment '{AppName}' with administrator rights.");
                        return;
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleInstanceApplication app = new SingleInstanceApplication(new MainForm());
            app.Run(Environment.GetCommandLineArgs());
        }

        internal static void RunAtStartup(bool enable)
        {
            using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(RUN_KEY, true))
            {
                string startupValue = AppName;
                if (enable)
                {
                    regKey.SetValue(startupValue, Application.ExecutablePath);
                }
                else
                {
                    regKey.DeleteValue(startupValue, false);
                }
            }
        }
    }
}
