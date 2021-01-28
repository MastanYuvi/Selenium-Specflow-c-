using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowTestFW.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowTestFW.Hooks
{
    [Binding]
    public sealed class Hooks
    {

        private Global global;
        private static ExtentTest featureName;
        private static ExtentTest scenarioName;
        private static ExtentReports extent;

        public Hooks(Global global)
        {
            this.global = global;
        }


        [BeforeTestRun]
        public static void InitializeReportSteps()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var basePath = currentDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];
            var reporter = basePath + "\\Reports\\ExtentReport.html";

            var htmlReporter = new ExtentHtmlReporter(reporter);


            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);



        }


        [BeforeFeature]
        public static void CreateExtentTest()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            global.Driver = new ChromeDriver();
            global.Driver.Manage().Window.Maximize();
            global.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            global.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            scenarioName = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }


        public MediaEntityModelProvider TakeScreenShotAsBase64String(String Name)
        {
            var MediaEntity = ((ITakesScreenshot)global.Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(MediaEntity, Name).Build();
        }

        [AfterStep]
        public void InitializeStepReports()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            var StepError = ScenarioContext.Current.TestError;
            var skippedStep = ScenarioContext.Current.ScenarioExecutionStatus.ToString();
            var Screenshot = TakeScreenShotAsBase64String(ScenarioContext.Current.ScenarioInfo.Title.Trim());


            //Passed Steps
            if (StepError == null)
            {
                if (stepType.Equals("Given"))
                {
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType.Equals("When"))
                {
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType.Equals("Then"))
                {
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType.Equals("And"))
                {
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }

            }


            //FailedSteps

            else if(StepError != null)
            {
                if (stepType.Equals("Given"))
                {
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, Screenshot);
                }
                else if (stepType.Equals("When"))
                {
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, Screenshot);
                }
                else if (stepType.Equals("Then"))
                {
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, Screenshot);
                }
                else if (stepType.Equals("And"))
                {
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, Screenshot);
                }
            }


            //Skipped Steps
            if (skippedStep == "StepDefinitionPending")
            {
                if (stepType.Equals("Given"))
                {
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending / Skipped");
                }
                else if (stepType.Equals("When"))
                {
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending / Skipped");
                }
                else if (stepType.Equals("Then"))
                {
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending / Skipped");
                }
                else if (stepType.Equals("And"))
                {
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending / Skipped");
                }
            }

        }

        [AfterScenario]
        public void AfterScenario()
        {
            global.Driver.Quit();
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var basePath = currentDirectory.Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];
            var DriverKiller = basePath + "\\Utils\\DriverTaskKiller.cmd";
            ProcessStartInfo startInfo = new ProcessStartInfo(DriverKiller);
            Process process = Process.Start(startInfo);
            int timeToWait = 30000; // wait up to 30 seconds for process to end
            process.WaitForExit(timeToWait);
        }



        [AfterTestRun]
        public static void FlushExtentReport()
        {
            extent.Flush();
        }
    }
}
