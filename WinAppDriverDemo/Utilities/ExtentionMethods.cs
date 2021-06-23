using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinAppDriverDemo.Utilities
{
   public static  class ExtentionMethods
    {
        public static WindowsElement GetWindowsElement(this WindowsDriver<WindowsElement> windowsDriver, string Locator)
        {         

            var l = Locator.Split('>', 2);
            if (l[0].Equals("Id"))
                return windowsDriver.FindElementByAccessibilityId(l[1]);
            else
            {
               return  windowsDriver.FindElement(CommonFunctions.GetBy(Locator));
            }
        }

            

    }
}
