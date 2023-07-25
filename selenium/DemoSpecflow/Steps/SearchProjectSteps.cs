using DemoSpecflow.Library;
using TechTalk.SpecFlow;
using DemoSpecflow.Pages;
using NUnit.Framework;

namespace DemoSpecflow.Steps
{
    [Binding]
    public class SearchProjectSteps
    {
        LoginPage _loginPage = new LoginPage(Context.Webdriver);
        HomePage _homePage = new HomePage(Context.Webdriver);
        SearchProjectPage _searchProjectPage = new SearchProjectPage(Context.Webdriver);

        [Given(@"I login as admin")]
        public void GivenILoginAsAdmin()
        {
            _homePage.GoToUrl(ConfigurationHelper.GetConfigurationByKey(Context.Config, "BaseUrl"));
            _homePage.Navigate("/#!/login");
            _loginPage.LoginWithUsernameAndPassword(ConfigurationHelper.GetConfigurationByKey(Context.Config, "DefaultUsername"), ConfigurationHelper.GetConfigurationByKey(Context.Config, "DefaultPassword"));
        }

        [Given(@"I click on the Projects dropdown menu")]
        public void GivenIClickOnProjectsDropdownMenu()
        {
            _homePage.ClickOnProjectsButton();
        }

        [Given(@"I click on Search Project button")]
        public void GivenIClickOnSearchProjectButton()
        {
            _homePage.ClickOnSearchProjectButton();
        }

        [When(@"I fill all three ""(.*)"", ""(.*)"" and ""(.*)"" fields")]
        public void WhenIFillProjectNameLocationAndProjectTypeFields(string ProjectName, string Location, string ProjectType)
        {
            _searchProjectPage.InputProjectName(ProjectName);
            _searchProjectPage.SelectLocationDropdownListByText(Location);
            _searchProjectPage.SelectProjectTypeDropdownListByText(ProjectType);
        }

        [When(@"I fill ProjectName ""(.*)"" field")]
        public void WhenIFillProjectNameFields(string ProjectName)
        {
            _searchProjectPage.InputProjectName(ProjectName);
        }

        [When(@"I fill Location ""(.*)"" field")]
        public void WhenIFillLocationFields(string Location)
        {
            _searchProjectPage.SelectLocationDropdownListByText(Location);
        }

        [When(@"I fill ProjectType ""(.*)"" field")]
        public void WhenIFillProjectTypeFields(string ProjectType)
        {
            _searchProjectPage.SelectProjectTypeDropdownListByText(ProjectType);
        }

        [When(@"I click on Search button")] 
        public void WhenIClickOnSearchButton()
        {
            _searchProjectPage.ClickOnSearchButton();
        }

        [Then(@"I should see the result of all three ""(.*)"", ""(.*)"" and ""(.*)"" match the one in the result table")]
        public void ThenIShouldSeeTheProjectInTheResultTable(string ProjectName, string Location, string ProjectType)
        {
            Assert.That(_searchProjectPage.GetProjectNameLabel().ToLower().Contains(ProjectName));
            Assert.That(_searchProjectPage.GetLocationLabel(), Is.EqualTo(Location));
            Assert.That(_searchProjectPage.GetProjectTypeLabel(), Is.EqualTo(ProjectType));
        }

        [Then(@"I should see the ""(.*)"" contain in project name in the result table")]
        public void ThenIShouldSeeTheResultContainProjectNameInTheResultTable(string ProjectName)
        {
            Assert.That(_searchProjectPage.GetProjectNameLabel().ToLower().Contains(ProjectName));
        }

        [Then(@"I should see the ""(.*)"" have same location in the result table")]
        public void ThenIShouldSeeTheResultHaveSameLocationInTheResultTable(string Location)
        {
            Assert.That(_searchProjectPage.GetLocationLabel(), Is.EqualTo(Location));
        }

        [Then(@"I should see the ""(.*)"" have same project type in the result table")]
        public void ThenIShouldSeeTheResultHaveSameProjectTypeInTheResultTable(string ProjectType)
        {
            Assert.That(_searchProjectPage.GetProjectTypeLabel(), Is.EqualTo(ProjectType));
        }


        
    }
}