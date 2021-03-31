using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class SearchResultPage : BasePage
    {
        private WrapperWebElement FirstItemTitle => new WrapperWebElement(By.XPath("//*[contains(@class,'first-item')]"));

        public string GetFirstItemTitleText()
        {
            LogHelper.Info("Getting the First Item Title");
            return FirstItemTitle.Text;
        }
    }
}