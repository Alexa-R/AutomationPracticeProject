using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class RegistrationForm : BasePage
    {
        private WrapperWebElement FirstNameInputField => new WrapperWebElement(By.XPath("//*[@id='customer_firstname']"));
        private WrapperWebElement LastNameInputField => new WrapperWebElement(By.XPath("//*[@id='customer_lastname']"));
        private WrapperWebElement PasswordInputField => new WrapperWebElement(By.XPath("//*[@id='passwd']"));
        private WrapperWebElement AddressInputField => new WrapperWebElement(By.XPath("//*[@id='address1']"));
        private WrapperWebElement CityInputField => new WrapperWebElement(By.XPath("//*[@id='city']"));
        private WrapperWebElement ZipCodeInputField => new WrapperWebElement(By.XPath("//*[@id='postcode']"));
        private WrapperWebElement MobilePhoneInputField => new WrapperWebElement(By.XPath("//*[@id='phone_mobile']"));
        private WrapperWebElement AddressAliasInputField => new WrapperWebElement(By.XPath("//*[@id='alias']"));
        private WrapperWebElement RegisterButton => new WrapperWebElement(By.XPath("//*[@id='submitAccount']"));

        public void EnterFirstName(string firstName)
        {
            LogHelper.Info($"Entering of the First Name '{firstName}'");
            FirstNameInputField.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            LogHelper.Info($"Entering of the Last Name '{lastName}'");
            LastNameInputField.SendKeys(lastName);
        }

        public void EnterPassword(string password)
        {
            LogHelper.Info($"Entering of the Password '{password}'");
            PasswordInputField.SendKeys(password);
        }

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

        public void ClickRegisterButton()
        {
            LogHelper.Info("Clicking on the Register Button");
            RegisterButton.Click();
        }
    }
}