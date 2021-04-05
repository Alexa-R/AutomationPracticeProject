using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;

namespace AutomationPracticeProject.ApiTestCases.Authentication
{
    public class Login
    {
        [Test, Category("Priority_High")]
        public void LoginWithValidCredentials()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://automationpractice.com/index.php");
            var postData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("controller", "authentication"),
                    new KeyValuePair<string, string>("email", "lizy.flower22@gmail.com"),
                    new KeyValuePair<string, string>("passwd", "12345"),
                    new KeyValuePair<string, string>("SubmitLogin", "")
                }
            );
            request.Content = postData;
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = client.SendAsync(request);
            Console.WriteLine(response.Result.Content.ReadAsStringAsync().Result);
        }
    }
}