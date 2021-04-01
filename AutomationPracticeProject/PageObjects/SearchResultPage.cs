using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class SearchResultPage : BasePage
    {
        private WrapperWebElement FirstItemTitle => new WrapperWebElement(By.XPath("//*[contains(@class,'first-in-line') and contains(@class,'first-item')]//*[@class='product-name']"));
        private WrapperWebElement FirstItemAddToCartButton => new WrapperWebElement(By.XPath("//*[contains(@class,'first-in-line') and contains(@class,'first-item')]//*[contains(@class,'add_to_cart')]"));
        private WrapperWebElement FirstItemCard => new WrapperWebElement(By.XPath("//*[contains(@class,'first-in-line') and contains(@class,'first-item')]"));

        public string GetFirstItemTitleText()
        {
            LogHelper.Info("Getting the First Item Title");
            return FirstItemTitle.Text;
        }

        public void MoveToFirstItemCard()
        {
            LogHelper.Info($"Moving to First Item Card");
            FirstItemCard.MoveToElement();
        }

        public void ClickFirstItemAddToCartButton()
        {
            LogHelper.Info("Clicking on the First Item Add To Cart Button");
            FirstItemAddToCartButton.Click();
        }
    }
}