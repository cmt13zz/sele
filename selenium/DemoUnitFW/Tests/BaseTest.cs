using NUnit.Framework;
using NUnit.Framework.Interfaces;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using DemoUnitFW.Pages;
using DemoUnitFW.Library;

namespace DemoUnitFW.Tests
{
    public class BaseTest
    {
        public static IWebDriver Driver;
        public static ExtentTest Test;
        public static ExtentTest Node;

        [OneTimeSetUp]
        
        public void CreateTestForExtendReport() {
            Test = Hooks.Extent.CreateTest(TestContext.CurrentContext.Test.ClassName); 
        }

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver();
            BasePage basePage = new BasePage(Driver);
            basePage.Maximize();
            basePage.GoToUrl(ConfigurationHelper.GetConfigurationByKey(Hooks.Config, "Url.BasePage"));
            Node = Test.CreateNode(TestContext.CurrentContext.Test.Name);
            TestContext.Progress.WriteLine("Base Test Setup");

        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) 
            ? "" 
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    var fileLocation = ScreenshotHelper.CaptureScreenshot(Driver!, TestContext.CurrentContext.Test.ClassName!, 
                    TestContext.CurrentContext.Test.Name);
                    var mediaEntity = ScreenshotHelper.CaptureScreenshotAndAttachToExtentReport(Driver!, TestContext.CurrentContext.Test.Name);

                    Node!.Fail("#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus + stacktrace + mediaEntity);
                    Node!.Fail("#Screenshot Below: }" +
                                Node.AddScreenCaptureFromPath(fileLocation));
                    break;

                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    Node!.Log(logstatus, "#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;

                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    Node!.Skip("#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;

                default:
                    logstatus = Status.Pass;
                    Node!.Log(logstatus, "#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;
            }

            Driver!.Quit();

            TestContext.Progress.WriteLine("Base Test Tear Down");

        }

        [OneTimeSetUp]

        public void OneTimeSetUp() {
            
        }

    }
}