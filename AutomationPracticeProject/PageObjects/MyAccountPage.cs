using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class MyAccountPage : BasePage
    {
        private WrapperWebElement MyPersonalInformationButton => new WrapperWebElement(By.XPath("//*[@title='Information']"));
        private WrapperWebElement MyAddressesButton => new WrapperWebElement(By.XPath("//*[@title='Addresses']"));
        private WrapperWebElement MyWishListsButton => new WrapperWebElement(By.XPath("//*[@title='My wishlists']"));
        private WrapperWebElement HomeButton => new WrapperWebElement(By.XPath("//*[@title='Home']"));
        private WrapperWebElement OrderHistoryAndDetailsButton => new WrapperWebElement(By.XPath("//*[@title='Orders']"));

        public void ClickMyPersonalInformationButton()
        {
            LogHelper.Info("Clicking on the My Personal Information Button");
            MyPersonalInformationButton.Click();
        }

        public void ClickMyAddressesButton()
        {
            LogHelper.Info("Clicking on the My Addresses Button");
            MyAddressesButton.Click();
        }

        public void ClickMyWishListsButton()
        {
            LogHelper.Info("Clicking on the My WishLists Button");
            MyWishListsButton.Click();
        }

        public void ClickHomeButton()
        {
            LogHelper.Info("Clicking on the Home Button");
            HomeButton.Click();
        }

        public void ClickOrderHistoryAndDetailsButton()
        {
            LogHelper.Info("Clicking on the Order History And Details Button");
            OrderHistoryAndDetailsButton.Click();
        }
    }
}