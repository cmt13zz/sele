
using DemoUnitFW.Library;
using OpenQA.Selenium;

namespace DemoUnitFW.Pages
{
    public class ProfilePage : BasePage
    {
        private WebObject usernameValue = new WebObject(By.Id("userName-value"), "Username Value");

        private WebObject GitPocketBook = new WebObject(By.CssSelector(@"#see-book-Git\ Pocket\ Guide > a"), "Git Pocket Guide Link");
        private WebObject btnDelete = new WebObject(By.Id("delete-record-undefined"), "Delete button");
        private WebObject btnOKModal = new WebObject(By.Id("closeSmallModal-ok"), "OK Modal button");
        public ProfilePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetUsernameValue() {
            return GetText(usernameValue);
        }

        public string GetBookName() {
            return GetText(GitPocketBook);
        }

        public void ClickDeleteButton() {
            ClickElement(btnDelete);
        }

        public void ClickOKModalButton() {
            ClickElement(btnOKModal);
        }
    }
}