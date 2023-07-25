using NUnit.Framework;
using DemoUnitFW.Library;
using DemoUnitFW.Pages;


namespace DemoUnitFW.Tests
{
    public class AddBookTest: BaseTest
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
        public void AddNewBookSuccessfully()
        {
            
            loginPage.LoginWithAccount(JsonHelper.GetTestDataString("Username"), JsonHelper.GetTestDataString("Password"));
            Thread.Sleep(2000);
            bookPage.Navigate("/books");
            bookPage.ClickGitPocketLink();
            gitPocketGuideBookPage.ClickAddToCollection();
            Thread.Sleep(2000);
            gitPocketGuideBookPage.AcceptAlert();
            Thread.Sleep(2000);
            bookPage.Navigate("/profile");
            string BookName = profilePage.GetBookName();
            Assert.That(BookName, Is.EqualTo(JsonHelper.GetTestDataString("BookName")), "Add new Book Successfully");


        }
    }
}