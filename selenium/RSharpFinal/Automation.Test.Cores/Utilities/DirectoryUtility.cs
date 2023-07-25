using System;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace Automation.Test.Cores.Utilities
{
    public class DirectoryUtility
    {
        public static void CreateIfNotExists(string path) {
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

        }

        public static string GetCurrentDirectoryPath() {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        
    }
}