﻿using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.Search
{
    public class SearchResultPopup : BaseTest
    {
        [Test]
        public void GoToProductThroughSearchResultPopup()
        {
            Pages.BasePage.EnterItemInSearchInputField("Printed Dress");
            var resultItemText = Pages.BasePage.GetItemFromSearchResultPopupText(1);
            Pages.BasePage.ClickItemFromSearchResultPopup(1);
            Assert.That(resultItemText, Contains.Substring(Pages.ProductPage.GetProductTitleText()));
        }
    }
}