using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSpecflow.Library;
using DemoSpecflow.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace DemoSpecflow.Steps
{
    [Binding]
    public class SearchBookSteps
    {

        LoginPage _loginPage = new LoginPage(Context.Webdriver);
        BookPage _bookPage = new BookPage(Context.Webdriver);


        [Given(@"I navigate to the Book Page")]
        public void GivenINavigateToTheBookPage()
        {
            _loginPage.Navigate("/books");
        }

        [When(@"I input a keyword ""(.*)"" in the search box")]
        public void WhenISearchForABookWithTheTitle(string BookName)
        {
            _bookPage.InputSearchBox(BookName);
        }

        [Then(@"I see the correct amount of books ""(.*)"" results that contain the keyword ""(.*)""")]
        public void ThenISeeTheBookWithTheBookNameInTheSearchResult(int count, string BookName)
        {
            Assert.That(_bookPage.GetListOfBooks, Is.EqualTo(count));

        }

        

        

    }
}