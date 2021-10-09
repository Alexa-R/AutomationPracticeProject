using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class AuthenticationPage : BasePage
    {
        private WrapperWebElement EmailInputField => new WrapperWebElement(By.XPath("//*[@id='email']"));
        private WrapperWebElement PasswordInputField => new WrapperWebElement(By.XPath("//*[@id='passwd']"));
        private WrapperWebElement SignInButton => new WrapperWebElement(By.XPath("//*[@id='SubmitLogin']"));
        private WrapperWebElement RegistrationEmailInputField => new WrapperWebElement(By.XPath("//*[@id='email_create']"));
        private WrapperWebElement CreateAnAccountButton => new WrapperWebElement(By.XPath("//*[@id='SubmitCreate']"));
        private WrapperWebElement ForgotPasswordLink => new WrapperWebElement(By.XPath("//*[contains(@href,'password')]"));

        public void EnterEmail(string mail)
        {
            LogHelper.Info($"Entering of the Email '{mail}'");
            EmailInputField.SendKeys(mail);
        }

        public void EnterPassword(string password)
        {
            LogHelper.Info($"Entering of the Password '{password}'");
            PasswordInputField.SendKeys(password);
        }

        public void EnterRegistrationEmail(string mail)
        {
            LogHelper.Info($"Entering of the Registration Email '{mail}'");
            RegistrationEmailInputField.SendKeys(mail);
        }

        public void ClickCreateAnAccountButton()
        {
            LogHelper.Info("Clicking on the CreateAnAccount Button");
            CreateAnAccountButton.Click();
        }

        public void ClickSignInButton()
        {
            LogHelper.Info("Clicking on the SignIn Button");
            SignInButton.Click();
        }

        public void ClickForgotPasswordLink()
        {
            LogHelper.Info("Clicking on the Forgot Password Link");
            ForgotPasswordLink.Click();
        }
    }
}