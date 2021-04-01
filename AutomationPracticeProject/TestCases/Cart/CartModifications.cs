using System.Configuration;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.Cart
{
    public class CartModifications : BaseTest
    {
        [Test, Category("PriorityA")]
        public void EditCart()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickHomeButton();
            Pages.HomePage.MoveToProductCard(1);
            var productTitle = Pages.HomePage.GetProductTitle(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickLastProductTrashButton();
            
            Assert.AreNotEqual(productTitle, Pages.CheckoutPage.GetLastProductTitleText());
        }
    }
}