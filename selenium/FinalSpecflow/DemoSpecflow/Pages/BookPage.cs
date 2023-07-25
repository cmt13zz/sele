using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSpecflow.Library;
using OpenQA.Selenium;

namespace DemoSpecflow.Pages
{
    public class BookPage : BasePage
    {
        private WebObject GitPocketLink = new WebObject(By.CssSelector(@"#see-book-Git\ Pocket\ Guide > a"), "Git Pocket Guide Link");
        
        private WebObject SearchBox = new WebObject(By.Id("searchBox"), "Search Input");
        private WebObject ListsOfBooks = new WebObject(By.CssSelector(".action-buttons > span > a"), "Lists of Books");
        public BookPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickGitPocketLink() {
            ClickElement(GitPocketLink);
        }

        public void InputSearchBox(string searchBox) {
            InputText(SearchBox, searchBox);
        }

        public int GetListOfBooks() {
            return FindMultipleElements(ListsOfBooks);
        }

       
    }
}