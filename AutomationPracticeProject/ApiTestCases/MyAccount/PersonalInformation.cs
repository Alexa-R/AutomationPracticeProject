using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using NUnit.Framework;

namespace AutomationPracticeProject.ApiTestCases.MyAccount
{
    public class PersonalInformation : BaseApiTest
    {
        [Test, Category("Priority_Medium")]
        public void ChangeUserPersonalInformation()
        {
            var dayOfBirth = $"{RandomHelper.GetRandomNumbers(1, 31)}";
            var monthOfBirth = $"{RandomHelper.GetRandomNumbers(1, 12)}";
            var yearOfBirth = $"{RandomHelper.GetRandomNumbers(1900, 2021)}";

            var cookies = new CookieContainer();
            var cookie = new Cookie("PrestaShop-a30a9934ef476d11b6cc3c983616e364",
                "L%2BJQvWetG3%2BEW%2BGgWmgsK1LZmQZxDhy1TL%2BsTMTcSsQs7gEZnJM7eSv606R7WkAE0S8HaatQNEIoXKgSP14r0O%2F%2ByEguhMLyUtvbsNutQ0udEjKHkcjsIh7OKG2rcc5WwCoWajGCLpYM72Ei6mPI5DQijk2Avp157wund3MtK3hHFnKiWdH%2FlhYLu44T5re2aGkQviolSlDWWvNV%2F4ayZ30SkX0T8kNPdj%2B01Lh3KmlyNCs8A6C%2BMrAOcjknLbDm%2BF55EGzN9P9SiXYRlCep%2FxoAgmxaDOmjzH1BwMeHBO9oTSIvMvgRT03Vu52hGyAWMZIb814588lXpXgv2vSloUc4draz01aXBg2uAaBLgBkZZWTHJ34uAHVfPuR4C9aKNoEKrujbrOWDq%2FY%2Fki8%2FFUekERDTGUy3aOaWVaL9oMrAXP0VPOeP5aZwDO2WWUI21ZEPujMPLx6pES5G%2Bln0%2Fc5aWM9mRpCGuCI%2FHFUwpi61aFTj4b9pZcOqwP3Gz%2FAAQVMetvFn2QHl88trUBzDicmaf%2BmBcjzNc4BMr3JqJrzAEwM%2BTw5HtUXahAfYVXHGJRBFYmC9r%2BpXoW1w3hT%2FuonnAFR6XqooeoKgquD%2FGziCR9J4lF8Y3vjsD6T5P8BZ000466")
            {
                Domain = "automationpractice.com"
            };

            cookies.Add(cookie);
            var handler = new HttpClientHandler
            {
                CookieContainer = cookies
            };

            var client = new HttpClient(handler);

            var editProfileData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("controller", "identity"),
                    new KeyValuePair<string, string>("email", ConfigurationManager.AppSettings["Login"]),
                    new KeyValuePair<string, string>("days", dayOfBirth),
                    new KeyValuePair<string, string>("months", monthOfBirth),
                    new KeyValuePair<string, string>("years", yearOfBirth),
                    new KeyValuePair<string, string>("old_passwd", ConfigurationManager.AppSettings["Password"]),
                    new KeyValuePair<string, string>("submitIdentity", "")
                }
            );

            var response = ApiHelper.SendPostRequest(client, EndPoints.BasePath, editProfileData, ContentTypeConstants.FormUrlencoded);
            Console.WriteLine(response.Result.Content.ReadAsStringAsync().Result);
        }
    }
}