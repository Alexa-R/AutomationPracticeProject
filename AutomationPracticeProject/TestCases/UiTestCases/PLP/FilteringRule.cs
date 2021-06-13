using AutomationPracticeProject.Constants;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.PLP
{
    public class FilteringRule : BaseTest
    {
        [Test, Category("Medium")]
        public void FilterProductsOnCategoryPlp()
        {
            Pages.BasePage.ClickProductCategoryButton(ProductCategoryNamesConstants.Women);
            Pages.SearchResultPage.ClickOptionFromFilterChecklist(FilterNamesContstants.Categories, CategoriesFilterConstants.Dresses);
            Assert.IsTrue(Pages.SearchResultPage.AreProductsTitlesContainString("Dress"));
        }

        [Test, Category("Medium")]
        public void NewFilterDoesNotDisablePreviousOneOnCategoryPlp()
        {
            Pages.BasePage.ClickProductCategoryButton(ProductCategoryNamesConstants.Women);
            Pages.SearchResultPage.ClickOptionFromFilterChecklist(FilterNamesContstants.Styles, StylesFilterConstants.Casual);
            Pages.SearchResultPage.ClickOptionFromFilterChecklist(FilterNamesContstants.Styles, StylesFilterConstants.Dressy);
            Assert.True(Pages.SearchResultPage.IsOptionFromFilterChecklistChecked(FilterNamesContstants.Styles, StylesFilterConstants.Casual));
            Assert.True(Pages.SearchResultPage.IsOptionFromFilterChecklistChecked(FilterNamesContstants.Styles, StylesFilterConstants.Dressy));
        }

        [Test, Category("Medium")]
        public void FilterProductsOnSearchPlp()
        {
            Pages.BasePage.EnterItemInSearchInputField("Women");
            Pages.BasePage.KeyEnter();
            Pages.SearchResultPage.ClickOptionFromFilterChecklist(FilterNamesContstants.Categories, CategoriesFilterConstants.Dresses);
            Assert.IsTrue(Pages.SearchResultPage.AreProductsTitlesContainString("Dress"));
        }

        [Test, Category("Medium")]
        public void NewFilterDoesNotDisablePreviousOneOnSearchPlp()
        {
            Pages.BasePage.EnterItemInSearchInputField("Dress");
            Pages.BasePage.KeyEnter();
            Pages.SearchResultPage.ClickOptionFromFilterChecklist(FilterNamesContstants.Styles, StylesFilterConstants.Casual);
            Pages.SearchResultPage.ClickOptionFromFilterChecklist(FilterNamesContstants.Styles, StylesFilterConstants.Dressy);
            Assert.True(Pages.SearchResultPage.IsOptionFromFilterChecklistChecked(FilterNamesContstants.Styles, StylesFilterConstants.Casual));
            Assert.True(Pages.SearchResultPage.IsOptionFromFilterChecklistChecked(FilterNamesContstants.Styles, StylesFilterConstants.Dressy));
        }
    }
}