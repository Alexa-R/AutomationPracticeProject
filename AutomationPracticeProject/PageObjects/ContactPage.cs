using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class ContactPage : BasePage
    {
        private WrapperWebElement MessageTextArea => new WrapperWebElement(By.XPath("//*[@id='message']"));
        private WrapperWebElement SendButton => new WrapperWebElement(By.XPath("//*[@id='submitMessage']"));
        private WrapperWebElement SuccessAlert => new WrapperWebElement(By.XPath("//*[@class='alert alert-success']"));

        public void EnterMessage(string message)
        {
            LogHelper.Info($"Entering of the Message");
            MessageTextArea.SendKeys(message);
        }

        public void ClickSendButton()
        {
            LogHelper.Info("Clicking on the Send Button");
            SendButton.Click();
        }

        public bool IsSuccessAlertDisplayed()
        {
            LogHelper.Info("Checking the display of the SuccessAlert");
            return SuccessAlert.Displayed;
        }
    }
}