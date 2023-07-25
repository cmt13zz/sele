using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSpecflow.Library;
using OpenQA.Selenium;

namespace DemoSpecflow.Pages
{
    public class DetailedFormPopUp : BasePage
    {

        private WebObject _lblName = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(1) > td:nth-child(2)"), "Name Label");
        private WebObject _lblEmail = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(2) > td:nth-child(2)"), "Email Label");
        private WebObject _lblGender = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(3) > td:nth-child(2)"), "Gender Label");
        private WebObject _lblMobile = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(4) > td:nth-child(2)"), "Mobile Label");
        private WebObject _lblDateOfBirth = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(5) > td:nth-child(2)"), "Date of birth Label");
        private WebObject _lblSubjects = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(6) > td:nth-child(2)"), "Subject Label");
        private WebObject _lblHobbies = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(7) > td:nth-child(2)"), "Hobbies Label");
        private WebObject _lblPicture = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(8) > td:nth-child(2)"), "Picture Label");
        private WebObject _lblAddress = new WebObject(By.CssSelector(".table > tbody > tr:nth-child(9) > td:nth-child(2)"), "Address Label");
       


        public DetailedFormPopUp(IWebDriver driver) : base(driver)
        {
        }

        public string GetLabelName() {
            return GetText(_lblName);
        }

        public string GetLabelEmail() {
            return GetText(_lblEmail);
        }

        public string GetLabelGender() {
            return GetText(_lblGender);
        }

        public string GetLabelMobile() {
            return GetText(_lblMobile);
        }

        public string GetLabelDateOfBirth() {
            return GetText(_lblDateOfBirth);
        }

        public string GetLabelSubjects() {
            return GetText(_lblSubjects);
        }

        public string GetLabelHobbies() {
            return GetText(_lblHobbies);
        }

        public string GetLabelPicture() {
            return GetText(_lblPicture);
        }

        public string GetLabelAddress() {
            return GetText(_lblAddress);
        }

       

        
    }
}