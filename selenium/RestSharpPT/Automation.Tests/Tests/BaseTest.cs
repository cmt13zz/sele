using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestSharp;
using RestSharp.Serializers;
using Automation.Test.Cores.API;
using Automation.Services.Services;

namespace Automation.Tests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.Fixtures)]

    public class BaseTest
    {
        protected Dictionary<string, AccountDto> _accountData;

        protected Dictionary<string, string> _tokenData;

        protected APIClient _apiClient;

        protected UserService _userService;

        public BaseTest() {
            _accountData = JsonFileUtility.ReadAndParse<Dictionary<string, AccountDto>>(FileConstant.AccountFilePath.GetAbsolutePath());
            _tokenData = new Dictionary<string, string>();
            _apiClient = new APIClient(ConfigurationManager.GetConfig()["application:url"]);
            _userService = new UserService(_apiClient);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}