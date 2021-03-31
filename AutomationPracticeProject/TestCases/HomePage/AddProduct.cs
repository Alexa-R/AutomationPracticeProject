using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.HomePage
{
    public class AddProduct : BaseTest
    {
        [Test]
        public void AbilityToAddProduct()
        {
            Pages.HomePage.MoveToProductCard(1);
            var productTitle = Pages.HomePage.GetProductTitle(1);
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.HomePage.WaitUntilCartPopupIsDisplayed();
            Pages.ProductCartPopup.ClickProceedToCheckoutButton();
            Assert.Equals(productTitle, Pages.CheckoutPage.GetLastProductTitleText());
        }
    }
}