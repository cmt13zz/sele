using OpenQA.Selenium;
using DemoSpecflow.Library;


namespace DemoSpecflow.Pages
{
    public class LoginPage: BasePage
    {
         private WebObject _txtUserName = new WebObject(By.Id("username"), "UserName Textbox");
        private WebObject _txtPassword = new WebObject(By.Id("password"), "Password Textbox");
        private WebObject _btnLogin = new WebObject(By.CssSelector("form[name='loginForm'] input[type='submit']"), "Login Button");
        private WebObject _lblErrorMessage = new WebObject(By.CssSelector("form[name='loginForm'] div.alert"), "Error Message Label");
        private WebObject _lblUserNameRequiredMessage = new WebObject(By.CssSelector("#username ~ div p"), "UserName Required Message Label");
        private WebObject _lblPasswordRequiredMessage = new WebObject(By.CssSelector("#password ~ div p"), "Password Required Message Label");


        public LoginPage(IWebDriver driver): base(driver) {

        }

        public void InputUserName(string userName) {
            InputText(_txtUserName, userName);
        }

        public void InputPassword(string password) {
            InputText(_txtPassword, password);
        }

        public void ClickLoginBtn() {
            ClickElement(_btnLogin);
        }

        public string GetWrongPasswordMessage() {
            return GetText(_lblErrorMessage);
        } 

        public string GetUserNameRequiredMessage() {
            return GetText(_lblUserNameRequiredMessage);
        }

        public string GetPasswordRequiredMessage() {
            return GetText(_lblPasswordRequiredMessage);
        }
        public void LoginWithUsernameAndPassword(string userName, string password)
        {
            InputUserName(userName);
            InputPassword(password);
            ClickElement(_btnLogin);
        }

        public void LoginWithUsername(string userName)
        {
            InputUserName(userName);
            ClickElement(_btnLogin);
            
        }

        public void LoginWithPassword(string password)
        {
            InputPassword(password);
            ClickElement(_btnLogin);
        }




    }
}