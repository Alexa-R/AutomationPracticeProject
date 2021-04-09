using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using AutomationPracticeProject.WrapperFactory;
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

        public void ClickOptionFromFilterChecklist(string filterName, string optionName)
        {
            LogHelper.Info($"Clicking on the {filterName} filter {optionName} option");
            new WrapperWebElement(By.XPath($"//*[@class='layered_filter'][.//*[text()='{filterName}']]//li[.//*[text()='{optionName}']]//*[@class='checker']")).Click();
        }

        public bool IsOptionFromFilterChecklistChecked(string filterName, string optionName)
        {
            LogHelper.Info($"Verifying that the {filterName} filter {optionName} option is checked");
            return new WrapperWebElement(By.XPath($"//*[@class='layered_filter'][.//*[text()='{filterName}']]//li[.//*[text()='{optionName}']]//*[@class='checked']")).Displayed;
        }

        public bool IsProductsTitlesContainsString(string substring)
        {
            LogHelper.Info($"Checking that all products' titles on PLP contains {substring}");
            var isContains = false;
            var list = WebDriverFactory.Driver.FindElements(By.XPath("//*[@class='product_list row grid']//*[@class='product-name']"));
            for (var i = 0; i < list.Count; i++)
            {
                isContains = list[i].Text.Contains(substring);
            }

            return isContains;
        }
    }
}