using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.TestCases.ApiTestCases;

namespace AutomationPracticeProject.Helpers
{
    public static class ApiHelper
    {
        public static Task<HttpResponseMessage> SendPostRequest(HttpClient client, string requestUri, HttpContent requestContent, string contentType)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) {Content = requestContent};
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            var response = client.SendAsync(request);
            return response;
        }

        public static CookieContainer GetAuthCookie(HttpClient client)
        {
            var loginData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("controller", "authentication"),
                    new KeyValuePair<string, string>("email", ConfigurationManager.AppSettings["Login"]),
                    new KeyValuePair<string, string>("passwd", ConfigurationManager.AppSettings["Password"]),
                    new KeyValuePair<string, string>("SubmitLogin", "")
                }
            );

            var response = ApiHelper.SendPostRequest(client, EndPoints.BasePath, loginData, ContentTypeConstants.FormUrlencoded);

            var cookies = new CookieContainer();
            var headerCookie = response.Result.Headers.GetValues("Set-Cookie").First();
            var array = headerCookie.Split(new char[] { '=', ';' });

            var authCookie = new Cookie(array[0], array[1])
            {
                Domain = "automationpractice.com"
            };

            cookies.Add(authCookie);

            return cookies;
        }
    }
}