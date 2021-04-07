using System.Collections.Generic;
using System.Net.Http;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.TestCases;
using NUnit.Framework;

namespace AutomationPracticeProject.ApiTestCases.Search
{
    public class Plp : BaseTest
    {
        [Test, Category("Priority_High")]
        public void ProductsAreDisplayedOnPageAccordingToSearch()
        {
            var searchData = new FormUrlEncodedContent(
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("controller", "search"),
                        new KeyValuePair<string, string>("orderby", "position"),
                        new KeyValuePair<string, string>("orderway", "desc"),
                        new KeyValuePair<string, string>("search_query", "Faded Short Sleeve T-shirts"),
                        new KeyValuePair<string, string>("submit_search", "")
                    }
                );

            ApiHelper.SendPostRequest(_client, EndPoints.BasePath, searchData, ContentTypeConstants.FormUrlencoded);
        }
    }
}