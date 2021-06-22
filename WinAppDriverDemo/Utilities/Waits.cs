using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WinAppDriverDemo.Utilities
{
    public class Waits
    {
        private WindowsDriver<WindowsElement> _windowsDriver;

        public Waits(WindowsDriver<WindowsElement> windowsDriver)
        {
            _windowsDriver = windowsDriver;
        }

        public void WaitforWinElement(string locator)
        {

            var wait = new DefaultWait<WindowsDriver<WindowsElement>>(_windowsDriver)
            {
                Timeout = TimeSpan.FromSeconds(120),
                PollingInterval=TimeSpan.FromSeconds(5)
                
            };

            var waittime = 120000;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            var notdisplayed = true;
            while(waittime>timer.ElapsedMilliseconds && notdisplayed)
            {

                var l = locator.Split('>', 2);
                if (l[0].Equals("Id"))
                {
                    wait.Until(ele =>
                ele.FindElementByAccessibilityId(l[1]).Displayed == true);
                    notdisplayed = false;
                }
                   
                else
                {
                    wait.Until(ele =>
               ele.FindElement(CommonFunctions.GetBy(locator)).Displayed == true);
                    notdisplayed = false;
                }
            }

            timer.Reset();


            }




        }






    }

