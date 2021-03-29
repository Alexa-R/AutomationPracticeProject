using System.Configuration;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.MyAccount
{
    public class MyAddresses : BaseTest
    {
        [Test]
        public void AddNewAddress()
        {
            var address = $"Address{RandomHelper.GetRandomString(8)}";
            var city = $"City{RandomHelper.GetRandomString(8)}";
            var zipCode = $"{RandomHelper.GetRandomNumbers(5)}";
            var mobilePhone = $"{RandomHelper.GetRandomNumbers(8)}";
            var addressAlias = $"AddressAlias{RandomHelper.GetRandomString(8)}";

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressPage.ClickAddNewAddressButton();
            Pages.AddressPage.CreateNewAddress(address, city, StatesDropdownConstants.Alabama, zipCode, CountriesDropdownConstants.UnitedStates, mobilePhone, addressAlias);
            Assert.AreEqual(addressAlias.ToUpper(), Pages.AddressPage.GetLastAddressCardTitleText());
        }
    }
}