using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using AutomationPracticeProject.WrapperFactory;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class BasePage
    {
        private WrapperWebElement SignInButton => new WrapperWebElement(By.XPath("//*[@class='login']"));
        private WrapperWebElement SignOutButton => new WrapperWebElement(By.XPath("//*[@class='logout']"));
        private WrapperWebElement ContactUsButton => new WrapperWebElement(By.XPath("//*[@id='contact-link']"));
        private WrapperWebElement AccountButton => new WrapperWebElement(By.XPath("//*[@class='account']"));
        private WrapperWebElement SearchInputField => new WrapperWebElement(By.XPath("//*[@id='search_query_top']"));

        public void ClickSignInButton()
        {
            LogHelper.Info("Clicking on the SignIn Button");
            SignInButton.Click();
        }

        public void ClickSignOutButton()
        {
            LogHelper.Info("Clicking on the SignOut Button");
            SignOutButton.Click();
        }

        public void ClickContactUsButton()
        {
            LogHelper.Info("Clicking on the ContactUs Button");
            ContactUsButton.Click();
        }

        public bool IsSignInButtonDisplayed()
        {
            LogHelper.Info("Checking the display of the SignIn Button");
            return SignInButton.Displayed;
        }

        public bool IsSignOutButtonDisplayed()
        {
            LogHelper.Info("Checking the display of the SignOut Button");
            return SignOutButton.Displayed;
        }
        
        public bool IsAccountButtonDisplayed()
        {
            LogHelper.Info("Checking the display of the Account Button");
            return AccountButton.Displayed;
        }

        public void ClickAccountButton()
        {
            LogHelper.Info("Clicking on the Account Button");
            AccountButton.Click();
        }

        public void ClickDropdown(string dropdownName)
        {
            LogHelper.Info($"Clicking on the {dropdownName} Dropdown Menu");
            new WrapperWebElement(By.XPath($"//*[@id='id_{dropdownName}']")).Click();
        }

        public void ClickOptionFromDropdown(string dropdownName, string option)
        {
            LogHelper.Info($"Clicking on the {option} from {dropdownName} Dropdown Menu");
            new WrapperWebElement(By.XPath($"//*[@id='id_{dropdownName}']//*[@value='{option}']")).Click();
        }

        public void LogIn(string login, string password)
        {
            ClickSignInButton();
            Pages.AuthenticationPage.EnterEmail(login);
            Pages.AuthenticationPage.EnterPassword(password);
            Pages.AuthenticationPage.ClickSignInButton();
        }

        public string GetAccountButtonText()
        {
            LogHelper.Info("Getting the Account Button Title");
            return AccountButton.Text;
        }

        public void AcceptAlert()
        {
            LogHelper.Info("Accepting of Alert");
            WebDriverFactory.Driver.SwitchTo().Alert().Accept();
        }

        public void ClickItemFromSearchResultPopup(int resultItemIndex)
        {
            LogHelper.Info("Clicking on the WishList Delete Button");
            new WrapperWebElement(By.XPath($"//*[@class='ac_results']//li[{resultItemIndex}]")).Click();
        }

        public string GetItemFromSearchResultPopupText(int resultItemIndex)
        {
            LogHelper.Info("Getting the Result Popup Text");
            return new WrapperWebElement(By.XPath($"//*[@class='ac_results']//li[{resultItemIndex}]")).Text;
        }

        public void EnterItemInSearchInputField(string itemName)
        {
            LogHelper.Info($"Searching for '{itemName}' in search input field");
            SearchInputField.SendKeys(itemName);
        }

        public void KeyEnter()
        {
            SearchInputField.SendKeys(Keys.Enter);
        }

        public void ClickProductCategoryButton(string categoryName)
        {
            LogHelper.Info($"Clicking on the {categoryName} category button");
            new WrapperWebElement(By.XPath($"//*[contains(@class,'sf-menu')]/li/*[@title='{categoryName}']")).Click();
        }
    }
}