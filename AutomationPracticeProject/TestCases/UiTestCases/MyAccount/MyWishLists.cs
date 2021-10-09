using System.Configuration;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.MyAccount
{
    public class MyWishLists : BaseTest
    {
        private string _wishListName = $"WishListName{RandomHelper.GetRandomString(8)}";

        [Test, Category("Medium")]
        public void AddNewWishList()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyWishListsButton();
            Pages.MyWishListsPage.CreateWishList(_wishListName);
            Assert.That(Pages.MyWishListsPage.GetWishListsTableText(), Contains.Substring(_wishListName));

            Pages.MyWishListsPage.DeleteWishList(_wishListName);
        }

        [Test, Category("Medium")]
        public void DeleteWishList()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyWishListsButton();
            Pages.MyWishListsPage.CreateWishList(_wishListName);
            Pages.MyWishListsPage.DeleteWishList(_wishListName);
            Assert.That(Pages.MyWishListsPage.GetWishListsTableText(), !Contains.Substring(_wishListName.ToUpper()));
        }

        [Test, Category("Medium")]
        public void EditWishList()
        {
            var newWishListName = $"NewWishListName{RandomHelper.GetRandomString(8)}";

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyWishListsButton();
            Pages.MyWishListsPage.CreateWishList(_wishListName);
            Pages.MyWishListsPage.ClickWishList(_wishListName);
            Pages.MyWishListsPage.ClickEditButton();
            Pages.MyWishListsPage.EnterNewWishListName(newWishListName);
            Pages.MyWishListsPage.ClickSaveChangesButton();
            Assert.That(Pages.MyWishListsPage.GetWishListsTableText(), Contains.Substring(_wishListName));

            Pages.MyWishListsPage.DeleteWishList(_wishListName);
        }
    }
}