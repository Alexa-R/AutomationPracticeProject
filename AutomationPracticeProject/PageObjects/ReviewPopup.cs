using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperElement;
using OpenQA.Selenium;

namespace AutomationPracticeProject.PageObjects
{
    public class ReviewPopup : BasePage
    {
        private WrapperWebElement ReviewTitleInputField => new WrapperWebElement(By.XPath("//*[@id='comment_title']"));
        private WrapperWebElement ReviewCommentInputField => new WrapperWebElement(By.XPath("//*[@id='content']"));
        private WrapperWebElement SendButton => new WrapperWebElement(By.XPath("//*[@id='submitNewMessage']"));
        private WrapperWebElement ResultPopup => new WrapperWebElement(By.XPath("//*[contains(@class,'fancybox-type-html')]"));

        public void EnterReviewTitle(string reviewTitle)
        {
            LogHelper.Info($"Entering of the Review Title '{reviewTitle}'");
            ReviewTitleInputField.SendKeys(reviewTitle);
        }

        public void EnterReviewComment(string reviewComment)
        {
            LogHelper.Info($"Entering of the Review Comment '{reviewComment}'");
            ReviewCommentInputField.SendKeys(reviewComment);
        }
       
        public void ClickSendButton()
        {
            LogHelper.Info("Clicking on the Send Button");
            SendButton.Click();
        }

        public string GetResultPopupText()
        {
            LogHelper.Info("Getting the Result Popup Text");
            return ResultPopup.Text;
        }
    }
}