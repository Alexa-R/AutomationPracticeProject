using System;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class ForgotPasswordPage
    {
        private WrapperWebElement RetrievePasswordButton => new WrapperWebElement(By.XPath("//*[@id='form_forgotpassword']//*[@type='submit']"));
        private WrapperWebElement VerificationCodeInputField => new WrapperWebElement(By.XPath("//*[@id='Ver_Code']"));
        private WrapperWebElement SubmitCodeButton => new WrapperWebElement(By.XPath("//*[@id='form_code']//*[@type='submit']"));
        private WrapperWebElement NewPasswordInputField => new WrapperWebElement(By.XPath("//*[@id='new_password']"));
        private WrapperWebElement NewPasswordAgainInputField => new WrapperWebElement(By.XPath("//*[@id='new_password_again']"));
        private WrapperWebElement SubmitNewPasswordButton => new WrapperWebElement(By.XPath("//*[@id='submit_new_password']"));
        
        public void ClickRetrievePasswordButton()
        {
            LogHelper.Info("Clicking on the Retrieve Password Button");
            RetrievePasswordButton.Click();
        }

        public string GetCodeFromMessage(string senderNickname, string userId)
        {
            var messageSnippet = GMailHelper.ReadLastInboxMessage(senderNickname, userId);
            var startWith = "following code";
            var substring = messageSnippet.Substring(messageSnippet.IndexOf(startWith, StringComparison.Ordinal) + startWith.Length);
            var orderConfirmationArray = substring.Trim().Split(new char[] { ' ', '.', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return orderConfirmationArray[0];
        }

        public void EnterVerificationCode(string code)
        {
            LogHelper.Info($"Entering of the Verification Code");
            VerificationCodeInputField.SendKeys(code);
        }

        public void ClickSubmitCodeButton()
        {
            LogHelper.Info("Clicking on the Submit Code Button");
            SubmitCodeButton.Click();
        }

        public void EnterNewPassword(string newPassword)
        {
            LogHelper.Info($"Entering of the New Password");
            NewPasswordInputField.SendKeys(newPassword);
        }

        public void EnterNewPasswordAgain(string newPassword)
        {
            LogHelper.Info($"Entering of the New Password Again");
            NewPasswordAgainInputField.SendKeys(newPassword);
        }

        public void ClickSubmitNewPasswordButton()
        {
            LogHelper.Info("Clicking on the Submit New Password Button");
            SubmitNewPasswordButton.Click();
        }
    }
}