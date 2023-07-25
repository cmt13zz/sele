using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automation.Test.Cores.Utilities;
using Microsoft.Extensions.Configuration;

namespace Automation.Test.Cores.Configurations
{
    public class ConfigurationManager
    {
        private static IConfigurationRoot _configurationRoot;

        public static void Init(string fileName = "appsetting.json") {
            _configurationRoot = new ConfigurationBuilder()
            .SetBasePath(DirectoryUtility.GetCurrentDirectoryPath())
            .AddJsonFile(fileName, true)
            .AddEnvironmentVariables()
            .Build();
        }

        public static IConfigurationRoot GetConfig() {
            return _configurationRoot;
        }

        public static T GetConfig<T>(string key) where T : class {
            return _configurationRoot.GetSection(key).Get<T>();
        }

        public static T GetValue<T>(string key) where T : class {
            return _configurationRoot.GetValue<T>(key);
        }
    }
}