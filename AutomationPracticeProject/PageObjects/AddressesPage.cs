using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class AddressesPage : BasePage
    {
        private WrapperWebElement AddNewAddressButton => new WrapperWebElement(By.XPath("//*[@title='Add an address']"));
        private WrapperWebElement LastAddressCard => new WrapperWebElement(By.XPath("//*[contains(@class,'last_item') and contains(@class,'item box')]"));
        private WrapperWebElement LastAddressCardUpdateButton => new WrapperWebElement(By.XPath("//*[contains(@class,'last_item') and contains(@class,'item box')]//*[@title='Update']"));

        public void ClickAddNewAddressButton()
        {
            LogHelper.Info("Clicking on the Add New Address Button");
            AddNewAddressButton.Click();
        }

        public string GetLastAddressCardText()
        {
            LogHelper.Info("Getting the Last Address Card Text");
            return LastAddressCard.Text;
        }

        public void ClickLastAddressCardUpdateButton()
        {
            LogHelper.Info("Clicking on the Last Address Card Update Button");
            LastAddressCardUpdateButton.Click();
        }
    }
}