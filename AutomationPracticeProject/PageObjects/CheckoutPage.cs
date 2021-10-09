using System;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class CheckoutPage : BasePage
    {
        private WrapperWebElement ProceedToCheckoutButton => new WrapperWebElement(By.XPath("//*[@class='cart_navigation clearfix']//*[@title='Proceed to checkout']"));
        private WrapperWebElement SubmitAddressProceedToCheckoutButton => new WrapperWebElement(By.XPath("//*[@class='cart_navigation clearfix']//*[@type='submit']"));
        private WrapperWebElement TermsOfServiceAgreementCheckBox => new WrapperWebElement(By.XPath("//*[@id='uniform-cgv']"));
        private WrapperWebElement PayByBankWireButton => new WrapperWebElement(By.XPath("//*[@class='bankwire']"));
        private WrapperWebElement PayByCheckButton => new WrapperWebElement(By.XPath("//*[@class='cheque']"));
        private WrapperWebElement IConfirmMyOrderButton => new WrapperWebElement(By.XPath("//*[@id='cart_navigation']//*[@type='submit']"));
        private WrapperWebElement OrderConfirmationTitle => new WrapperWebElement(By.XPath("//*[@class='cheque-indent']"));
        private WrapperWebElement OrderConfirmationBox => new WrapperWebElement(By.XPath("//*[@class='box order-confirmation']"));
        private WrapperWebElement SuccessAlert => new WrapperWebElement(By.XPath("//*[@class='alert alert-success']"));
        private WrapperWebElement WarningAlert => new WrapperWebElement(By.XPath("//*[@class='alert alert-warning']"));
        private WrapperWebElement AddNewAddressButton => new WrapperWebElement(By.XPath("//*[@title='Add']"));
        private WrapperWebElement EqualityAddressesCheckBox => new WrapperWebElement(By.XPath("//*[@id='uniform-addressesAreEquals']"));
        private WrapperWebElement LastProductTitle => new WrapperWebElement(By.XPath("//*[contains(@class,'last_item')]//*[@class='product-name']"));
        private WrapperWebElement LastProductTrashButton => new WrapperWebElement(By.XPath("//*[contains(@class,'last_item')]//*[@class='cart_quantity_delete']"));

        public void ClickProceedToCheckoutButton()
        {
            LogHelper.Info("Clicking on the ProceedToCheckout Button");
            ProceedToCheckoutButton.Click();
        }

        public void ClickSubmitProceedToCheckoutButton()
        {
            LogHelper.Info("Clicking on the Submit Address Proceed To Checkout Button");
            SubmitAddressProceedToCheckoutButton.Click();
        }

        public void ClickTermsOfServiceAgreementCheckBox()
        {
            LogHelper.Info("Clicking on the Terms Of Service Agreement CheckBox");
            TermsOfServiceAgreementCheckBox.Click();
        }

        public void ClickPayByBankWireButton()
        {
            LogHelper.Info("Clicking on the Pay By Bank Wire Button");
            PayByBankWireButton.Click();
        }

        public void ClickPayByCheckButton()
        {
            LogHelper.Info("Clicking on the Pay By Check Button");
            PayByCheckButton.Click();
        }

        public void ClickIConfirmMyOrderButton()
        {
            LogHelper.Info("Clicking on the I Confirm My Order Button");
            IConfirmMyOrderButton.Click();
        }

        public string GetOrderConfirmationTitleText()
        {
            LogHelper.Info("Getting the Order Confirmation Title Text");
            return OrderConfirmationTitle.Text;
        }

        public bool IsSuccessAlertDisplayed()
        {
            LogHelper.Info("Checking the display of the SuccessAlert");
            return SuccessAlert.Displayed;
        }

        public string GetWarningAlertText()
        {
            LogHelper.Info("Getting of Warning Alert Text");
            WarningAlert.WaitForElementIsStale();
            return WarningAlert.Text;
        }

        public void ClickAddNewAddressButton()
        {
            LogHelper.Info("Clicking on the Add New Address Button");
            AddNewAddressButton.Click();
        }

        public void ClickEqualityAddressesCheckBox()
        {
            LogHelper.Info("Clicking on the Equality Addresses CheckBox");
            EqualityAddressesCheckBox.Click();
        }

        public void ClickAddressFromDropdown(string dropdownName, string addressName)
        {
            LogHelper.Info($"Clicking on the {addressName} from {dropdownName} Dropdown Menu");
            new WrapperWebElement(By.XPath($"//*[@id='{dropdownName}']//*[contains(text(),'{addressName}')]")).Click();
        }

        public string GetOrderReference()
        {
            LogHelper.Info("Getting the Order Reference");
            var orderConfirmationText = OrderConfirmationBox.Text;
            var startWith = "reference";
            var substring = orderConfirmationText.Substring(orderConfirmationText.IndexOf(startWith, StringComparison.Ordinal) + startWith.Length);
            var orderConfirmationArray = substring.Trim().Split(new char[] { ' ', '.', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return orderConfirmationArray[0];
        }

        public string GetLastProductTitleText()
        {
            LogHelper.Info("Getting the Last Product Title");
            return LastProductTitle.Text;
        }

        public void ClickLastProductTrashButton()
        {
            LogHelper.Info("Clicking on the Last Product Trash Button");
            LastProductTrashButton.Click();
        }
    }
}