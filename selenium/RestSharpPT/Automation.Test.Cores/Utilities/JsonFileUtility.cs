using System;
using System.IO;
using Newtonsoft.Json;

namespace Automation.Test.Cores.Utilities
{
    public class JsonFileUtility
    {
        public static string ReadJsonFile(string path) {
            if (!Directory.Exists(path)) {
                path = Path.Combine(DirectoryUtility.GetCurrentDirectoryPath(), path);

                if (!File.Exists(path)) {
                    throw new Exception ("Cannot find file " + path);
                }
            }

            return File.ReadAllText(path);
        }

        public static T ReadAndParse<T>(string path) where T : class {
            var jsonContent = ReadJsonFile(path);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}