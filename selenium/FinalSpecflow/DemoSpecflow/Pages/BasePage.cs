using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using DemoSpecflow.Library;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;
using DemoSpecflow.Steps;
using AventStack.ExtentReports;

namespace DemoSpecflow.Pages
{
    public class BasePage
    {
        public IWebDriver WebDriver;
        public WebDriverWait Wait;
        public BasePage(IWebDriver driver)
        {

            WebDriver = driver;
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(Int16.Parse(ConfigurationHelper.GetConfigurationByKey(Context.Config, "SeleniumTimeOutInSeconds"))));

        }

        public void GoToUrl(String url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }



        public void Navigate(String url)
        {
            WebDriver.Navigate().GoToUrl(ConfigurationHelper.GetConfigurationByKey(Context.Config, "BaseUrl") + url);
        }

        public void Maximize()
        {
            WebDriver.Manage().Window.Maximize();
        }

        //======================== Wait methods ===========================

        public IWebElement WaitForElementToBeClickable(WebObject webObject)
        {
            return Wait.Until(ExpectedConditions.ElementToBeClickable(webObject.By));
        }

        public IWebElement WaitForElementToBeVisible(WebObject webObject)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(webObject.By));
        }

        public bool IsElementDisplayed(WebObject webObject)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(webObject.By)).Displayed;
        }

        public bool IsElementExist(WebObject webObject)
        {
            return WebDriver.FindElements(webObject.By).Count > 0;
        }




        //========================= Interaction methods =======================

        public void InputText(WebObject webObject, string text)
        {
            TestContext.Progress.WriteLine($"Input Text: {webObject.Name}");
            var element = WaitForElementToBeVisible(webObject);
            element.Clear();
            element.SendKeys(text);
            Context.Node.Log(Status.Pass, $"Input Text: {webObject.Name}");

        }

        public void ClickElement(WebObject webObject)
        {
            TestContext.Progress.WriteLine($"Click on Element: {webObject.Name}");
            var element = WaitForElementToBeClickable(webObject);
            Context.Node.Log(Status.Pass, $"Click on Element: {webObject.Name}");
            element.Click();

        }

        public string GetText(WebObject webObject)
        {
            TestContext.Progress.WriteLine($"Get Text: {webObject.Name}");
            var element = WaitForElementToBeVisible(webObject);
            Context.Node.Log(Status.Pass, $"Get Text: {webObject.Name}");
            return element.Text;



        }

        public void UploadPicture(WebObject webObject)
        {
            TestContext.Progress.WriteLine($"Upload picture: {webObject.Name}");
            string path = Path.Combine(JsonHelper.GetProjectRootDirectory(), "TestData", ConfigurationHelper.GetConfigurationByKey(Context.Config, "Picture.File"));
            WebDriver.FindElement(webObject.By).SendKeys(path);
        }

        public void SelectOptionByText(WebObject webObject, string text)
        {
            TestContext.Progress.WriteLine($"Select Option: {webObject.Name}, By Text: {text}");
            var element = WaitForElementToBeVisible(webObject);
            Wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
            var select = new SelectElement(element);
            select.SelectByText(text);
            Context.Node.Log(Status.Pass, $"Select Option: {webObject.Name}, By Text: {text}");
        }

        public void ClickSubmitButtonJs()
        {
            var btnClickSubmit = "var btnSubmit = document.getElementById('submit'); btnSubmit.click()";
            WebDriver.ExecuteJavaScript(btnClickSubmit);
        }

        public void HideElement()
        {
            var ads = "var ad = document.getElementsByTagName('iframe')[0]; ad.style.display = 'none'";
            var footer = "document.querySelector('footer').style.display = 'none'";
            WebDriver.ExecuteJavaScript(ads);
            WebDriver.ExecuteJavaScript(footer);

        }

        public int FindMultipleElements(WebObject webObject)
        {
            var elements = WebDriver.FindElements(webObject.By);
            var count = elements.Count;
            foreach (var element in elements)
            {
                Console.WriteLine(element.Text);
            }

            return count;
        }





    }
}


