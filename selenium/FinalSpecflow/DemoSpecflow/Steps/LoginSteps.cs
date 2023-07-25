
using DemoSpecflow.Library;
using DemoSpecflow.Pages;
using DemoSpecflow.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DemoSpecflow.Steps
{
    [Binding]
    public class LoginSteps : Context
    {
        LoginPage _loginPage = new LoginPage(Context.Webdriver);
        ProfilePage _profilePage = new ProfilePage(Context.Webdriver);



        [When(@"I navigate to the Login Page")]
        public void GivenINavigateToTheLoginPage()
        {
            _loginPage.Navigate("/login");
        }

        [When(@"I login with valid username ""(.*)"" and password ""(.*)""")]
        public void GivenILoginWithValidUsernameAndPassword(string username, string password)
        {
            _loginPage.LoginWithUsernameAndPassword(username, password);
            _profilePage.WaitForProfilePageToLoad();
        }
    }
}