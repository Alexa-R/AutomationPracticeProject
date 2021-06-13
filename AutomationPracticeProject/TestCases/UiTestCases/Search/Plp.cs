using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.UiTestCases.Search
{
    public class Plp : BaseTest
    {
        [Test, Category("High")]
        public void ProductsAreDisplayedOnPageAccordingToSearch()
        {
            var searchString = "Faded Short Sleeve T-shirts";
            Pages.BasePage.EnterItemInSearchInputField(searchString);
            Pages.BasePage.KeyEnter();
            Assert.AreEqual(searchString, Pages.SearchResultPage.GetFirstItemTitleText());
        }
    }
}