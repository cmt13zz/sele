
using DemoSpecflow.Library;
using DemoSpecflow.Pages;
using DemoSpecflow.Services;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace DemoSpecflow.Steps
{
    [Binding]
    public class AddBookSteps : Context
    {


        LoginPage _loginPage = new LoginPage(Context.Webdriver);
        ProfilePage _profilePage = new ProfilePage(Context.Webdriver);


        [Given(@"I delete all books from my collection using API")]
        public async Task GivenIDeleteAllBooksFromMyCollection(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            var token = await UserService.GenerateTokenAsync(dictionary["username"], dictionary["password"]);
            var response = await BookService.DeleteAllBooksAsync(token.Data.Token, dictionary["userId"]);
            
            
        }


        [When(@"I add a book using API")]
        public async Task GivenIAddABookWithISBNAndUserIdUsingAPI(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            var token = await UserService.GenerateTokenAsync(dictionary["username"], dictionary["password"]); //small mistake, waiting to figure out
            var response = await BookService.AddBookAsync(token.Data.Token, dictionary["userId"], dictionary["isbn"]);
        }

        
        

        [When(@"I navigate to the Profile Page")]
        public void GivenINavigateToTheProfilePage()
        {
            _loginPage.Navigate("/profile");
            
        }

        [Then(@"I see the book with the book name ""(.*)"" in my collection")]
        public void ThenISeeTheBookWithBookNameInMyCollection(string BookName)
        {
            
            Assert.That(_profilePage.GetBookName(), Is.EqualTo(BookName));
        }








    }
}