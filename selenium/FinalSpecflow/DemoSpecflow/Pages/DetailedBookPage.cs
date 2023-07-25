using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSpecflow.Library;
using OpenQA.Selenium;

namespace DemoSpecflow.Pages
{
    public class DetailedBookPage : BasePage
    {
        private WebObject btnAddToCollection = new WebObject(By.CssSelector(".fullButtonWrap > div:nth-child(2) > button"), "Add To Collection button");
        public DetailedBookPage(IWebDriver driver) : base(driver)
        {
        }

    }
}