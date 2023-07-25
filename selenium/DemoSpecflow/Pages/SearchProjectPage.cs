using DemoSpecflow.Library;
using OpenQA.Selenium;

namespace DemoSpecflow.Pages
{
    public class SearchProjectPage : BasePage
    {
        private WebObject _txtProjectName = new WebObject(By.CssSelector("#searchProject input[ng-model='input.projectname']"), "Project Name Textbox");
        private WebObject _ddlLocation = new WebObject(By.Id("ddl-location"), "Location Dropdown List");
        private WebObject _ddlProjectType = new WebObject(By.Id("ddl-projecttype"), "Project Type Dropdown List");
        private WebObject _btnSearchButton = new WebObject(By.CssSelector("#searchProject button[class*='search']"), "Search Button");
        private WebObject _lblProjectName = new WebObject(By.CssSelector("div[ui-view='projectsresult'] #tbl-results tbody tr:nth-child(1) > td:nth-child(1)"), "Project Name Label");

        private WebObject _lblProjectType = new WebObject(By.CssSelector("div[ui-view='projectsresult'] #tbl-results tbody tr:nth-child(1) > td:nth-child(3)"), "Project Type Label");
        private WebObject _lblLocation = new WebObject(By.CssSelector("div[ui-view='projectsresult'] #tbl-results tbody tr:nth-child(1) > td:nth-child(6)"), "Location Label");

        public SearchProjectPage(IWebDriver driver) : base(driver)
        {
        }

        public void InputProjectName(string projectName)
        {
            InputText(_txtProjectName, projectName);
        }

        public void SelectLocationDropdownListByText(string text)
        {
            SelectOptionByText(_ddlLocation, text);
        }

        public void SelectProjectTypeDropdownListByText(string text)
        {
            SelectOptionByText(_ddlProjectType, text);
        }

        public void ClickOnSearchButton()
        {
            ClickElement(_btnSearchButton);
        }

        public string GetProjectNameLabel()
        {
            return GetText(_lblProjectName);
        }

        public string GetProjectTypeLabel()
        {
            return GetText(_lblProjectType);
        }

        public string GetLocationLabel()
        {
            return GetText(_lblLocation);
        }

        

    }
}