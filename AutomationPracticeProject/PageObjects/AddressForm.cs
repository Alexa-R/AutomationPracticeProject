using AutomationPracticeProject.Constants;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class AddressForm : BasePage
    {
        private WrapperWebElement AddressInputField => new WrapperWebElement(By.XPath("//*[@id='address1']"));
        private WrapperWebElement CityInputField => new WrapperWebElement(By.XPath("//*[@id='city']"));
        private WrapperWebElement ZipCodeInputField => new WrapperWebElement(By.XPath("//*[@id='postcode']"));
        private WrapperWebElement MobilePhoneInputField => new WrapperWebElement(By.XPath("//*[@id='phone_mobile']"));
        private WrapperWebElement AddressAliasInputField => new WrapperWebElement(By.XPath("//*[@id='alias']"));
        private WrapperWebElement SaveButton => new WrapperWebElement(By.XPath("//*[@id='submitAddress']"));
        
        public void EnterAddress(string address)
        {
            LogHelper.Info($"Entering of the Address '{address}'");
            AddressInputField.SendKeys(address);
        }

        public void EnterCity(string city)
        {
            LogHelper.Info($"Entering of the City '{city}'");
            CityInputField.SendKeys(city);
        }

        public void EnterZipCode(string zipCode)
        {
            LogHelper.Info($"Entering of the Zip Code '{zipCode}'");
            ZipCodeInputField.SendKeys(zipCode);
        }

        public void EnterMobilePhone(string mobilePhone)
        {
            LogHelper.Info($"Entering of the Mobile Phone '{mobilePhone}'");
            MobilePhoneInputField.SendKeys(mobilePhone);
        }

        public void EnterAddressAlias(string addressAlias)
        {
            LogHelper.Info($"Entering of the Address Alias '{addressAlias}'");
            AddressAliasInputField.SendKeys(addressAlias);
        }

        public void ClearAddressAliasInputField()
        {
            LogHelper.Info($"Clearing of the Address Alias Input Field");
            AddressAliasInputField.Clear();
        }

        public void ClickSaveButton()
        {
            LogHelper.Info("Clicking on the Save Button");
            SaveButton.Click();
        }

        public void CreateNewAddress(string address, string city,  string state, string zipCode, string country, string mobilePhone, string addressAlias)
        {
            EnterAddress(address);
            EnterCity(city);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.StateDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.StateDropdown, state);
            EnterZipCode(zipCode);
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.CountryDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.CountryDropdown, country);
            EnterMobilePhone(mobilePhone);
            ClearAddressAliasInputField();
            EnterAddressAlias(addressAlias);
            ClickSaveButton();
        }
    }
}