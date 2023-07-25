using OpenQA.Selenium;
using DemoSpecflow.Library;
using DemoSpecflow.Pages;

namespace DemoSpecflow.Pages
{
    public class HomePage : BasePage
    {
        private WebObject _btnProjects = new WebObject(By.CssSelector(".nav:nth-child(1) li:nth-child(2) a.dropdown-toggle"), "Projects Button");
        private WebObject _btnCreateProject = new WebObject(By.CssSelector(".nav:nth-child(1) li:nth-child(2) li:nth-child(1) a"), "Create Project Button");
        private WebObject _btnSearchProject = new WebObject(By.CssSelector(".nav:nth-child(1) li:nth-child(2) li:nth-child(2) a"),"Create Project Button");
        private WebObject _btnUserName = new WebObject(By.CssSelector(".navbar-right a.dropdown-toggle"), "UserName Button");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnProjectsButton()
        {
            ClickElement(_btnProjects);
        }

        public void ClickOnCreateProjectButton()
        {
            ClickElement(_btnCreateProject);
        }

        public void ClickOnSearchProjectButton()
        {
            ClickElement(_btnSearchProject);
        }

        public string GetUserNameText()
        {
            return GetText(_btnUserName);
        }

    }
}