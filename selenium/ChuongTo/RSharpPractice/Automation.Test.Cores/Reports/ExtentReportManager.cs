using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Automation.Test.Cores.Reports
{
    public class ExtentReportManager
    {
        private static readonly Lazy<ExtentReports> _lazyReport = new Lazy<ExtentReports>(() => new ExtentReports());

        public static ExtentReports Instance {get { return _lazyReport.Value; }}

        static ExtentReportManager() {
            string projectPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string reportPath = Path.Combine(projectPath, "TestResult"); //Automation.Tests/bin/Debug/net6.0/TestResult

            if(!Directory.Exists(reportPath)) {
                Directory.CreateDirectory(reportPath);
            }

            var htmlReporter = new ExtentHtmlReporter(reportPath + @"\index.html");
            htmlReporter.LoadConfig(projectPath + @"\ExtentReportConfig.xml");
            Instance.AttachReporter(htmlReporter);
        }

        public static void GenerateReport() {
            Instance.Flush();
        }
    }
}