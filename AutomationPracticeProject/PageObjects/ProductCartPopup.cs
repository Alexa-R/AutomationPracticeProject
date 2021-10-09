using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class ProductCartPopup : BasePage
    {
        private WrapperWebElement ProceedToCheckoutButton => new WrapperWebElement(By.XPath("//*[@title='Proceed to checkout']"));

        public void ClickProceedToCheckoutButton()
        {
            LogHelper.Info("Clicking on the ProceedToCheckout Button");
            ProceedToCheckoutButton.Click();
        }
    }
}