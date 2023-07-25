using Microsoft.Extensions.Configuration;



namespace DemoSpecflow.Library
{
    public class ConfigurationHelper
    {
        public static IConfiguration ReadConfiguration(string path)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path)
                .Build();
            return config;
        }

        public static string GetConfigurationByKey(IConfiguration config, string key)
        {
            var value = config[key];
            if (!string.IsNullOrEmpty(value)) return value;
            var message
                = $"Attribute [{key}] has not been set in AppSettings.";
            throw new InvalidDataException(message);
        }

    }
}