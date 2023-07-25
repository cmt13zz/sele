using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;


using NUnitFinal.Pages;
using NUnitFinal.Tests;

namespace NUnitFinal.Pages
{
    public class BasePage
    {
         protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            double waitTime = Double.Parse(
                    ConfigurationHelper.GetConfigurationByKey(Hook.Config!,
                        "TimeOut.WebDriver"));
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
        }

        public void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        // Wait Element
        public IWebElement WaitForElementToBeVisible(WebObject webObject)
        {
            return Wait.Until(
                    ExpectedConditions.ElementIsVisible(webObject.By));
        }

        public IWebElement WaitForElementToBeClickable(WebObject webObject)
        {
            return Wait.Until(
                    ExpectedConditions.ElementToBeClickable(webObject.By));
        }

        public bool IsElementDisplayed(WebObject webObject)
        {
            return Wait.Until(
                    ExpectedConditions.ElementIsVisible(
                        webObject.By)).Displayed;
        }

        public bool IsElementExist(WebObject webObject)
        {
            return Driver.FindElements(webObject.By).Count > 0;
        }

        // Action on Element
        public void ClickOnElement(WebObject webObject)
        {
            TestContext.Progress.WriteLine($"Click on Element: {webObject.Name}");
            var element = WaitForElementToBeClickable(webObject);
            element.Click();
        }

        public void InputText(WebObject webObject, string text)
        {
            TestContext.Progress.WriteLine($"Input Text: {webObject.Name}");
            var element = WaitForElementToBeVisible(webObject);
            element.Clear();
            element.SendKeys(text);
        }

        public void SelectOptionByText(WebObject webObject, string text)
        {
            TestContext.Progress.WriteLine(
                    $"Select Option: {webObject.Name}, By Text: {text}");
            var element = WaitForElementToBeVisible(webObject);
            Wait.Until(ExpectedConditions.TextToBePresentInElement(element, text));
            var select = new SelectElement(element);
            select.SelectByText(text);
        }

        public string GetText(WebObject webObject)
        {
            TestContext.Progress.WriteLine($"Get Text: {webObject.Name}");
            var element = WaitForElementToBeVisible(webObject);
            return element.Text;
        }

    }
}