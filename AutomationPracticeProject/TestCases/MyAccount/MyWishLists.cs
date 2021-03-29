﻿using System.Configuration;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.MyAccount
{
    public class MyWishLists : BaseTest
    {
        private string wishListName = $"WishListName{RandomHelper.GetRandomString(8)}";

        [Test]
        public void AddNewWishList()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyWishListsButton();
            Pages.MyWishListsPage.CreateWishList(wishListName);
            Assert.That(Pages.MyWishListsPage.GetWishListsTableText(), Contains.Substring(wishListName));

            Pages.MyWishListsPage.DeleteWishList(wishListName);
        }

        [Test]
        public void DeleteWishList()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyWishListsButton();
            Pages.MyWishListsPage.CreateWishList(wishListName);
            Pages.MyWishListsPage.DeleteWishList(wishListName);
            Assert.That(Pages.MyWishListsPage.GetWishListsTableText(), !Contains.Substring(wishListName.ToUpper()));
        }
    }
}