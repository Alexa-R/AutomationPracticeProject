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
            Pages.PersonalInformationForm.ClearLastNameInputField();
            Pages.PersonalInformationForm.EnterLastName(lastName);
            Pages.PersonalInformationForm.EnterCurrentPassword(ConfigurationManager.AppSettings["Password"]);
            Pages.PersonalInformationForm.ClickSaveButton();
            Assert.IsTrue(Pages.PersonalInformationForm.IsSuccessAlertDisplayed());
            Assert.That(Pages.BasePage.GetAccountButtonText(), Contains.Substring(lastName));
        }
    }
}