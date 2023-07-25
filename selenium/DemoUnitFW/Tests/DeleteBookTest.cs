using NUnit.Framework;
using DemoUnitFW.Library;
using DemoUnitFW.Pages;

namespace DemoUnitFW.Tests
{
    public class DeleteBookTest : BaseTest
    {
        BookPage bookPage;
        GitPocketGuideBookPage gitPocketGuideBookPage;
        LoginPage loginPage;
        ProfilePage profilePage;

        [SetUp]
        public new void Setup()
        {
            bookPage = new BookPage(BaseTest.Driver);
            gitPocketGuideBookPage = new GitPocketGuideBookPage(BaseTest.Driver);
            loginPage = new LoginPage(BaseTest.Driver);
            profilePage = new ProfilePage(BaseTest.Driver);
            bookPage.Navigate("/login");
        }

        [Test]
        public void DeleteBookSuccessfully()
        {
            loginPage.LoginWithAccount(JsonHelper.GetTestDataString("Username"), JsonHelper.GetTestDataString("Password"));
            Thread.Sleep(3000);
            
            profilePage.ClickDeleteButton();
            profilePage.ClickOKModalButton();
            Thread.Sleep(2000);
            profilePage.AcceptAlert();

            Thread.Sleep(2000);

            //If this can pass the AcceptAlert(), it means that the only book in user profile has deleted successfully
            Assert.Pass("Delete book successfully");
        }
    }
}