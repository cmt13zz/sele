using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;



namespace SeleniumDocs.Hello
{
    public class LoginTestCase
    {
        public static void Main()
        {
            var driver = new ChromeDriver();
            
            //Open TMS Login Page
            driver.Navigate().GoToUrl("http://192.168.237.10:3000/");

            //Enter username and password
            driver.FindElement(By.Id("username")).SendKeys("admin2");
            driver.FindElement(By.Id("password")).SendKeys("fdfddvd");


            
        }
    }
}