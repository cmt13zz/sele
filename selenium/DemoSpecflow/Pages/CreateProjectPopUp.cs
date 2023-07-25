using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DemoSpecflow.Library;
using OpenQA.Selenium;

namespace DemoSpecflow.Pages
{
    public class CreateProjectPopUp : BasePage
    {

        private WebObject _txtProjectName = new WebObject(By.Id("name"), "Project Name Textbox");
        private WebObject _ddlProjectType = new WebObject(By.Id("projecttype"), "Project Type Dropdown List");
        private WebObject _ddlProjectStatus = new WebObject(By.Id("status"), "Project Status Dropdown List");
        private WebObject _dtpStartDate = new WebObject(By.Name("sdate"), "Project Start Date Date Picker");
        private WebObject _dtpEndDate = new WebObject(By.Name("edate"), "Project End Date Date Picker");
        private WebObject _txtSize = new WebObject(By.Id("sizeday"), "Project Name Textbox");
        private WebObject _ddlLocation = new WebObject(By.Id("location"), "Location Dropdown List");
        private WebObject _ddlProjectManager = new WebObject(By.Id("projectManager"), "Project Manager Dropdown List");
        private WebObject _ddlDeliveryManager = new WebObject(By.Id("deliveryManager"), "Delivery Manager Dropdown List");
        private WebObject _ddlEngagementManager = new WebObject(By.Id("engagementManager"), "Engagement Manager Dropdown List");
        private WebObject _txaShortDescription = new WebObject(By.Id("shortDescription"), "Short Description Textarea");
        private WebObject _txaLongDescription = new WebObject(By.Id("longDescription"), "Long Description Textarea");
        private WebObject _txaTechnologies = new WebObject(By.Id("technologies"), "Technologies Textarea");
        private WebObject _txtClientName = new WebObject(By.Id("clientName"), "Client Name Textbox");
        private WebObject _ddlClientIndustry = new WebObject(By.Id("clientindustry"), "Client Industry Dropdown List");
        private WebObject _txaClientDescription = new WebObject(By.Id("clientdescription"), "Client Description Textarea");
        private WebObject _btnCreate = new WebObject(By.Id("btnConfirm"), "Create Button");
        private WebObject _btnDatePickerTitle = new WebObject(By.CssSelector("button[id^='datepicker'][id$='title']"), "Date Picker Title Button");
        private WebObject _btnDatePickerRight = new WebObject(By.CssSelector("button.uib-right"), "Date Picker Next Button");
        private WebObject _btnDatePickerLeft = new WebObject(By.CssSelector("button.uib-left"), "Date Picker Previous Button");
        private string _yearLocatorFormat = "//table[contains(@class, 'uib-yearpicker')]//span[text()='{0}']//parent::button";
        private string _monthLocatorFormat = "table.uib-monthpicker tr:nth-child({0}) td:nth-child({1}) button";
        private string _dateLocatorFormat = "//table[contains(@class, 'uib-daypicker')]//span[not(contains(@class,'text-muted'))][text()='{0:d2}']//parent::button";

        public CreateProjectPopUp(IWebDriver driver) : base(driver)
        {
        }

        public void InputProjectName(string projectName)
        {
            InputText(_txtProjectName, projectName);
        }

        public void SelectProjectTypeDrodownListByText(string text)
        {
            SelectOptionByText(_ddlProjectType, text);
        }

        public void SelectProjectStatusDrodownListByText(string text)
        {
            SelectOptionByText(_ddlProjectStatus, text);
        }

        public void PickStartDateDatePicker(string dateInput)
        {
            ClickElement(_dtpStartDate);
            _pickDatePicker(dateInput);
        }

        public void PickEndDateDatePicker(string dateInput)
        {
            ClickElement(_dtpEndDate);
            _pickDatePicker(dateInput);
        }

        public void InputSize(string size)
        {
            InputText(_txtSize, size);
        }

        public void SelectLocationDrodownListByText(string text)
        {
            SelectOptionByText(_ddlLocation, text);
        }

        public void SelectProjectManagerDrodownListByText(string text)
        {
            SelectOptionByText(_ddlProjectManager, text);
        }

        public void SelectDeliveryManagerDrodownListByText(string text)
        {
            SelectOptionByText(_ddlDeliveryManager, text);
        }

        public void SelectEngagementManagerDrodownListByText(string text)
        {
            SelectOptionByText(_ddlEngagementManager, text);
        }

        public void InputShortDescription(string shortDescription)
        {
            InputText(_txaShortDescription, shortDescription);
        }

        public void InputLongDescription(string longDescription)
        {
            InputText(_txaLongDescription, longDescription);
        }

        public void InputTechnologies(string technologies)
        {
            InputText(_txaTechnologies, technologies);
        }

        public void InputClientName(string clientName)
        {
            InputText(_txtClientName, clientName);
        }

        public void SelectClientIndustryDrodownListByText(string text)
        {
            SelectOptionByText(_ddlClientIndustry, text);
        }

        public void InputClientDescription(string clientDescription)
        {
            InputText(_txaClientDescription, clientDescription);
        }

        public void ClickOnCreateButton()
        {
            ClickElement(_btnCreate);
        }

        private WebObject _getYearObject(int year)
        {
            return new WebObject(By.XPath(string.Format(_yearLocatorFormat, year)), $"Year {year}");
        }

        private WebObject _getMonthObject(int month)
        {
            int row = (month - 1) / 4 + 1;
            int col = (month - 1) % 3 + 1;
            return new WebObject(By.CssSelector(string.Format(_monthLocatorFormat, row, col)), $"Month {month}");
        }

        private WebObject _getDayObject(int date)
        {
            return new WebObject(By.XPath(string.Format(_dateLocatorFormat, date)), $"Date {date}");
        }

        private void _pickDatePicker(string dateInput)
        {
            var dateObj = DateTime.Parse(dateInput);
            int year = dateObj.Year;
            int month = dateObj.Month;
            int day = dateObj.Day;
            Regex yearRegex = new Regex(@"(\d+) - (\d+)");
            ClickElement(_btnDatePickerTitle);
            ClickElement(_btnDatePickerTitle);

            while (true)
            {
                string yearTitle = GetText(_btnDatePickerTitle);
                Match yearMatch = yearRegex.Match(yearTitle);
                if (yearMatch.Success)
                {
                    int fromYear = int.Parse(yearMatch.Groups[1].Value);
                    int toYear = int.Parse(yearMatch.Groups[2].Value);
                    if (fromYear <= year && year <= toYear)
                    {
                        break;
                    }
                    else if (year < fromYear)
                    {
                        ClickElement(_btnDatePickerLeft);
                    }
                    else if (toYear < year)
                    {
                        ClickElement(_btnDatePickerRight);
                    }
                }
            }
            ClickElement(_getYearObject(year));
            ClickElement(_getMonthObject(month));
            ClickElement(_getDayObject(day));
        }

    }
}