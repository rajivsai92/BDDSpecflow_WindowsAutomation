using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;

namespace WinAppDriverDemo.Utilities
{
   public  class WindowsSession
    {
       

        public WindowsDriver<WindowsElement> LaunchApplication(string AppIdOrAppPath)
        {
            WindowsDriver<WindowsElement> winSession;

            try
            {
                //StartWinAppDriver();
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", AppIdOrAppPath);
                appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                winSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appCapabilities, TimeSpan.FromSeconds(180));
                winSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception while Launching Application <br>Exception : " + ex);
            }

            return winSession;

        }
        public static void KillProcess(string name)
        {

            Process[] p1 = Process.GetProcesses();
            foreach (Process p in p1)
            {
                if (p.ProcessName.Contains(name))
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception ex)
                    {

                    }
            }
        }


        /// <summary>
        /// Used to launch WinAppDriver.exe
        /// </summary>

        public static void StartWinAppDriver()
        {
            KillProcess("WinAppDriver");

            var process = new Process();
            var startinfo = new ProcessStartInfo(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            startinfo.UseShellExecute = true;
            startinfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo = startinfo;
            process.Start();
            Thread.Sleep(5000);
        }

    }
}
