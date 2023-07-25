using NUnit.Framework;
using DemoUnitFW.Library;
using DemoUnitFW.Pages;


namespace DemoUnitFW.Tests
{
    public class SearchBookTest : BaseTest 
    {
        BookPage bookPage;


        [SetUp]
        public new void Setup()
        {
            bookPage = new BookPage(BaseTest.Driver);
            bookPage.Navigate("/books");
        }

        [Test]
        public void SearchDesignBook()
        {
            bookPage.InputSearchBox(JsonHelper.GetTestDataString("SearchBoxdesign"));
            Thread.Sleep(1000);
            string DesignPatternBook = bookPage.GetTextDesignPatternBook();
            string DesigningEvovlableBook = bookPage.GetTextDesigningEvolvableBook();
            Boolean result = DesignPatternBook.Equals(JsonHelper.GetTestDataString("book1"))
            && DesigningEvovlableBook.Equals(JsonHelper.GetTestDataString("book2"));
            Assert.That(result, Is.True, "Search books successfully");
        }
    }
}