
using DemoSpecflow.Library;
using TechTalk.SpecFlow;
using DemoSpecflow.Pages;
using NUnit.Framework;

namespace DemoSpecflow.Steps
{
    [Binding]
    public class FillApplicationFormSteps
    {

        FormPage _formPage = new FormPage(Context.Webdriver);
        DetailedFormPopUp _detailedFormPopUp = new DetailedFormPopUp(Context.Webdriver);

        [Given(@"I navigate to the Application Page")]
        public void GivenINavigateToTheApplicationPage()
        {
            _formPage.Navigate("/automation-practice-form");
        }

        [When (@"I input text in all fields with info below")]
        public void WhenIFillAllFieldsWithInfoBelow(Table table)
        {
            _formPage.HideAds();
            var dictionary = TableExtensions.ToDictionary(table);
            _formPage.InputFirstName(dictionary["FirstName"]);
            _formPage.InputLastName(dictionary["LastName"]);
            _formPage.InputEmail(dictionary["Email"]);
            _formPage.ClickRadioGender();
            _formPage.InputMobileNumber(dictionary["Mobile"]);
            _formPage.ClickDateOfBirth();
            _formPage.ClickDateSelect();
            _formPage.InputSubject(dictionary["Subjects"]);
            _formPage.ClickSubjectOption();
            _formPage.ClickHobbiesCheckbox();
            _formPage.UploadPictureInForm();
            _formPage.InputCurrentAddress(dictionary["CurrentAddress"]);
            

        }

        [When (@"I input text in mandatory fields with info below")]
        public void WhenIFillMandatoryFieldsWithInfoBelow(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            _formPage.InputFirstName(dictionary["FirstName"]);
            _formPage.InputLastName(dictionary["LastName"]); 
            _formPage.ClickRadioGender();
            _formPage.InputMobileNumber(dictionary["Mobile"]);
        }

        [When(@"I click on Submit button")]
        public void WhenIClickOnSubmitButton()
        {
            _formPage.ClickSubmitButton();
        }

        [Then(@"I see the detailed project popup")]
        public void ThenISeeTheDetailedProjectPoppup(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            Assert.That(_detailedFormPopUp.GetLabelName(), Is.EqualTo($"{dictionary["FirstName"]} {dictionary["LastName"]}"));
            Assert.That(_detailedFormPopUp.GetLabelEmail(), Is.EqualTo(dictionary["Email"]));
            Assert.That(_detailedFormPopUp.GetLabelGender(), Is.EqualTo(dictionary["Gender"]));
            Assert.That(_detailedFormPopUp.GetLabelMobile(), Is.EqualTo(dictionary["Mobile"]));
            Assert.That(_detailedFormPopUp.GetLabelDateOfBirth(), Is.EqualTo(dictionary["DateOfBirth"]));
            Assert.That(_detailedFormPopUp.GetLabelSubjects(), Is.EqualTo(dictionary["Subjects"]));
            Assert.That(_detailedFormPopUp.GetLabelHobbies(), Is.EqualTo(dictionary["Hobbies"]));
            Assert.That(_detailedFormPopUp.GetLabelPicture(), Is.EqualTo(dictionary["Picture"]));
            Assert.That(_detailedFormPopUp.GetLabelAddress(), Is.EqualTo(dictionary["CurrentAddress"]));

        }

        [Then(@"I see the detailed project popup with mandatory fields: ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]

        public void ThenISeeTheDetailedProjectPoppupWithMandatoryFields(string FirstName, string LastName, string Gender,
        string Mobile) {
            Assert.That(_detailedFormPopUp.GetLabelName(), Is.EqualTo($"{FirstName} {LastName}"));
            Assert.That(_detailedFormPopUp.GetLabelGender(), Is.EqualTo(Gender));
            Assert.That(_detailedFormPopUp.GetLabelMobile(), Is.EqualTo(Mobile));
        }




    }
}