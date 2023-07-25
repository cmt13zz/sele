using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using AventStack.ExtentReports;
using DemoUnitFW.Library;
using AventStack.ExtentReports.Reporter;


namespace DemoUnitFW.Tests
{
    [SetUpFixture]
    public class Hooks
    {
        public static ExtentReports Extent;
        public static IConfiguration Config;
        public static string ReportDir;
        const string appSettingPath = "Configs\\appsettings.json";

        [OneTimeSetUp]
        public void Setup()
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

        [OneTimeTearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("Starting OneTimeTearDown");
            Extent.Flush();
        }
    }

}