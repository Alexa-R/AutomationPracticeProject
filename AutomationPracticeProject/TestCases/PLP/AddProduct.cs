using AutomationPracticeProject.Constants;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.PLP
{
    public class AddProduct : BaseTest
    {
        [Test]
        public void AddProductToCartFromCategoryPlp()
        {
            Pages.BasePage.ClickProductCategoryButton(ProductCategoryNamesConstants.Women);
            var productTitle = Pages.SearchResultPage.GetFirstItemTitleText();
            Pages.SearchResultPage.MoveToFirstItemCard();
            Pages.SearchResultPage.ClickFirstItemAddToCartButton();
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Assert.AreEqual(productTitle, Pages.CheckoutPage.GetLastProductTitleText());
        }
    }
}