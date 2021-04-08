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
    public class PersonalInformation : BaseTest
    {
        [Test, Category("Priority_Medium")]
        public void ChangeUserPersonalInformation()
        {
            var dayOfBirth = $"{RandomHelper.GetRandomNumbers(1, 31)}";
            var monthOfBirth = $"{RandomHelper.GetRandomNumbers(1, 12)}";
            var yearOfBirth = $"{RandomHelper.GetRandomNumbers(1900, 2021)}";

            LogHelper.Info("Trying to change user personal information via API");
            var cookies = ApiHelper.GetAuthCookie(_client);
            var handler = new HttpClientHandler
            {
                CookieContainer = cookies
            };

            _client = new HttpClient(handler);

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

            ApiHelper.SendPostRequest(_client, EndPoints.BasePath, editProfileData, ContentTypeConstants.FormUrlencoded);

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyPersonalInformationButton();
            Pages.PersonalInformationForm.GetDaysDropdownSelectedValue().Should().BeEquivalentTo(dayOfBirth);
            Pages.PersonalInformationForm.GetMonthDropdownSelectedValue().Should().BeEquivalentTo(monthOfBirth);
            Pages.PersonalInformationForm.GetYearsDropdownSelectedValue().Should().BeEquivalentTo(yearOfBirth);
        }
    }
}