using System.Configuration;
using AutomationPracticeProject.Constants;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.ContactPage
{
    public class SendMessage : BaseTest
    {
        [Test, Category("Medium")]
        public void AbilityToSendMessage()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.BasePage.ClickContactUsButton();
            Pages.BasePage.ClickDropdown(DropdownNamesConstants.SubjectHeadingDropdown);
            Pages.BasePage.ClickOptionFromDropdown(DropdownNamesConstants.SubjectHeadingDropdown, SubjectHeadingDropdownConstants.CustomerService);
            Pages.ContactPage.EnterMessage("Message to the company");
            Pages.ContactPage.ClickSendButton();
            Assert.IsTrue(Pages.ContactPage.IsSuccessAlertDisplayed());
        }
    }
}