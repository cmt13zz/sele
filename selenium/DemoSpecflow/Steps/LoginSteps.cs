using DemoSpecflow.Library;
using TechTalk.SpecFlow;
using DemoSpecflow.Pages;
using NUnit.Framework;

namespace DemoSpecflow.Steps
{
    [Binding]
    public class LoginSteps
    {

        
        LoginPage _loginPage = new LoginPage(Context.Webdriver);
        HomePage _homePage = new HomePage(Context.Webdriver);

        [Given(@"I open the Homepage")]
        public void GivenIOpenTheHomepage()
        {
            _homePage.GoToUrl(ConfigurationHelper.GetConfigurationByKey(Context.Config, "BaseUrl"));
        }

        [Given(@"I navigate to Login page")]
        public void GivenINavigateToLoginPage()
        {
            _homePage.Navigate("/#!/login");
        }

        [When(@"I click on Login button")]
        public void WhenIClickOnLoginButton()
        {
            _loginPage.ClickLoginBtn();
        }

        [When(@"I login with username ""(.*)""")]
        public void WhenILoginWithUsername(string username)
        {
            _loginPage.LoginWithUsername(username);
        }

        [When(@"I login with password ""(.*)""")]
        public void WhenILoginWithPassword(string password)
        {
            _loginPage.LoginWithPassword(password);
        }


        [When (@"I login with ""(.*)"" and ""(.*)""")]
        public void WhenILoginWithAnd(string username, string password)
        {
            _loginPage.LoginWithUsernameAndPassword(username, password);
        }

        [Then (@"I login successfully")]
        public void ThenILoginSuccessfully()
        {
            Assert.That(_homePage.GetUserNameText(), Is.EqualTo(ConfigurationHelper.GetConfigurationByKey(Context.Config, "DefaultUsername")));
        }

        [Then(@"The error message ""(.*)"" should be displayed when I enter invalid username and password")]
        public void ThenTheErrorMessageShouldBeDisplayedWhenIEnterInvalidUsernameAndPassword(string message)
        {
            Assert.That(_loginPage.GetWrongPasswordMessage(), Is.EqualTo(message));
        }

        [Then(@"The error message ""(.*)"" should be displayed when I leave username empty")]
        public void ThenTheErrorMessageShouldBeDisplayedWhenIEnterEmptyUsername(string message)
        {
            Assert.That(_loginPage.GetUserNameRequiredMessage(), Is.EqualTo(message));
        }

        [Then(@"The error message ""(.*)"" should be displayed when I leave password empty")]
        public void ThenTheErrorMessageShouldBeDisplayedWhenIEnterEmptyPassword(string message)
        {
            Assert.That(_loginPage.GetPasswordRequiredMessage(), Is.EqualTo(message));
        }

        [Then(@"The error message ""(.*)"" should be displayed when I leave username and password empty")]
        public void ThenTheErrorMessageShouldBeDisplayedWhenIEnterEmptyUsernameAndPassword(string message)
        {
            Assert.That(_loginPage.GetUserNameRequiredMessage(), Is.EqualTo(message));
            Assert.That(_loginPage.GetPasswordRequiredMessage(), Is.EqualTo(message));
        }


    }
}