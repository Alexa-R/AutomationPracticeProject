using System.Collections.Generic;
using System.Net.Http;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using FluentAssertions;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.ApiTestCases.Search
{
    public class Plp : BaseTest
    {
        [Test, Category("High")]
        public void ProductsAreDisplayedOnPageAccordingToSearch()
        {
            var searchText = "Faded Short Sleeve T-shirts";

            LogHelper.Info("Trying to check that products are displayed on the page according to the search via API");
            var searchData = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("controller", "search"),
                        new KeyValuePair<string, string>("orderby", "position"),
                        new KeyValuePair<string, string>("orderway", "desc"),
                        new KeyValuePair<string, string>("search_query", searchText),
                        new KeyValuePair<string, string>("submit_search", "")
                    }
                );

            var response = ApiHelper.SendPostRequest(_client, EndPoints.BasePath, searchData, ContentTypeConstants.FormUrlencoded);

            var firstItemTitleXpath ="//*[contains(@class,'first-in-line') and contains(@class,'first-item')]//*[@class='product-name']";
            HtmlAssertions.GetHtmlElementText(response.Result.Content.ReadAsStringAsync().Result, firstItemTitleXpath).Should().Contain(searchText);
        }
    }
}