using Newtonsoft.Json.Linq;

namespace DemoSpecflow.Library

{

    public class JsonHelper

    {

        public static string GetProjectRootDirectory() {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }

        private static JObject GetTestDataJsonObject() {
            string path = Path.Combine(GetProjectRootDirectory(), "TestData", "TestData.json");
            JObject jObject = JObject.Parse(File.ReadAllText(path));
            return jObject;
        }

        public static int GetTestDataInt(string label) {
            var jObject = GetTestDataJsonObject();
            return Int32.Parse(jObject[label].ToString());
        }

        public static string GetTestDataString(string label) {
            var jObject = GetTestDataJsonObject();
            return jObject[label].ToString();
        }

        public static List<string> GetTestDataArray(string label) {
            var jObject = GetTestDataJsonObject();
            return jObject[label].ToObject<List<string>>(); ;
        }

    }

}