﻿using System.Configuration;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.MyAccount
{
    public class OrderHistory : BaseTest
    {
        [Test, Category("High")]
        public void DisplayOfNewlyOrder()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickHomeButton();
            Pages.HomePage.MoveToProductCard(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickTermsOfServiceAgreementCheckBox();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickPayByCheckButton();
            Pages.CheckoutPage.ClickIConfirmMyOrderButton(); 
            var orderReference = Pages.CheckoutPage.GetOrderReference();
            Pages.BasePage.ClickAccountButton();
            Pages.MyAccountPage.ClickOrderHistoryAndDetailsButton();
            Assert.That(Pages.OrderHistoryPage.GetOrdersTableText(), Contains.Substring(orderReference));
        }
    }
}