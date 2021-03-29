using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class MyAccountPage : BasePage
    {
        private WrapperWebElement MyPersonalInformationButton => new WrapperWebElement(By.XPath("//*[@title='Information']"));

        public void ClickMyPersonalInformationButton()
        {
            LogHelper.Info("Clicking on the Register Button");
            MyPersonalInformationButton.Click();
        }
    }
}