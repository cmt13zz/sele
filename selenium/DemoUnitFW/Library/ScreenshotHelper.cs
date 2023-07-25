using OpenQA.Selenium;
using AventStack.ExtentReports;
using System.Text.RegularExpressions;
using DemoUnitFW.Tests;

namespace DemoUnitFW.Library
{
    public class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver,
                string className,
                string testName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot) driver;
            var screenshot = takesScreenshot.GetScreenshot();
            string screenshotFolder = ConfigurationHelper.GetConfigurationByKey(Hooks.Config!, "Screenshot.Folder");
            string screenshotDirectory = Path.Combine(Hooks.ReportDir!, screenshotFolder);
            testName = Regex.Replace(testName, "(.*)", "");

            string fileName = string.Format(@"Screenshot_{0}_{1}.png",
                    className + testName,
                    DateTime.Now.ToString("yyyyMMdd_HHmmssff"));

            Directory.CreateDirectory(screenshotDirectory);
            string fileLocation = Path.Combine(screenshotDirectory, fileName);
            screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);

            return Path.Combine(screenshotFolder, fileName);
        }

        public static MediaEntityModelProvider CaptureScreenshotAndAttachToExtentReport(IWebDriver driver,
                string screenshotName)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            string screenshot = takesScreenshot.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
        }

    }
}