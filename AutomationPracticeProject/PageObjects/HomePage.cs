using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class HomePage : BasePage
    {
        public void MoveToProductCard(int productCardIndex)
        {
            LogHelper.Info($"Moving to {productCardIndex} product card");
            new WrapperWebElement(By.XPath($"//*[@id='homefeatured']//*[@class='product-container'][.//*[@data-id-product={productCardIndex}]]")).MoveToElement();
        }

        public void ClickAddToCartButtonInCard(int productCardIndex)
        {
            LogHelper.Info($"Clicking on the Add To Cart Button in {productCardIndex} product card");
            new WrapperWebElement(By.XPath($"//*[@id='homefeatured']//*[contains(@class,'add_to_cart_button') and @data-id-product={productCardIndex}]")).Click();
        }

        public string GetProductTitle(int productCardIndex)
        {
            LogHelper.Info($"Getting the Product Title of the {productCardIndex} product card");
            return new WrapperWebElement(By.XPath($"//*[@id='homefeatured']//*[@class='product-container'][.//*[@data-id-product={productCardIndex}]]//*[@class='product-name']")).Text;
        }
    }
}