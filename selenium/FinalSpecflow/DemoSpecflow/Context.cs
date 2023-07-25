
using OpenQA.Selenium;
using AventStack.ExtentReports;
using TechTalk.SpecFlow;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using DemoSpecflow.Library;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using DemoSpecflow.API;
using DemoSpecflow.Services;

namespace DemoSpecflow
{
    [Binding]
    public class Context
    {
        public static IConfiguration Config;

        protected APIClient ApiClient;

        protected UserService UserService;
        protected BookService BookService;

        public static IWebDriver Webdriver;
        static string appSettingPath = "Configs\\appsettings.json";

        public static ExtentReports Extent;
        public static ExtentTest Test;
        public static ExtentTest Node;

       
        public Context() {
            ApiClient = new APIClient(ConfigurationHelper.GetConfigurationByKey(Config, "BaseUrl"));
            UserService = new UserService(ApiClient);
            BookService = new BookService(ApiClient);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            
            TestContext.Progress.WriteLine("Starting OneTimeSetUp");
            // Read Configuration file
            Config = ConfigurationHelper.ReadConfiguration(appSettingPath);

            // Init Extend report
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var actualPath = dir.Substring(0, dir.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            var reportPath = projectPath + ConfigurationHelper.GetConfigurationByKey(Config, "TestResult.Folder") +
            ConfigurationHelper.GetConfigurationByKey(Config, "TestResult.File");

            var htmlReporter = new ExtentHtmlReporter(reportPath);


            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
            Extent.AddSystemInfo("Host Name", "Demo Test");
            Extent.AddSystemInfo("Environment", "Test Environment");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            TestContext.Progress.WriteLine("Starting OneTimeTearDown");
            Extent.Flush();
        }

        [BeforeFeature]
         public static void InitTestForExtentReport() {
            Test = Extent.CreateTest(TestContext.CurrentContext.Test.ClassName);
         }

        [BeforeScenario]
        public static void Setup()
        {
            
            Webdriver = BrowserFactory.InitDriver(ConfigurationHelper.GetConfigurationByKey(Config, "Browser"));
            Webdriver.Manage().Window.Maximize();
            Node = Test.CreateNode(TestContext.CurrentContext.Test.Name);
            Console.WriteLine("Starting Setup");
            Webdriver.Navigate().GoToUrl(ConfigurationHelper.GetConfigurationByKey(Config, "BaseUrl"));
        }

        [AfterScenario]
        public static void TearDown()
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

                    Node.Fail("#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus + stacktrace);
                    break;

                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    Node.Log(logstatus, "#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;

                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    Node.Skip("#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;

                default:
                    logstatus = Status.Pass;
                    Node.Log(logstatus, "#Test Name: " + TestContext.CurrentContext.Test.Name + " #Status: " + logstatus);
                    break;
            }

            Webdriver.Quit();

            TestContext.Progress.WriteLine("Base Test Tear Down");

        }

    }
}
