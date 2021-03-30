﻿using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class CheckoutPage
    {
        private WrapperWebElement ProceedToCheckoutButton => new WrapperWebElement(By.XPath("//*[@class='cart_navigation clearfix']//*[@title='Proceed to checkout']"));
        private WrapperWebElement SubmitAddressProceedToCheckoutButton => new WrapperWebElement(By.XPath("//*[@class='cart_navigation clearfix']//*[@type='submit']"));
        private WrapperWebElement TermsOfServiceAgreementCheckBox => new WrapperWebElement(By.XPath("//*[@id='uniform-cgv']"));
        private WrapperWebElement PayByBankWireButton => new WrapperWebElement(By.XPath("//*[@class='bankwire']"));
        private WrapperWebElement PayByCheckButton => new WrapperWebElement(By.XPath("//*[@class='cheque']"));
        private WrapperWebElement IConfirmMyOrderButton => new WrapperWebElement(By.XPath("//*[@id='cart_navigation']//*[@type='submit']"));
        private WrapperWebElement OrderConfirmationTitle => new WrapperWebElement(By.XPath("//*[@class='cheque-indent']"));
        private WrapperWebElement SuccessAlert => new WrapperWebElement(By.XPath("//*[@class='alert alert-success']"));

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
    }
}