using System.Configuration;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UserFlow
{
    public class Checkout : BaseTest
    {
        [Test]
        public void CheckoutUsingBankWire()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickHomeButton();
            Pages.HomePage.MoveToProductCard(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.HomePage.WaitUntilCartPopupIsDisplayed();
            Pages.HomePage.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickTermsOfServiceAgreementCheckBox();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickPayByBankWireButton();
            Pages.CheckoutPage.ClickIConfirmMyOrderButton();
            Assert.That(Pages.CheckoutPage.GetOrderConfirmationTitleText(), Contains.Substring("is complete"));
        }
    }
}