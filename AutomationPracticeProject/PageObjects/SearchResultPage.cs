using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AreProductsTitlesContainString(string substring)
        {
            LogHelper.Info($"Checking that all products' titles on PLP contains {substring}");
            var areContain = false;
            var productsTitlesList = WebDriverFactory.Driver.FindElements(By.XPath("//*[@class='product_list row grid']//*[@class='product-name']"));
            foreach (var element in productsTitlesList)
            { 
                areContain = element.Text.Contains(substring);
            }

            return areContain;
        }
        
        public bool AreProductsSortedByPriceLowestFirst()
        {
            LogHelper.Info($"Checking that all products are sorted by Price: Lowest First");
            var areSorted = false;
            var productPricesTextList = new List<double>();
            var productsPricesList = WebDriverFactory.Driver.FindElements(By.XPath("//*[@class='right-block']//*[@class='price product-price']"));
            foreach (var element in productsPricesList)
            {
                productPricesTextList.Add(Convert.ToDouble(element.Text.Trim().TrimStart('$')));
            }
            var sortedProductsPricesTextList = productPricesTextList.OrderBy(v => v).ToList();
            areSorted = productPricesTextList.Equals(sortedProductsPricesTextList);

            return areSorted;
        }
    }
}