using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.IO;


using NUnitFinal.Library;


namespace BinhTran.Test
{
    [SetUpFixture]
    class Hook
    {
        public static ExtentReports? Extent { get; private set; }
        public static IConfiguration? Config { get; private set; }
        public static string? ReportDir { get; private set; }
        private static readonly string _appSettingPath =
            Path.Combine("Configuration", "appsettings.json");

        [OneTimeSetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("============>Global OneTimeSetUp");

            // Read Configuration file
            Config = ConfigurationHelper.ReadConfiguration(_appSettingPath);

            // Init Extend report
            string dir = TestContext.CurrentContext.TestDirectory;
            string actualPath = dir.Substring(0, dir.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            ReportDir = Path.Combine(projectPath,
                    ConfigurationHelper.GetConfigurationByKey(Config,
                        "TestResult.Folder"));
            string reportPath = Path.Combine(ReportDir,
                    ConfigurationHelper.GetConfigurationByKey(Config,
                        "TestResult.File"));

            var htmlReporter = new ExtentHtmlReporter(reportPath);

            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
            Extent.AddSystemInfo("Host Name", "Demo Test");
            Extent.AddSystemInfo("Environment", "Test Environment");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            TestContext.Progress.WriteLine("Global OneTimeTearDown");
            Extent!.Flush();
        }
    }
}
