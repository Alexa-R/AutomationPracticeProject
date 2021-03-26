using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class HomePage
    {
        private WrapperWebElement CartPopup => new WrapperWebElement(By.XPath("//*[@id='layer_cart']"));
        private WrapperWebElement ProceedToCheckoutButton => new WrapperWebElement(By.XPath("//*[@id='layer_cart']"));

        public void ClickAddToCartButtonInCard(int productCardIndex)
        {
            LogHelper.Info($"Clicking on the Add To Cart Button in {productCardIndex} product card");
            new WrapperWebElement(By.XPath($"//*[@id='homefeatured']//*[contains(@class,'add_to_cart_button') and @data-id-product={productCardIndex}]")).Click();
        }

        public void WaitUntilCartPopupIsDisplayed()
        {
            LogHelper.Info("Waiting for Cart Popup is display");
            CartPopup.WaitForElementIsDisplayed();
        }

        public void ClickProceedToCheckoutButton()
        {
            LogHelper.Info("Clicking on the ProceedToCheckout Button");
            ProceedToCheckoutButton.Click();
        }
    }
}