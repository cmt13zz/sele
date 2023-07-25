
using NUnit.Framework;
using DemoUnitFW.Pages;
using DemoUnitFW.Library;

namespace DemoUnitFW.Tests
{
    public class FormTest: BaseTest
    {

        FormPage formPage;

        [SetUp]
       
        public new void Setup()
        {

             formPage = new FormPage(BaseTest.Driver);
             formPage.Navigate("/automation-practice-form");
             
        }

        [Test]
        public void CreateFormWithAllFields()
        {
            formPage.InputFirstName(JsonHelper.GetTestDataString("FirstName"));
            formPage.InputLastName(JsonHelper.GetTestDataString("LastName"));
            formPage.InputEmail(JsonHelper.GetTestDataString("Email"));
            formPage.ClickRadioGender();
            formPage.InputMobileNumber(JsonHelper.GetTestDataString("MobileNumber"));
            formPage.ClickDateOfBirth();
            formPage.ClickDateSelect();
            formPage.InputSubject(JsonHelper.GetTestDataString("Subject"));
            formPage.ClickSubjectOption();
            formPage.ClickHobbiesCheckbox();
            formPage.UploadPictureInForm();
            formPage.InputCurrentAddress(JsonHelper.GetTestDataString("CurrentAddress"));
            formPage.ClickSubmitButton();
            Thread.Sleep(1000);
            string txtClose = formPage.GetCloseButton();
            Assert.That(txtClose, Is.EqualTo("Close"), "Fill form successfully");
        }

        [Test]
        public void CreateFormWithRequiredFields() {
            formPage.InputFirstName(JsonHelper.GetTestDataString("FirstName"));
            formPage.InputLastName(JsonHelper.GetTestDataString("LastName"));
            formPage.InputEmail(JsonHelper.GetTestDataString("Email"));
            formPage.ClickRadioGender();
            formPage.InputMobileNumber(JsonHelper.GetTestDataString("MobileNumber"));
            formPage.ClickSubmitButton();
            Thread.Sleep(1000);
            string txtClose = formPage.GetCloseButton();
            Assert.That(txtClose, Is.EqualTo("Close"), "Fill mandatory form successfully");
        }
    }
}