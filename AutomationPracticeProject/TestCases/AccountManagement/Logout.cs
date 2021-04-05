using System.Configuration;
using AutomationPracticeProject.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeProject.TestCases.AccountManagement
{
    public class Logout : BaseTest 
    {
        [Test, Category("Priority_High")]
        public void AbilityToLogout()
        {
            Pages.BasePage.LogIn(ConfigurationManager.AppSettings["Login"], ConfigurationManager.AppSettings["Password"]);
            Pages.BasePage.ClickSignOutButton();
            Assert.IsTrue(Pages.BasePage.IsSignInButtonDisplayed());
        }
    }
}