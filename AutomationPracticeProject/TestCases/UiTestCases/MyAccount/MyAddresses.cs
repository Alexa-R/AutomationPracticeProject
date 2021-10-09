using System.Configuration;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.MyAccount
{
    public class MyAddresses : BaseTest
    {
        private string _address = $"Address{RandomHelper.GetRandomString(8)}";
        private string _city = $"City{RandomHelper.GetRandomString(8)}";
        private string _zipCode = $"{RandomHelper.GetRandomNumbers(5)}";
        private string _mobilePhone = $"{RandomHelper.GetRandomNumbers(8)}";
        private string _addressAlias = $"AddressAlias{RandomHelper.GetRandomString(8)}";

        [Test, Category("High")]
        public void AddNewAddress()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressesPage.ClickAddNewAddressButton();
            Pages.AddressForm.CreateNewAddress(_address, _city, StatesDropdownConstants.Alabama, _zipCode, CountriesDropdownConstants.UnitedStates, _mobilePhone, _addressAlias);
            Assert.That(Pages.AddressesPage.GetLastAddressCardText(), Contains.Substring(_addressAlias.ToUpper()));

            Pages.AddressesPage.DeleteLastAddress();
        }

        [Test, Category("Medium")]
        public void EditAddress()
        {
            var updateCity = $"UpdateCity{RandomHelper.GetRandomString(8)}";

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressesPage.ClickAddNewAddressButton();
            Pages.AddressForm.CreateNewAddress(_address, _city, StatesDropdownConstants.Alabama, _zipCode, CountriesDropdownConstants.UnitedStates, _mobilePhone, _addressAlias);
            Pages.AddressesPage.ClickLastAddressCardUpdateButton();
            Pages.AddressForm.EnterCity(updateCity);
            Pages.AddressForm.ClickSaveButton();
            Assert.That(Pages.AddressesPage.GetLastAddressCardText(), Contains.Substring(updateCity));

            Pages.AddressesPage.DeleteLastAddress();
        }

        [Test, Category("Medium")]
        public void DeleteAddress()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressesPage.ClickAddNewAddressButton();
            Pages.AddressForm.CreateNewAddress(_address, _city, StatesDropdownConstants.Alabama, _zipCode, CountriesDropdownConstants.UnitedStates, _mobilePhone, _addressAlias);
            Pages.AddressesPage.DeleteLastAddress();
            Assert.That(Pages.AddressesPage.GetLastAddressCardText(), !Contains.Substring(_addressAlias.ToUpper()));
        }
    }
}