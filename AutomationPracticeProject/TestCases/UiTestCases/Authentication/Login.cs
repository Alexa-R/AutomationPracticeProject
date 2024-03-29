﻿using System.Configuration;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.Authentication
{
    public class Login : BaseTest
    {
        [Test, Category("High")]
        public void LoginWithValidCredentials()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Assert.IsTrue(Pages.BasePage.IsSignOutButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsAccountButtonDisplayed());
        }

        [Test, Category("High")]
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
            Pages.RegistrationForm.EnterFirstName(firstName);
            Pages.RegistrationForm.EnterLastName(lastName);
            Pages.RegistrationForm.EnterPassword(password);
            Pages.RegistrationForm.EnterAddress(address);
            Pages.RegistrationForm.EnterCity(city);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.StateDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.StateDropdown, StatesDropdownConstants.Alabama);
            Pages.RegistrationForm.EnterZipCode(zipCode);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.CountryDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.CountryDropdown, CountriesDropdownConstants.UnitedStates);
            Pages.RegistrationForm.EnterMobilePhone(mobilePhone);
            Pages.RegistrationForm.ClearAddressAliasInputField();
            Pages.RegistrationForm.EnterAddressAlias(addressAlias);
            Pages.RegistrationForm.ClickRegisterButton();
            Assert.IsTrue(Pages.BasePage.IsSignOutButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsAccountButtonDisplayed());
        }

        [Test, Category("Medium")]
        public void PasswordRecovery()
        {
            var newPassword = $"{RandomHelper.GetRandomStringWithNumbers(8)}@mail.ru";

            Pages.BasePage.ClickSignInButton();
            Pages.AuthenticationPage.ClickForgotPasswordLink();
            Pages.AuthenticationPage.EnterEmail(ConfigurationManager.AppSettings["Login"]);
            Pages.ForgotPasswordPage.ClickRetrievePasswordButton();
            var code = Pages.ForgotPasswordPage.GetCodeFromMessage("Lizy Flower", "me");
            Pages.ForgotPasswordPage.EnterVerificationCode(code);
            Pages.ForgotPasswordPage.ClickSubmitCodeButton();
            Pages.ForgotPasswordPage.EnterNewPassword("password");
            Pages.ForgotPasswordPage.EnterNewPasswordAgain("password");
            Pages.ForgotPasswordPage.ClickSubmitNewPasswordButton();
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], newPassword);
            Assert.IsTrue(Pages.BasePage.IsSignOutButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsAccountButtonDisplayed());
        }
    }
}