using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Automation.Test.Cores.API;
using Automation.Services.Services;
using Automation.Test.Cores.Configurations;
using Automation.Test.Cores.Extensions;
using Automation.Test.Cores.ShareData;
using Automation.Services.Models;
using Automation.Test.Cores.Reports;
using AventStack.ExtentReports;
using Newtonsoft.Json;

namespace Automation.Tests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]

    public class BaseTest
    {
        

        protected APIClient ApiClient;

        protected UserService UserService;
        protected BookService BookService;

        public BaseTest()
        {

            ApiClient = new APIClient(ConfigurationManager.GetConfig()["application:url"]);

            UserService = new UserService(ApiClient);
            BookService = new BookService(ApiClient);

            ExtentTestManager.CreateParentTest(TestContext.CurrentContext.Test.Name);
        }

        [SetUp]
        public void BeforeTest()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {

            UpdateTestReport();
            DataStorage.ClearData();

        }

        public void UpdateTestReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    ExtentTestManager.GetTest().Log(Status.Fail, "Message: " + TestContext.CurrentContext.Result.Message);
                    break;

                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;

                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;

                default:
                    logstatus = Status.Pass;
                    break;

            }

            ExtentTestManager.GetTest().Log(logstatus, "Test ended with " + logstatus + stackTrace);
        }

        
    }
}