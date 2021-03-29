using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class MyWishListsPage
    {
        private WrapperWebElement NameInputField => new WrapperWebElement(By.XPath("//*[@id='name']"));
        private WrapperWebElement SaveButton => new WrapperWebElement(By.XPath("//*[@id='submitWishlist']"));
        private WrapperWebElement WishListsTable => new WrapperWebElement(By.XPath("//*[@id='block-history']"));

        public void EnterWishListName(string wishListName)
        {
            LogHelper.Info($"Entering of the Last Name");
            NameInputField.SendKeys(wishListName);
        }

        public void ClickSaveButton()
        {
            LogHelper.Info("Clicking on the Save Button");
            SaveButton.Click();
        }

        public string GetWishListsTableText()
        {
            return WishListsTable.Text;
        }
    }
}