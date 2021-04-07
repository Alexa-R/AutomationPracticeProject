using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using AutomationPracticeProject.TestCases;
using FluentAssertions;
using NUnit.Framework;

namespace AutomationPracticeProject.ApiTestCases.MyAccount
{
    public class MyWishLists : BaseTest
    {
        [Test, Category("Priority_Medium")]
        public void AddNewWishList()
        {
            var wishListName = $"WishListName{RandomHelper.GetRandomString(8)}";

            var cookies = ApiHelper.GetAuthCookie(_client);
            var handler = new HttpClientHandler
            {
                CookieContainer = cookies
            };

            _client = new HttpClient(handler);

            var newWishListData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("controller", "mywishlist"),
                    new KeyValuePair<string, string>("fc", "module"),
                    new KeyValuePair<string, string>("module", "blockwishlist"),
                    new KeyValuePair<string, string>("name", wishListName),
                    new KeyValuePair<string, string>("token", "2564aec6dfc0deae462fc3414cbdd10d"),
                    new KeyValuePair<string, string>("submitWishlist", "")
                }
            );

            ApiHelper.SendPostRequest(_client, EndPoints.BasePath, newWishListData, ContentTypeConstants.FormUrlencoded);

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyWishListsButton();
            Pages.MyWishListsPage.GetWishListsTableText().Should().Contain(wishListName);
        }
    }
}