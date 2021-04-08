using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using AutomationPracticeProject.TestCases;
using FluentAssertions;
using NUnit.Framework;

namespace AutomationPracticeProject.ApiTestCases.Authentication
{
    public class Login : BaseTest
    {
        [Test, Category("Priority_High")]
        public void LoginWithValidCredentials()
        {
            LogHelper.Info("Trying to login via API");
            var loginData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("controller", "authentication"),
                    new KeyValuePair<string, string>("email", ConfigurationManager.AppSettings["Login"]),
                    new KeyValuePair<string, string>("passwd", ConfigurationManager.AppSettings["Password"]),
                    new KeyValuePair<string, string>("SubmitLogin", "")
                }
            );
            
            var response = ApiHelper.SendPostRequest(_client, EndPoints.BasePath, loginData, ContentTypeConstants.FormUrlencoded);

            var logOutButtonXpath = "//*[@class='logout']";
            var accountButtonXpath = "//*[@class='account']";
            HtmlAssertions.IsElementExistsOnHtmlPage(response.Result.Content.ReadAsStringAsync().Result, logOutButtonXpath).Should().BeTrue();
            HtmlAssertions.IsElementExistsOnHtmlPage(response.Result.Content.ReadAsStringAsync().Result, accountButtonXpath).Should().BeTrue();
        }

        [Test, Category("Priority_High")]
        public void RegistrationWithValidCredentials()
        {
            var registrationEmail = $"{RandomHelper.GetRandomStringWithNumbers(8)}@mail.ru";
            var firstName = $"FirstName{RandomHelper.GetRandomString(8)}";
            var lastName = $"LastName{RandomHelper.GetRandomString(8)}";
            var password = $"Password{RandomHelper.GetRandomStringWithNumbers(8)}";
            var address = $"Address{RandomHelper.GetRandomString(8)}";
            var city = $"City{RandomHelper.GetRandomString(8)}";
            var zipCode = $"{RandomHelper.GetRandomNumbers(5)}";
            var mobilePhone = $"{RandomHelper.GetRandomNumbers(8)}";
            var addressAlias = $"AddressAlias{RandomHelper.GetRandomString(8)}";

            LogHelper.Info("Trying to register user via API");
            var registrationData = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("controller", "authentication"),
                    new KeyValuePair<string, string>("customer_firstname", firstName),
                    new KeyValuePair<string, string>("customer_lastname", lastName),
                    new KeyValuePair<string, string>("email", registrationEmail),
                    new KeyValuePair<string, string>("passwd", password),
                    new KeyValuePair<string, string>("firstname", firstName),
                    new KeyValuePair<string, string>("lastname", lastName),
                    new KeyValuePair<string, string>("address1", address),
                    new KeyValuePair<string, string>("city", city),
                    new KeyValuePair<string, string>("id_state", StatesDropdownConstants.Arkansas),
                    new KeyValuePair<string, string>("postcode", zipCode),
                    new KeyValuePair<string, string>("id_country", CountriesDropdownConstants.UnitedStates),
                    new KeyValuePair<string, string>("phone_mobile", mobilePhone),
                    new KeyValuePair<string, string>("alias", addressAlias),
                    new KeyValuePair<string, string>("submitAccount", "")
                }
            );

            ApiHelper.SendPostRequest(_client, EndPoints.BasePath, registrationData, ContentTypeConstants.FormUrlencoded);
            
            Pages.BasePage.LogIn(registrationEmail, password);
            Pages.BasePage.IsSignOutButtonDisplayed().Should().BeTrue();
            Pages.BasePage.IsAccountButtonDisplayed().Should().BeTrue();
        }
    }
}