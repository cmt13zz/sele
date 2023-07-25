using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using DemoUnitFW.Library;
using DemoUnitFW.Tests;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;

namespace DemoUnitFW.Pages
{
    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public BasePage(IWebDriver driver) {

            this.driver = driver;
            double WaitTime = Double.Parse(ConfigurationHelper.GetConfigurationByKey(Hooks.Config!, "SeleniumTimeOutInSeconds")); 
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTime));
        }

        public void GoToUrl (String url) {
            driver.Navigate().GoToUrl(url);
        }

        

        public void Navigate (String url) {
            driver.Navigate().GoToUrl(ConfigurationHelper.GetConfigurationByKey(Hooks.Config!, "Url.BasePage") + url);
        }

         public void Maximize () {
            driver.Manage().Window.Maximize();
        }

        //======================== Wait methods ===========================

        public IWebElement WaitForElementToBeClickable(WebObject webObject) {
            return wait.Until(ExpectedConditions.ElementToBeClickable(webObject.By));
        }

         public IWebElement WaitForElementToBeVisible(WebObject webObject) {
            return wait.Until(ExpectedConditions.ElementIsVisible(webObject.By));
        }

         public bool IsElementDisplayed(WebObject webObject)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(webObject.By)).Displayed;
        }

        public bool IsElementExist(WebObject webObject)
        {
            return driver.FindElements(webObject.By).Count > 0;
        }

        


        //========================= Interaction methods =======================

        public void InputText(WebObject webObject, string text) {
            TestContext.Progress.WriteLine($"Input Text: {webObject.Name}");
            var element = WaitForElementToBeVisible(webObject);
            element.Clear();
            element.SendKeys(text);

        }

        public void ClickElement(WebObject webObject) {
            TestContext.Progress.WriteLine($"Click on Element: {webObject.Name}");
            var element = WaitForElementToBeClickable(webObject);
            element.Click();

        }

        public string GetText (WebObject webObject) {
            TestContext.Progress.WriteLine($"Get Text: {webObject.Name}");
            var element = WaitForElementToBeVisible(webObject);
            return element.Text;


        }

        public void UploadPicture(WebObject webObject) {
            TestContext.Progress.WriteLine($"Upload picture: jerry.png");
            string path = Path.Combine(JsonHelper.GetProjectRootDirectory(), "TestData", "jerry.png");
            driver.FindElement(webObject.By).SendKeys(path);
        }

        //=============Alert====================
        public void AcceptAlert() {
            var AlertAccepted = driver.SwitchTo().Alert();
            AlertAccepted.Accept();
        }

        //============Click button using JS========================
        public void ClickSubmitButtonJs() {
            var btnClickSubmit = "var btnSubmit = document.getElementById('submit'); btnSubmit.click()";
            driver.ExecuteJavaScript(btnClickSubmit);
        }

        public void ClickAddToCollectionJs() {
            var btnAddToCollection = "var btnAdd = document.querySelector('.fullButtonWrap > div:nth-child(2) > button'); btnAdd.click()";
            driver.ExecuteJavaScript(btnAddToCollection);
        }


    }
}

    
