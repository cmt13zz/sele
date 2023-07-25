using OpenQA.Selenium;
using DemoSpecflow.Library;


namespace DemoSpecflow.Pages
{
    public class LoginPage: BasePage
    {
        private WebObject _txtUserName = new WebObject(By.Id("userName"), "UserName Textbox");
        private WebObject _txtPassword = new WebObject(By.Id("password"), "Password Textbox");
        private WebObject _btnLogin = new WebObject(By.Id("login"), "Login Button");
       

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