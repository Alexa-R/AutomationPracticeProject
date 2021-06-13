using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class MyWishListsPage : BasePage
    {
        private WrapperWebElement NameInputField => new WrapperWebElement(By.XPath("//*[@id='name']"));
        private WrapperWebElement SaveButton => new WrapperWebElement(By.XPath("//*[@id='submitWishlist']"));
        private WrapperWebElement WishListsTable => new WrapperWebElement(By.XPath("//*[@id='block-history']"));
        private WrapperWebElement EditButton => new WrapperWebElement(By.XPath("//*[@id='editWishlist']"));
        private WrapperWebElement NewNameInputField => new WrapperWebElement(By.XPath("//*[@id='NewNameInput']"));
        private WrapperWebElement SaveChangesButton => new WrapperWebElement(By.XPath("//*[@id='SubmitWishlistChanges']"));

        public void EnterWishListName(string wishListName)
        {
            LogHelper.Info($"Entering of the Wishlist Name");
            NameInputField.SendKeys(wishListName);
        }

        public void ClickSaveButton()
        {
            LogHelper.Info("Clicking on the Save Button");
            SaveButton.Click();
        }

        public string GetWishListsTableText()
        {
            LogHelper.Info("Getting the WishLists Table Text");
            return WishListsTable.Text;
        }
        
        public void ClickWishListDeleteButton(string wishListName)
        {
            LogHelper.Info("Clicking on the WishList Delete Button");
            new WrapperWebElement(By.XPath($"//tr[.//*[contains(text(),'{wishListName}')]]//*[@class='icon-remove']")).Click();
        }
        
        public void CreateWishList(string wishListName)
        {
            EnterWishListName(wishListName);
            ClickSaveButton();
        }

        public void DeleteWishList(string wishListName)
        {
            ClickWishListDeleteButton(wishListName);
            Pages.BasePage.AcceptAlert();
        }

        public void ClickWishList(string wishListName)
        {
            LogHelper.Info("Clicking on the WishList");
            new WrapperWebElement(By.XPath($"//*[contains(text(),'{wishListName}')]")).Click();
        }

        public void ClickEditButton()
        {
            LogHelper.Info("Clicking on the Edit Button");
            EditButton.Click();
        }

        public void EnterNewWishListName(string wishListName)
        {
            LogHelper.Info($"Entering of the new Wishlist Name");
            NewNameInputField.SendKeys(wishListName);
        }

        public void ClickSaveChangesButton()
        {
            LogHelper.Info("Clicking on the Save Changes Button");
            SaveChangesButton.Click();
        }
    }
}