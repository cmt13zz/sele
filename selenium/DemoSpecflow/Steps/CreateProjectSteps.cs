using DemoSpecflow.Library;
using TechTalk.SpecFlow;
using DemoSpecflow.Pages;
using NUnit.Framework;


namespace DemoSpecflow.Steps
{
    [Binding]
    public class CreateProjectSteps
    {
        LoginPage _loginPage = new LoginPage(Context.Webdriver);
        HomePage _homePage = new HomePage(Context.Webdriver);
        DetailedProjectPage _detailedProjectPage = new DetailedProjectPage(Context.Webdriver);
        CreateProjectPopUp _createProjectPopUp = new CreateProjectPopUp(Context.Webdriver);

        [Given(@"I login as an admin")]
        public void GivenILoginAsAdmin()
        {
            _homePage.GoToUrl(ConfigurationHelper.GetConfigurationByKey(Context.Config, "BaseUrl"));
            _homePage.Navigate("/#!/login");
            _loginPage.LoginWithUsernameAndPassword(ConfigurationHelper.GetConfigurationByKey(Context.Config, "DefaultUsername"), ConfigurationHelper.GetConfigurationByKey(Context.Config, "DefaultPassword"));
        }

        [Given(@"I click on Projects dropdown menu")]
        public void GivenIClickOnProjectsDropdownMenu()
        {
            _homePage.ClickOnProjectsButton();
        }

        [Given(@"I click on Create Project button")]
        public void GivenIClickOnCreateProjectButton()
        {
            _homePage.ClickOnCreateProjectButton();
        }

        [When(@"I create new project with info below")]
        public void GivenIFillInTheFollowingFields(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            _createProjectPopUp.InputProjectName(dictionary["ProjectName"]);
            _createProjectPopUp.SelectProjectTypeDrodownListByText(dictionary["ProjectType"]);
            _createProjectPopUp.SelectProjectStatusDrodownListByText(dictionary["ProjectStatus"]);
            _createProjectPopUp.InputSize(dictionary["Size"]);
            _createProjectPopUp.SelectLocationDrodownListByText(dictionary["Location"]);
            _createProjectPopUp.SelectProjectManagerDrodownListByText(dictionary["ProjectManager"]);
            _createProjectPopUp.SelectDeliveryManagerDrodownListByText(dictionary["DeliveryManager"]);
            _createProjectPopUp.SelectEngagementManagerDrodownListByText(dictionary["EngagementManager"]);
            _createProjectPopUp.InputShortDescription(dictionary["ShortDescription"]);
            _createProjectPopUp.InputLongDescription(dictionary["LongDescription"]);
            _createProjectPopUp.InputTechnologies(dictionary["Technologies"]);
            _createProjectPopUp.InputClientName(dictionary["ClientName"]);
            _createProjectPopUp.SelectClientIndustryDrodownListByText(dictionary["ClientIndustry"]);
            _createProjectPopUp.InputClientDescription(dictionary["ClientDescription"]);

        }

        [When(@"I click on Create button")]
        public void GivenIClickOnCreateButton()
        {
            _createProjectPopUp.ClickOnCreateButton();
        }

        [Then(@"I should see the detailed project")]
        public void ThenIShouldSeeTheDetailedProject(string ProjectName,
                string ProjectType, string ProjectStatus, string StartDate,
                string EndDate, string Size, string Location,
                string ProjectManager, string DeliveryManager,
                string EngagementManager, string ShortDescription,
                string LongDescription, string Technologies, string ClientName,
                string ClientIndustry, string ClientDescription
)
        {
            Assert.That(_detailedProjectPage.GetProjectNameText(), Is.EqualTo(ProjectName));
            Assert.That(_detailedProjectPage.GetProjectTypeText(), Is.EqualTo(ProjectType));
            Assert.That(_detailedProjectPage.GetProjectStatusText(), Is.EqualTo(ProjectStatus));
            Assert.That(_detailedProjectPage.GetStartDateText(), Is.EqualTo(StartDate));
            Assert.That(_detailedProjectPage.GetEndDateText(), Is.EqualTo(EndDate));
            Assert.That(_detailedProjectPage.GetSizeText(), Is.EqualTo(Size));
            Assert.That(_detailedProjectPage.GetLocationText(), Is.EqualTo(Location));
            Assert.That(_detailedProjectPage.GetProjectManagerText(), Is.EqualTo(ProjectManager));
            Assert.That(_detailedProjectPage.GetDeliveryManagerText(), Is.EqualTo(DeliveryManager));
            Assert.That(_detailedProjectPage.GetEngagementManagerText(), Is.EqualTo(EngagementManager));
            Assert.That(_detailedProjectPage.GetShortDescriptionText(), Is.EqualTo(ShortDescription));
            Assert.That(_detailedProjectPage.GetLongDescriptionText(), Is.EqualTo(LongDescription));
            Assert.That(_detailedProjectPage.GetTechnologiesText(), Is.EqualTo(Technologies));
            Assert.That(_detailedProjectPage.GetClientNameText(), Is.EqualTo(ClientName));
            Assert.That(_detailedProjectPage.GetClientIndustryText(), Is.EqualTo(ClientIndustry));
            Assert.That(_detailedProjectPage.GetClientDescriptionText(), Is.EqualTo(ClientDescription));
        }



        
    }
}