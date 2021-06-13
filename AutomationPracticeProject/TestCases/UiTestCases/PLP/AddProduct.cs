using AutomationPracticeProject.Constants;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.PLP
{
    public class AddProduct : BaseTest
    {
        [Test, Category("High")]
        public void AddProductToCartFromCategoryPlp()
        {
            Pages.BasePage.ClickProductCategoryButton(ProductCategoryNamesConstants.Women);
            var productTitle = Pages.SearchResultPage.GetFirstItemTitleText();
            Pages.SearchResultPage.MoveToFirstItemCard();
            Pages.SearchResultPage.ClickFirstItemAddToCartButton();
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Assert.AreEqual(productTitle, Pages.CheckoutPage.GetLastProductTitleText());
        }

        [Test, Category("High")]
        public void AddProductToCartFromSearchPlp()
        {
            Pages.BasePage.EnterItemInSearchInputField("Printed Dress");
            Pages.BasePage.KeyEnter();
            var productTitle = Pages.SearchResultPage.GetFirstItemTitleText();
            Pages.SearchResultPage.MoveToFirstItemCard();
            Pages.SearchResultPage.ClickFirstItemAddToCartButton();
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Assert.AreEqual(productTitle, Pages.CheckoutPage.GetLastProductTitleText());
        }
    }
}