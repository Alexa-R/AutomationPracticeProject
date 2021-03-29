using System.Configuration;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.Authentication
{
    public class Login : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Assert.IsTrue(Pages.BasePage.IsSignOutButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsAccountButtonDisplayed());
        }

        [Test]
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

            Pages.BasePage.ClickSignInButton();
            Pages.AuthenticationPage.EnterRegistrationEmail(registrationEmail);
            Pages.AuthenticationPage.ClickCreateAnAccountButton();
            Pages.RegistrationPage.EnterFirstName(firstName);
            Pages.RegistrationPage.EnterLastName(lastName);
            Pages.RegistrationPage.EnterPassword(password);
            Pages.RegistrationPage.EnterAddress(address);
            Pages.RegistrationPage.EnterCity(city);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.StateDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.StateDropdown, StatesDropdownConstants.Alabama);
            Pages.RegistrationPage.EnterZipCode(zipCode);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.CountryDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.CountryDropdown, CountriesDropdownConstants.UnitedStates);
            Pages.RegistrationPage.EnterMobilePhone(mobilePhone);
            Pages.RegistrationPage.ClearAddressAliasInputField();
            Pages.RegistrationPage.EnterAddressAlias(addressAlias);
            Pages.RegistrationPage.ClickRegisterButton();
            Assert.IsTrue(Pages.BasePage.IsSignOutButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsAccountButtonDisplayed());
        }
    }
}