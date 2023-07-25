using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Automation.Test.Cores.Configurations;
using Automation.Test.Cores.Reports;
using Automation.Test.Cores.ShareData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(), 
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        [OneTimeTearDown]
        public void TestEnd()
        {
            ExtentReportManager.GenerateReport();
        }
    }
}