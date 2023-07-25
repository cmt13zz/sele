using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSpecflow.Library;
using DemoSpecflow.Pages;
using DemoSpecflow.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DemoSpecflow.Steps
{
    public class DeleteBookSteps : Context
    {

        LoginPage _loginPage = new LoginPage(Context.Webdriver);
        ProfilePage _profilePage = new ProfilePage(Context.Webdriver);

        [Given(@"I add the book to my collection using API if it is not")]
        public async Task GivenAddTheBookWithISBNToMyCollectionUsingAPIIfItIsNot(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            var token = await UserService.GenerateTokenAsync(dictionary["username"], dictionary["password"]);
            var response = await BookService.AddBookAsync(token.Data.Token, dictionary["userId"], dictionary["isbn"]);
        }


        [Given(@"I navigate to the Profile Page")]
        public void GivenINavigateToTheProfilePage()
        {
            _loginPage.Navigate("/profile");
        }

        [Given(@"I see the book with the book name ""(.*)"" is in my collection")]
        public void GivenISeeTheBookWithTheBookNameIsInMyCollection(string bookName)
        {
            Assert.That(_profilePage.GetBookName, Is.EqualTo(bookName));
        }

        [When(@"I delete the book from my collection using API")]
        public async Task WhenIDeleteTheBookFromMyCollectionUsingAPI(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            var token = await UserService.GenerateTokenAsync(dictionary["username"], dictionary["password"]);
            var response = await BookService.DeleteBookAsync(token.Data.Token, dictionary["isbn"], dictionary["userId"]);

        }

        [Given(@"I navigate to the Login Page")]
        public void GivenINavigateToTheLoginPage()
        {
            _loginPage.Navigate("/login");
        }

        [Given(@"I login with valid username ""(.*)"" and password ""(.*)""")]
        public void GivenILoginWithValidUsernameAndPassword(string username, string password)
        {
            _loginPage.LoginWithUsernameAndPassword(username, password);
            _profilePage.WaitForProfilePageToLoad();
        }

        [When(@"I click on Logout button")]
        public void WhenIClickOnLogoutButton()
        {
            _profilePage.ClickLogoutButton();
        }

        [Then(@"I see the book is deleted from my collection")]
        public void ThenISeeTheBookWithTheBookNameIsNotInMyCollection()
        {
            Assert.That(_profilePage.IsBookExist, Is.False);
        }
    }
}