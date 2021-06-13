using System.Configuration;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.Cart
{
    public class CartModifications : BaseTest
    {
        [Test, Category("High")]
        public void EditCart()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickHomeButton();
            Pages.HomePage.MoveToProductCard(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickLastProductTrashButton();
            
            Assert.AreEqual("Your shopping cart is empty.", Pages.CheckoutPage.GetWarningAlertText());
        }
    }
}