using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using WinAppDriverDemo.Utilities;

namespace WinAppDriverDemo.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        private IObjectContainer _IObjectContainer;
        private WindowsSession _winSession; 
        public static string ScreenshotPath;
        public WindowsDriver<WindowsElement> windowsDriver;
        private static ScenarioContext _scenarioContext;
        public static string reportPath = CommonFunctions.GetProjectPathOfFolder("TestReports");
        public static string SubFolderName;
        private ISpecFlowOutputHelper _specFlowOutputHelper;


        public Hooks(IObjectContainer objectContainer, WindowsSession windowsSession, ScenarioContext scenarioContext,ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _IObjectContainer = objectContainer;
            _winSession = windowsSession;
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;

        }



        [BeforeTestRun]
        public static void InitializeReport()
        {
            SubFolderName = "AutomationResults" + DateTime.Today.ToString("ddMMyyyy") + "_" + DateTime.Now.ToShortTimeString().Replace(':', '_').Replace(" ", "_");
            Directory.CreateDirectory(reportPath + @"\" + SubFolderName + @"\");
            Directory.CreateDirectory(reportPath + @"\" + SubFolderName + @"\" + @"\" + "ScreenShots" + @"\");
            ScreenshotPath = reportPath + @"\" + SubFolderName + @"\" + @"\" + "ScreenShots" + @"\";
        }


   [BeforeFeature]
   public static void BeforeFeature()
        {
            WindowsSession.StartWinAppDriver();

        }



        [BeforeScenario]
        public void BeforeScenario()
        {
            if (windowsDriver == null)
            {
                windowsDriver = _winSession.LaunchApplication("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            }

            _IObjectContainer.RegisterInstanceAs(windowsDriver);

        }


        [AfterStep]
        public void InsertReportingSteps()
        {

            if (_scenarioContext.TestError != null)
            {
                #region Error Message 
                string Failmsg = "Message: " + _scenarioContext.TestError.Message +
                                "Inner Exception:" + _scenarioContext.TestError.InnerException +
                                 "Stack Trace: " + _scenarioContext.TestError.StackTrace;
                #endregion

                #region ScreenShot

                Random rad = new Random();
                string Imgname = "image" + rad.Next(0, 1000000);

                ((ITakesScreenshot)windowsDriver).GetScreenshot().SaveAsFile(ScreenshotPath + Imgname);

                string f = @"./Screenshots/" + Imgname;
                _specFlowOutputHelper.WriteLine(Failmsg);
                _specFlowOutputHelper.AddAttachment(f);
                #endregion

            }

        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
           
            windowsDriver.Quit();
            WindowsSession.KillProcess("Calculator.exe");

        }

        [AfterFeature]
        public static void AfterFeature()
        {
            WindowsSession.KillProcess("WinAppDriver");

        }


        [AfterTestRun]
        public static void AfterTestRun()
        {


            //Random rad = new Random();
            //string Filename = "Report_" + rad.Next(0, 10000);
            //var batFile = CommonFuntions.GetProjectPathOfFolder("BatchFiles") + "RunPgm.bat";
            //var p1 = AppContext.BaseDirectory;
            //var p2 = Assembly.GetExecutingAssembly().GetName().Name + ".dll";
            //var p3 = reportPath + @"\" + SubFolderName + @"\" + Filename + ".html";

            //var process = new Process();
            //var startinfo = new ProcessStartInfo(batFile);
            //startinfo.Arguments = string.Format("{0} {1} {2}", p1, p2, p3);
            //startinfo.UseShellExecute = false;
            //process.StartInfo = startinfo;
            //process.Start();

        }
    }
}
