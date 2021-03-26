using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class BasePage
    {
        private WrapperWebElement SignInButton => new WrapperWebElement(By.XPath("//*[@class='login']"));
        private WrapperWebElement SignOutButton => new WrapperWebElement(By.XPath("//*[@class='logout']"));
        private WrapperWebElement ContactUsButton => new WrapperWebElement(By.XPath("//*[@id='contact-link']"));
        private WrapperWebElement AccountButton => new WrapperWebElement(By.XPath("//*[@class='account']"));

        public void ClickSignInButton()
        {
            LogHelper.Info("Clicking on the Sign In Button");
            SignInButton.Click();
        }

        public bool IsSignOutButtonDisplayed()
        {
            LogHelper.Info("Checking the display of the Sign Out Button");
            return SignOutButton.Displayed;
        }

        public bool IsContactUsButtonDisplayed()
        {
            LogHelper.Info("Checking the display of the Contact Us Button");
            return ContactUsButton.Displayed;
        }

        public bool IsAccountButtonDisplayed()
        {
            LogHelper.Info("Checking the display of the Account Button");
            return AccountButton.Displayed;
        }

        public void LogIn(string login, string password)
        {
            Pages.BasePage.ClickSignInButton();
            Pages.AuthenticationPage.EnterEmail(login);
            Pages.AuthenticationPage.EnterPassword(password);
            Pages.AuthenticationPage.ClickSignInButton();
        }
    }
}