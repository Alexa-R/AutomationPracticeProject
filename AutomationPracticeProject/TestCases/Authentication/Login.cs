using System.Configuration;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.Authentication
{
    public class Login : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Assert.IsTrue(Pages.BasePage.IsContactUsButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsSignOutButtonDisplayed());
            Assert.IsTrue(Pages.BasePage.IsAccountButtonDisplayed());
        }
    }
}