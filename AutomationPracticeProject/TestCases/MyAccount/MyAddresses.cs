using System.Configuration;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.MyAccount
{
    public class MyAddresses : BaseTest
    {
        private string address = $"Address{RandomHelper.GetRandomString(8)}";
        private string city = $"City{RandomHelper.GetRandomString(8)}";
        private string zipCode = $"{RandomHelper.GetRandomNumbers(5)}";
        private string mobilePhone = $"{RandomHelper.GetRandomNumbers(8)}";
        private string addressAlias = $"AddressAlias{RandomHelper.GetRandomString(8)}";

        [Test, Category("PriorityA")]
        public void AddNewAddress()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressesPage.ClickAddNewAddressButton();
            Pages.AddressForm.CreateNewAddress(address, city, StatesDropdownConstants.Alabama, zipCode, CountriesDropdownConstants.UnitedStates, mobilePhone, addressAlias);
            Assert.That(Pages.AddressesPage.GetLastAddressCardText(), Contains.Substring(addressAlias.ToUpper()));

            Pages.AddressesPage.DeleteLastAddress();
        }

        [Test, Category("PriorityB")]
        public void EditAddress()
        {
            var updateCity = $"UpdateCity{RandomHelper.GetRandomString(8)}";

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressesPage.ClickAddNewAddressButton();
            Pages.AddressForm.CreateNewAddress(address, city, StatesDropdownConstants.Alabama, zipCode, CountriesDropdownConstants.UnitedStates, mobilePhone, addressAlias);
            Pages.AddressesPage.ClickLastAddressCardUpdateButton();
            Pages.AddressForm.EnterCity(updateCity);
            Pages.AddressForm.ClickSaveButton();
            Assert.That(Pages.AddressesPage.GetLastAddressCardText(), Contains.Substring(updateCity));

            Pages.AddressesPage.DeleteLastAddress();
        }

        [Test, Category("PriorityC")]
        public void DeleteAddress()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressesPage.ClickAddNewAddressButton();
            Pages.AddressForm.CreateNewAddress(address, city, StatesDropdownConstants.Alabama, zipCode, CountriesDropdownConstants.UnitedStates, mobilePhone, addressAlias);
            Pages.AddressesPage.DeleteLastAddress();
            Assert.That(Pages.AddressesPage.GetLastAddressCardText(), !Contains.Substring(addressAlias.ToUpper()));
        }
    }
}