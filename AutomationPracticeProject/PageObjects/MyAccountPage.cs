using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class MyAccountPage : BasePage
    {
        private WrapperWebElement MyPersonalInformationButton => new WrapperWebElement(By.XPath("//*[@title='Information']"));
        private WrapperWebElement MyAddressesButton => new WrapperWebElement(By.XPath("//*[@title='Addresses']"));

        public void ClickMyPersonalInformationButton()
        {
            LogHelper.Info("Clicking on the Register Button");
            MyPersonalInformationButton.Click();
        }

        public void ClickMyAddressesButton()
        {
            LogHelper.Info("Clicking on the My Addresses Button");
            MyAddressesButton.Click();
        }
    }
}