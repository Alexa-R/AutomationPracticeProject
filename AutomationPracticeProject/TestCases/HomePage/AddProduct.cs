﻿using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.HomePage
{
    public class AddProduct : BaseTest
    {
        [Test, Category("Priority_High")]
        public void AddProductToCartFromHomePage()
        {
            Pages.HomePage.MoveToProductCard(1);
            var productTitle = Pages.HomePage.GetProductTitle(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Assert.AreEqual(productTitle, Pages.CheckoutPage.GetLastProductTitleText());
        }
    }
}