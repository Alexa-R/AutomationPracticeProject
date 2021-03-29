using System.Configuration;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.MyAccount
{
    public class PersonalInformation : BaseTest
    {
        [Test]
        public void ChangeUserPersonalInformation()
        {
            var lastName = $"LastName{RandomHelper.GetRandomString(8)}";

            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.MyAccountPage.ClickMyPersonalInformationButton();
            Pages.PersonalInformationPage.ClearLastNameInputField();
            Pages.PersonalInformationPage.EnterLastName(lastName);
            Pages.PersonalInformationPage.EnterCurrentPassword(ConfigurationManager.AppSettings["Password"]);
            Pages.PersonalInformationPage.ClickSaveButton();
            Assert.IsTrue(Pages.PersonalInformationPage.IsSuccessAlertDisplayed());
            Assert.That(Pages.BasePage.GetAccountButtonText(), Contains.Substring(lastName));
        }
    }
}