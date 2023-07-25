
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using DemoUnitFW.Pages;
using DemoUnitFW.Library;



namespace DemoUnitFW.Tests
{
    public class LoginTest: BaseTest
    {
        LoginPage loginPage;
        ProfilePage profilePage;
        
        [SetUp]
        public new void Setup()
        {

            loginPage = new LoginPage(BaseTest.Driver);
            profilePage = new ProfilePage(BaseTest.Driver);

            loginPage.Navigate("/login");
        }

        [Test]
        public void LoginSuccessfullyWithValidAccount() {
            loginPage.InputUserName(ConfigurationHelper.GetConfigurationByKey(Hooks.Config!, "DefaultUsername"));
            loginPage.InputPassword(ConfigurationHelper.GetConfigurationByKey(Hooks.Config!, "DefaultPassword"));
            loginPage.ClickLoginBtn();
            string usernameValue = profilePage.GetUsernameValue();
            Assert.That(usernameValue, Is.EqualTo(ConfigurationHelper.GetConfigurationByKey(Hooks.Config!, "DefaultUsername")), "Login successfully with valid username");

        }


        
    }
}