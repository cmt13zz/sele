using DemoSpecflow.Library;
using OpenQA.Selenium;

namespace DemoSpecflow.Pages
{
    public class FormPage : BasePage
    {
        private WebObject txtFirstName = new WebObject(By.Id("firstName"), "First name Textbox");
        private WebObject txtLastName = new WebObject(By.Id("lastName"), "Last name Textbox");
        private WebObject txtEmail = new WebObject(By.Id("userEmail"), "Email Textbox");
        private WebObject radioGender = new WebObject(By.CssSelector("#genterWrapper > div:nth-child(2) > div:nth-child(2) > label"), "Gender Radio" );
        private WebObject txtMobileNumber = new WebObject(By.Id("userNumber"), "Mobile Number Textbox");
        private WebObject btnDateOfBirth = new WebObject(By.Id("dateOfBirthInput"),"Date of birth button");
        private WebObject DateSelect = new WebObject(By.ClassName("react-datepicker__day--008"), "Select date for DatePicker");
        private WebObject txtSubject = new WebObject(By.Id("subjectsInput"), "Input letter for subject");
        private WebObject SubjectSelect = new WebObject(By.CssSelector("#react-select-2-option-0"), "Select subject");
        private WebObject checkBoxHobbies = new WebObject(By.CssSelector("#hobbiesWrapper > div:nth-child(2) > div:nth-child(1) > label"), "Hobbies Checkbox");
        private WebObject btnUploadPicture = new WebObject(By.Id("uploadPicture"), "Upload Picture button");
        private WebObject txtCurrentAddress = new WebObject(By.Id("currentAddress"), "Current Address Textbox");
        private WebObject btnSubmit = new WebObject(By.Id("submit"), "Submit button");
        private WebObject btnClose = new WebObject(By.Id("closeLargeModal"), "Close button");
    
        public FormPage(IWebDriver driver) : base(driver)
        {
        }

        public void InputFirstName(string firstName) {
            InputText(txtFirstName, firstName);
        }

        public void InputLastName(string lastName) {
            InputText(txtLastName, lastName);
        }

        public void InputEmail(string email) {
            InputText(txtEmail, email);
        }

        public void ClickRadioGender() {
            ClickElement(radioGender);
        }

        public void InputMobileNumber(string mobileNumber) {
            InputText(txtMobileNumber, mobileNumber);
        }

        public void ClickDateOfBirth() {
            ClickElement(btnDateOfBirth);
        }

        public void ClickDateSelect() {
            ClickElement(DateSelect);
        }

        public void InputSubject(string subject) {
            InputText(txtSubject, subject);
        }

        public void ClickSubjectOption() {
            ClickElement(SubjectSelect);
        }

        public void ClickHobbiesCheckbox() {
            ClickElement(checkBoxHobbies);
        }

        public void UploadPictureInForm() {
            UploadPicture(btnUploadPicture);
        }
        

        public void InputCurrentAddress(string currentAddress) {
            InputText(txtCurrentAddress, currentAddress);
        }

        public string GetCloseButton() {
            return GetText(btnClose);
        }
        public void ClickSubmitButton() {
            ClickSubmitButtonJs();
        }

        public void HideAds() {
            HideElement();
        }
        

    }
}