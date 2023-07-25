using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Automation.Test.Cores.Configurations;
using Automation.Test.Cores.Reports;
using Automation.Test.Cores.ShareData;

namespace Automation.Tests
{
    [SetUpFixture]
    public class TestStartup
    {
        [OneTimeSetUp]
        public void OneTimeStartUp()
        {
            ConfigurationManager.Init();

            DataStorage.InitData();
        }

        [OneTimeTearDown]
        public void TestEnd()
        {
            ExtentReportManager.GenerateReport();
        }
    }
}