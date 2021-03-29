using System.Configuration;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.MyAccount
{
    public class MyWishLists : BaseTest
    {
        [Test]
        public void AddNewWishList()
        {
            var wishListName = $"WishListName{RandomHelper.GetRandomString(8)}";

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyWishListsButton();
            Pages.MyWishListsPage.EnterWishListName(wishListName);
            Pages.MyWishListsPage.ClickSaveButton();
            Assert.That(Pages.MyWishListsPage.GetWishListsTableText(), Contains.Substring(wishListName));
        }
    }
}