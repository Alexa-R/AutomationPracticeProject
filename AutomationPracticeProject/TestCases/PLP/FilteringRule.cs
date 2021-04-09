using AutomationPracticeProject.Constants;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.PLP
{
    public class FilteringRule : BaseTest
    {
        [Test, Category("Priority_Medium")]
        public void FilterProductsOnCategoryPlp()
        {
            Pages.BasePage.ClickProductCategoryButton(ProductCategoryNamesConstants.Women);
            Pages.SearchResultPage.ClickOptionFromFilterChecklist(FilterNamesContstants.Categories, CategoriesFilterConstants.Dresses);
            Assert.IsTrue(Pages.SearchResultPage.IsProductsTitlesContainsString("Dress"));
        }
    }
}