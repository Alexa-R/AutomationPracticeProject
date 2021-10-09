using System.Configuration;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.UserFlow
{
    public class Checkout : BaseTest
    {
        private string _address = $"Address{RandomHelper.GetRandomString(8)}";
        private string _city = $"City{RandomHelper.GetRandomString(8)}";
        private string _zipCode = $"{RandomHelper.GetRandomNumbers(5)}";
        private string _mobilePhone = $"{RandomHelper.GetRandomNumbers(8)}";
        private string _addressAlias = $"AddressAlias{RandomHelper.GetRandomString(8)}";

        [Test, Category("Priority_High")]
        public void CheckoutUsingBankWire()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickHomeButton();
            Pages.HomePage.MoveToProductCard(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickTermsOfServiceAgreementCheckBox();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickPayByBankWireButton();
            Pages.CheckoutPage.ClickIConfirmMyOrderButton();
            Assert.That(Pages.CheckoutPage.GetOrderConfirmationTitleText(), Contains.Substring("is complete"));
        }

        [Test, Category("Priority_High")]
        public void CheckoutUsingCheck()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickHomeButton();
            Pages.HomePage.MoveToProductCard(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickTermsOfServiceAgreementCheckBox();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickPayByCheckButton();
            Pages.CheckoutPage.ClickIConfirmMyOrderButton();
            Assert.IsTrue(Pages.CheckoutPage.IsSuccessAlertDisplayed());
        }

        [Test, Category("Priority_Medium")]
        public void CheckoutWithDeliveryAddressCreationOnCheckoutStep()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickHomeButton();
            Pages.HomePage.MoveToProductCard(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickEqualityAddressesCheckBox();
            Pages.CheckoutPage.ClickAddNewAddressButton();
            Pages.AddressForm.CreateNewAddress(_address, _city, StatesDropdownConstants.Alabama, _zipCode, CountriesDropdownConstants.UnitedStates, _mobilePhone, _addressAlias);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.DeliveryAddressDropdown);
            Pages.CheckoutPage.ClickAddressFromDropdown(DropdownNamesConstants.DeliveryAddressDropdown, _addressAlias);
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickTermsOfServiceAgreementCheckBox();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickPayByCheckButton();
            Pages.CheckoutPage.ClickIConfirmMyOrderButton();
            Assert.IsTrue(Pages.CheckoutPage.IsSuccessAlertDisplayed());

            Pages.BasePage.ClickAccountButton();
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressesPage.DeleteLastAddress();
        }

        [Test, Category("Priority_Medium")]
        public void CheckoutWithBillingAddressCreationOnCheckoutStep()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickHomeButton();
            Pages.HomePage.MoveToProductCard(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickProceedToCheckoutButton();
            Pages.CheckoutPage.ClickEqualityAddressesCheckBox();
            Pages.CheckoutPage.ClickAddNewAddressButton();
            Pages.AddressForm.CreateNewAddress(_address, _city, StatesDropdownConstants.Alabama, _zipCode, CountriesDropdownConstants.UnitedStates, _mobilePhone, _addressAlias);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.BillingAddressDropdown);
            Pages.CheckoutPage.ClickAddressFromDropdown(DropdownNamesConstants.BillingAddressDropdown, _addressAlias);
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickTermsOfServiceAgreementCheckBox();
            Pages.CheckoutPage.ClickSubmitProceedToCheckoutButton();
            Pages.CheckoutPage.ClickPayByCheckButton();
            Pages.CheckoutPage.ClickIConfirmMyOrderButton();
            Assert.IsTrue(Pages.CheckoutPage.IsSuccessAlertDisplayed());

            Pages.BasePage.ClickAccountButton();
            Pages.MyAccountPage.ClickMyAddressesButton();
            Pages.AddressesPage.DeleteLastAddress();
        }
    }
}