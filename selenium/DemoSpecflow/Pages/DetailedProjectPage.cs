using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSpecflow.Library;
using OpenQA.Selenium;

namespace DemoSpecflow.Pages
{
    public class DetailedProjectPage : BasePage
    {
        private WebObject _txtProjectName = new WebObject(By.XPath("//label[@for='name']/../p"), "Project Name Textbox");
        private WebObject _ddlProjectType = new WebObject(By.XPath("//label[@for='type']/../p"), "Project Type Dropdown List");
        private WebObject _ddlProjectStatus = new WebObject(By.XPath("//label[@for='status']/../p"), "Project Status Dropdown List");
        private WebObject _dtpStartDate = new WebObject(By.XPath("//label[@for='startDate']/../p"), "Project Start Date Date Picker");
        private WebObject _dtpEndDate = new WebObject(By.XPath("//label[@for='endDate']/../p"), "Project End Date Date Picker");
        private WebObject _txtSize = new WebObject(By.XPath("//label[@for='sizeday']/../p"), "Project Name Textbox");
        private WebObject _ddlLocation = new WebObject(By.XPath("//label[@for='location']/../p"), "Location Dropdown List");
        private WebObject _ddlProjectManager = new WebObject(By.XPath("//label[@for='projectManager']/../p"), "Project Manager Dropdown List");
        private WebObject _ddlDeliveryManager = new WebObject(By.XPath("//label[@for='deliveryManager']/../p"), "Delivery Manager Dropdown List");
        private WebObject _ddlEngagementManager = new WebObject(By.XPath("//label[@for='engagementManager']/../p"), "Engagement Manager Dropdown List");
        private WebObject _txaShortDescription = new WebObject(By.XPath("//label[@for='shortDescription']/../p"), "Short Description Textarea");
        private WebObject _txaLongDescription = new WebObject(By.XPath("//label[@for='longDescription']/../p"), "Long Description Textarea");
        private WebObject _txaTechnologies = new WebObject(By.XPath("//label[@for='technologies']/../p"), "Technologies Textarea");
        private WebObject _txtClientName = new WebObject(By.XPath("//label[@for='clientName']/../p"), "Client Name Textbox");
        private WebObject _ddlClientIndustry = new WebObject(By.XPath("//label[@for='clientindustry']/../p"), "Client Industry Dropdown List");
        private WebObject _txaClientDescription = new WebObject(By.XPath("//label[@for='clientdescription']/../p"), "Client Description Textarea");
        private WebObject _btnDelete = new WebObject(By.Id("btnDelete"), "Delete Button");
        private WebObject _btnDeleteConfirm = new WebObject(By.CssSelector("#modalDeleteProject button[type='submit']"), "Delete Confirm Button");


        public DetailedProjectPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnDeleteButton()
        {
            ClickElement(_btnDelete);
        }

        public void ClickOnDeleteConfirnButton()
        {
            ClickElement(_btnDeleteConfirm);
        }

        public string GetProjectNameText()
        {
            return GetText(_txtProjectName);
        }

        public string GetProjectTypeText()
        {
            return GetText(_ddlProjectType);
        }

        public string GetProjectStatusText()
        {
            return GetText(_ddlProjectStatus);
        }

        public string GetStartDateText()
        {
            return GetText(_dtpStartDate);
        }

        public string GetEndDateText()
        {
            return GetText(_dtpEndDate);
        }

        public string GetSizeText()
        {
            return GetText(_txtSize);
        }

        public string GetLocationText()
        {
            return GetText(_ddlLocation);
        }

        public string GetProjectManagerText()
        {
            return GetText(_ddlProjectManager);
        }

        public string GetDeliveryManagerText()
        {
            return GetText(_ddlDeliveryManager);
        }

        public string GetEngagementManagerText()
        {
            return GetText(_ddlEngagementManager);
        }

        public string GetShortDescriptionText()
        {
            return GetText(_txaShortDescription);
        }

        public string GetLongDescriptionText()
        {
            return GetText(_txaLongDescription);
        }

        public string GetTechnologiesText()
        {
            return GetText(_txaTechnologies);
        }

        public string GetClientNameText()
        {
            return GetText(_txtClientName);
        }

        public string GetClientIndustryText()
        {
            return GetText(_ddlClientIndustry);
        }

        public string GetClientDescriptionText()
        {
            return GetText(_txaClientDescription);
        }

    }
}