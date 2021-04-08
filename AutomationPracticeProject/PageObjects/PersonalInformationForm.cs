using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class PersonalInformationForm : BasePage
    {
        private WrapperWebElement CurrentPasswordInputField => new WrapperWebElement(By.XPath("//*[@id='old_passwd']"));
        private WrapperWebElement LastNameInputField => new WrapperWebElement(By.XPath("//*[@id='lastname']"));
        private WrapperWebElement SaveButton => new WrapperWebElement(By.XPath("//*[@name='submitIdentity']"));
        private WrapperWebElement SuccessAlert => new WrapperWebElement(By.XPath("//*[@class='alert alert-success']"));
        private WrapperWebElement DaysDropdownSelectedElement => new WrapperWebElement(By.XPath("//*[@id='days']//*[@selected]"));
        private WrapperWebElement MonthsDropdownSelectedElement => new WrapperWebElement(By.XPath("//*[@id='months']//*[@selected]"));
        private WrapperWebElement YearsDropdownSelectedElement => new WrapperWebElement(By.XPath("//*[@id='years']//*[@selected]"));

        public void ClearLastNameInputField()
        {
            LogHelper.Info($"Clearing of the Last Name Input Field");
            LastNameInputField.Clear();
        }

        public void EnterLastName(string lastName)
        {
            LogHelper.Info($"Entering of the Last Name");
            LastNameInputField.SendKeys(lastName);
        }

        public void EnterCurrentPassword(string currentPassword)
        {
            LogHelper.Info($"Entering of the Current Password");
            CurrentPasswordInputField.SendKeys(currentPassword);
        }

        public void ClickSaveButton()
        {
            LogHelper.Info("Clicking on the Save Button");
            SaveButton.Click();
        }

        public bool IsSuccessAlertDisplayed()
        {
            LogHelper.Info("Checking the display of the SuccessAlert");
            return SuccessAlert.Displayed;
        }

        public string GetDaysDropdownSelectedValue()
        {
            LogHelper.Info("Getting the Days Dropdown Selected Element Value");
            return DaysDropdownSelectedElement.GetAttribute("value");
        }

        public string GetMonthDropdownSelectedValue()
        {
            LogHelper.Info("Getting the Month Dropdown Selected Element Value");
            return MonthsDropdownSelectedElement.GetAttribute("value");
        }

        public string GetYearsDropdownSelectedValue()
        {
            LogHelper.Info("Getting the Years Dropdown Selected Element Value");
            return YearsDropdownSelectedElement.GetAttribute("value");
        }
    }
}