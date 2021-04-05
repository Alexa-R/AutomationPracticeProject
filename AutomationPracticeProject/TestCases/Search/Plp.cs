using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.Search
{
    public class Plp : BaseTest
    {
        [Test, Category("Priority_High")]
        public void ProductsAreDisplayedOnPageAccordingToSearch()
        {
            var searchString = "Faded Short Sleeve T-shirts";
            Pages.BasePage.EnterItemInSearchInputField(searchString);
            Pages.BasePage.KeyEnter();
            Assert.AreEqual(searchString, Pages.SearchResultPage.GetFirstItemTitleText());
        }
    }
}