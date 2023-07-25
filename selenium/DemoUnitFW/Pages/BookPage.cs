using OpenQA.Selenium;
using DemoUnitFW.Library;

namespace DemoUnitFW.Pages
{
    public class BookPage : BasePage
    {

        private WebObject GitPocketLink = new WebObject(By.CssSelector(@"#see-book-Git\ Pocket\ Guide > a"), "Git Pocket Guide Link");
        private WebObject SearchBox = new WebObject(By.Id("searchBox"), "Search Input");
        private WebObject DesignPatternBook = new WebObject(By.CssSelector(@"#see-book-Learning\ JavaScript\ Design\ Patterns > a"),
        "Design Pattern Book");
        private WebObject DesigningEvovlableBook = new WebObject(By.CssSelector(@"#see-book-Designing\ Evolvable\ Web\ APIs\ with\ ASP\.NET > a"),
        "Designing Evolvable API.NET Book");
        public BookPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickGitPocketLink() {
            ClickElement(GitPocketLink);
        }

        public void InputSearchBox(string searchBox) {
            InputText(SearchBox, searchBox);
        }

        public string GetTextDesignPatternBook() {
            return GetText(DesignPatternBook);
        }

        public string GetTextDesigningEvolvableBook() {
            return GetText(DesigningEvovlableBook);
        }
    }
}