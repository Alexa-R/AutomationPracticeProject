using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class ProductPage : BasePage
    {
        private WrapperWebElement MainProductImage => new WrapperWebElement(By.XPath("//*[@id='bigpic']"));
        private WrapperWebElement ProductTitle => new WrapperWebElement(By.XPath("//*[@itemprop='name']"));
        private WrapperWebElement ProductPrice => new WrapperWebElement(By.XPath("//*[@id='our_price_display']"));
        private WrapperWebElement ProductSpecification => new WrapperWebElement(By.XPath("//*[@class='table-data-sheet']"));
        private WrapperWebElement ProductQuantityInputField => new WrapperWebElement(By.XPath("//*[@id='quantity_wanted']"));
        private WrapperWebElement ProductSizeDropdown => new WrapperWebElement(By.XPath("//*[@id='uniform-group_1']"));
        private WrapperWebElement ProductColorList => new WrapperWebElement(By.XPath("//*[@id='color_to_pick_list']"));
        private WrapperWebElement AddToCartButton => new WrapperWebElement(By.XPath("//*[@id='add_to_cart']"));
        private WrapperWebElement AddToWishListButton => new WrapperWebElement(By.XPath("//*[@id='wishlist_button']"));
        private WrapperWebElement CreateWishListButton => new WrapperWebElement(By.XPath("//*[@id='create_wishlist_button']"));
        private WrapperWebElement SuccessAlert => new WrapperWebElement(By.XPath("//*[@class='alert alert-success']"));
        private WrapperWebElement AddReviewButton => new WrapperWebElement(By.XPath("//*[@id='new_comment_tab_btn']"));

        public bool IsMainProductImageDisplayed()
        {
            LogHelper.Info("Checking the display of the Main Product Image");
            return MainProductImage.Displayed;
        }

        public bool IsProductTitleDisplayed()
        {
            LogHelper.Info("Checking the display of the Product Title");
            return ProductTitle.Displayed;
        }

        public bool IsProductPriceDisplayed()
        {
            LogHelper.Info("Checking the display of the Product Price");
            return ProductPrice.Displayed;
        }

        public bool IsProductSpecificationDisplayed()
        {
            LogHelper.Info("Checking the display of the Product Specification");
            return ProductSpecification.Displayed;
        }

        public bool IsProductQuantityInputFieldDisplayed()
        {
            LogHelper.Info("Checking the display of the Product Quantity Input Field");
            return ProductQuantityInputField.Displayed;
        }

        public bool IsProductSizeDropdownDisplayed()
        {
            LogHelper.Info("Checking the display of the Product Size Dropdown");
            return ProductSizeDropdown.Displayed;
        }

        public bool IsProductColorListDisplayed()
        {
            LogHelper.Info("Checking the display of the Product Color List");
            return ProductColorList.Displayed;
        }

        public void ClickAddToCartButton()
        {
            LogHelper.Info("Clicking on the Add To Cart Button");
            AddToCartButton.Click();
        }

        public string GetProductTitleText()
        {
            LogHelper.Info("Getting the Product Title Text");
            return ProductTitle.Text;
        }

        public void ClickAddToWishListButton()
        {
            LogHelper.Info("Clicking on the Add To WishList Button");
            AddToWishListButton.Click();
        }

        public void ClickCreateWishListButton()
        {
            LogHelper.Info("Clicking on the Create Wishlist Button");
            CreateWishListButton.Click();
        }

        public bool IsSuccessAlertDisplayed()
        {
            LogHelper.Info("Checking the display of the SuccessAlert");
            return SuccessAlert.Displayed;
        }

        public void ClickAddReviewButton()
        {
            LogHelper.Info("Clicking on the Add Review Button");
            AddReviewButton.Click();
        }
    }
}