using OpenQA.Selenium;
using DemoUnitFW.Library;
using DemoUnitFW.Tests;
using NUnit.Framework;

namespace DemoUnitFW.Pages
{
    public class LoginPage: BasePage
    {
        private WebObject txtUserName = new WebObject(By.Id("userName"), "userName Textbox");
        private WebObject txtPassword = new WebObject(By.Id("password"), "Password Textbox");

        private WebObject btnLogin = new WebObject(By.Id("login"), "Login Button");
        private WebObject txtWrongPassword = new WebObject(By.Id("name"), "Wrong password message");

        

        public LoginPage(IWebDriver driver): base(driver) {

        }

        public void InputUserName(string userName) {
            InputText(txtUserName, userName);
        }

        public void InputPassword(string password) {
            InputText(txtPassword, password);
        }

        public void ClickLoginBtn() {
            ClickElement(btnLogin);
        }

        public string GetWrongPasswordMessage() {
            return GetText(txtWrongPassword);
        } 

        public void LoginWithAccount(string userName, string password)
        {
            InputUserName(userName);
            InputPassword(password);
            ClickElement(btnLogin);
        }


    }
}