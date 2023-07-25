using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSpecflow.Library;
using OpenQA.Selenium;

namespace DemoSpecflow.Pages
{
    public class ProfilePage : BasePage
    {
        private WebObject usernameValue = new WebObject(By.Id("userName-value"), "Username Value");
        private WebObject GitPocketBook = new WebObject(By.CssSelector(@"Git\ Pocket\ Guide > a"), "Git Pocket Guide Book");    
        private WebObject GitPocketLink = new WebObject(By.CssSelector(@"#see-book-Git\ Pocket\ Guide > a"), "Git Pocket Guide Link");
        private WebObject btnDelete = new WebObject(By.Id("delete-record-undefined"), "Delete button");
        private WebObject btnOKModal = new WebObject(By.Id("closeSmallModal-ok"), "OK Modal button");

        private WebObject btnLogout = new WebObject(By.Id("submit"), "Logout button");
        public ProfilePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetUsernameValue() {
            return GetText(usernameValue);
        }

        public string GetBookName() {
            return GetText(GitPocketLink);
        }

        public void ClickDeleteButton() {
            ClickElement(btnDelete);
        }

        public void ClickOKModalButton() {
            ClickElement(btnOKModal);
        }

        public void ClickLogoutButton() {
            ClickElement(btnLogout);
        }

        public bool IsBookExist() {
            return IsElementExist(GitPocketBook);
        }

        public void WaitForProfilePageToLoad() {
            WaitForElementToBeVisible(usernameValue);
        }

        
    }
}