using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.PDP
{
    public class PdpDisplay : BaseTest
    {
        [Test, Category("Medium")]
        public void PdpDisplayIsCorrect()
        {
            Pages.BasePage.EnterItemInSearchInputField("Printed Dress");
            Pages.BasePage.ClickItemFromSearchResultPopup(1);
            Assert.IsTrue(Pages.ProductPage.IsMainProductImageDisplayed());
            Assert.IsTrue(Pages.ProductPage.IsProductTitleDisplayed());
            Assert.IsTrue(Pages.ProductPage.IsProductPriceDisplayed());
            Assert.IsTrue(Pages.ProductPage.IsProductSpecificationDisplayed());
            Assert.IsTrue(Pages.ProductPage.IsProductQuantityInputFieldDisplayed());
            Assert.IsTrue(Pages.ProductPage.IsProductSizeDropdownDisplayed());
            Assert.IsTrue(Pages.ProductPage.IsProductColorListDisplayed());
        }
    }
}