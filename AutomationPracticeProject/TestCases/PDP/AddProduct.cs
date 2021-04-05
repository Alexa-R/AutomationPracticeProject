using System.Configuration;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.PDP
{
    public class AddProduct : BaseTest
    {
        [Test, Category("Priority_High")]
        public void AddProductToCartFromPdp()
        {
            Pages.BasePage.EnterItemInSearchInputField("Printed Dress");
            Pages.BasePage.ClickItemFromSearchResultPopup(1);
            var productTitle =  Pages.ProductPage.GetProductTitleText();
            Pages.ProductPage.ClickAddToCartButton();
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Assert.AreEqual(productTitle, Pages.CheckoutPage.GetLastProductTitleText());
        }

        [Test, Category("Priority_Medium")]
        public void AddProductToWishListFromPdp()
        {
            var wishListName = $"WishListName{RandomHelper.GetRandomString(8)}";

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.BasePage.EnterItemInSearchInputField("Printed Dress");
            Pages.BasePage.ClickItemFromSearchResultPopup(1);
            Pages.ProductPage.ClickAddToWishListButton();
            Pages.ProductPage.ClickCreateWishListButton();
            Pages.MyWishListsPage.CreateWishList(wishListName);
            Assert.IsTrue(Pages.ProductPage.IsSuccessAlertDisplayed());

            Pages.BasePage.ClickAccountButton();
            Pages.MyAccountPage.ClickMyWishListsButton();
            Pages.MyWishListsPage.DeleteWishList(wishListName);
        }
    }
}