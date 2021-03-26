using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.HomePage
{
    public class AddProduct : BaseTest
    {
        [Test]
        public void AbilityToAddProduct()
        {
            Pages.HomePage.ClickAddToCartButtonInCard(1);
            Pages.HomePage.WaitUntilCartPopupIsDisplayed();
            Pages.HomePage.ClickProceedToCheckoutButton();
        }
    }
}