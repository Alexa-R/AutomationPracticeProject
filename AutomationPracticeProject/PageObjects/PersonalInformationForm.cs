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
    }
}