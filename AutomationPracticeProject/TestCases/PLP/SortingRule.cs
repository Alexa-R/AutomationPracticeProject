﻿using AutomationPracticeProject.Constants;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.PLP
{
    public class SortingRule : BaseTest
    {
        [Test, Category("Priority_Medium")]
        public void SortProductsOnCategoryPlp()
        {
            Pages.BasePage.ClickProductCategoryButton(ProductCategoryNamesConstants.Women);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.SortDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.SortDropdown, SortDropdownConstants.PriceLowestFirst);
            Assert.IsTrue(Pages.SearchResultPage.AreProductsSortedByPriceLowestFirst());
        }

        [Test, Category("Priority_Medium")]
        public void SortProductsOnSearchPlp()
        {
            Pages.BasePage.EnterItemInSearchInputField("Dress");
            Pages.BasePage.KeyEnter();
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.SortDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.SortDropdown, SortDropdownConstants.PriceLowestFirst);
            Assert.IsTrue(Pages.SearchResultPage.AreProductsSortedByPriceLowestFirst());
        }
    }
}