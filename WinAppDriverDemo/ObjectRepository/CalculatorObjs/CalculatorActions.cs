using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using WinAppDriverDemo.Utilities;

namespace WinAppDriverDemo.ObjectRepository.CalculatorObjs
{
    public class CalculatorActions
    {
        private IConfiguration _configuration;
        private WindowsDriver<WindowsElement> _windowsDriver;
        private Waits _waits;
        public CalculatorActions(WindowsDriver<WindowsElement> windowsDriver, Waits waits)
        {
            _windowsDriver = windowsDriver;
            _waits = waits;
            _configuration = new ConfigurationBuilder()
            .SetBasePath(CommonFunctions.GetProjectPathOfFolder(@"\ObjectRepository\CalculatorObjs"))
            .AddJsonFile("CalculatorLocators.json")
            .Build();


        }


        public void SelectNumber(int num)
        {
            var locator = _configuration["Numbers"];

            _windowsDriver.GetWindowsElement(string.Format(locator, num)).Click();


        }

        public void ClickAddButton()
        {
            var locator = _configuration["PlusOperator"];


            _waits.WaitforWinElement(locator);
            _windowsDriver.GetWindowsElement(locator).Click();


        }
        public void ClickMinusButton()
        {
            var locator = _configuration["MinusOperator"];


            _windowsDriver.GetWindowsElement(locator).Click();


        }
        public void ClickEqualToButton()
        {

            var locator = _configuration["EqualOperator"];
            _waits.WaitforWinElement(locator);
            _windowsDriver.GetWindowsElement(locator).Click();

        }
        public void VerifyResult(int expectedResult)
        {
            var locator = _configuration["ResultContainer"];

            int Actualresult = int.Parse(_windowsDriver.GetWindowsElement(locator).Text.Split(" ")[2]);

            Assert.AreEqual(Actualresult, expectedResult, "Results are not matching");
        }





    }
}

