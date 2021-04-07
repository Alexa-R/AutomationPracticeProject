using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.TestCases;
using NUnit.Framework;

namespace AutomationPracticeProject.ApiTestCases.MyAccount
{
    public class MyAddresses : BaseTest
    {
        [Test, Category("Priority_High")]
        public void AddNewAddress()
        {
            var address = $"Address{RandomHelper.GetRandomString(8)}";
            var city = $"City{RandomHelper.GetRandomString(8)}";
            var zipCode = $"{RandomHelper.GetRandomNumbers(5)}";
            var mobilePhone = $"{RandomHelper.GetRandomNumbers(8)}";
            var addressAlias = $"AddressAlias{RandomHelper.GetRandomString(8)}";

            var cookies = ApiHelper.GetAuthCookie(_client);
            var handler = new HttpClientHandler
            {
                CookieContainer = cookies
            };

            _client = new HttpClient(handler);

            var newAddressData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("controller", "address"),
                    new KeyValuePair<string, string>("firstname", ConfigurationManager.AppSettings["FirstName"]),
                    new KeyValuePair<string, string>("lastname", ConfigurationManager.AppSettings["LastName"]),
                    new KeyValuePair<string, string>("address1", address),
                    new KeyValuePair<string, string>("city", city),
                    new KeyValuePair<string, string>("id_state", StatesDropdownConstants.Arizona),
                    new KeyValuePair<string, string>("postcode", zipCode),
                    new KeyValuePair<string, string>("id_country", CountriesDropdownConstants.UnitedStates),
                    new KeyValuePair<string, string>("phone_mobile", mobilePhone),
                    new KeyValuePair<string, string>("alias", addressAlias),
                    new KeyValuePair<string, string>("token", "265bbd54c379ac2cf6766c0c5c861367"),
                    new KeyValuePair<string, string>("submitAddress", "")
                }
            );

            ApiHelper.SendPostRequest(_client, EndPoints.BasePath, newAddressData, ContentTypeConstants.FormUrlencoded);
        }
    }
}