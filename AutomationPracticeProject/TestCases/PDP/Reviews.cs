using System.Configuration;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.PDP
{
    public class Reviews : BaseTest
    {
        [Test, Category("Priority_Medium")]
        public void AddReview()
        {
            var reviewTitle = $"ReviewTitle{RandomHelper.GetRandomStringWithNumbers(8)}";
            var reviewContent = $"ReviewContent{RandomHelper.GetRandomStringWithNumbers(8)}";
            var successfulAddReview = "Your comment has been added";

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.BasePage.EnterItemInSearchInputField("Printed Dress");
            Pages.BasePage.ClickItemFromSearchResultPopup(1);
            Pages.ProductPage.ClickAddReviewButton();
            Pages.ReviewPopup.EnterReviewTitle(reviewTitle);
            Pages.ReviewPopup.EnterReviewComment(reviewContent);
            Pages.ReviewPopup.ClickSendButton();
            Assert.That(Pages.ReviewPopup.GetResultPopupText(), Contains.Substring(successfulAddReview));
        }
    }
}