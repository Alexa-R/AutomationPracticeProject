using System;
using System.Configuration;
using System.Net.Http;
using AutomationPracticeProject.Helpers;
using AutomationPracticeProject.WrapperFactory;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace AutomationPracticeProject.TestCases
{
    [AllureNUnit]
    [TestFixture]
    public class BaseTest 
    {
        protected HttpClient _client;

        [SetUp]
        public void SetUpTest()
        {
            _client = new HttpClient();
            ExtentReportsHelper.GetExtentReportsHelper().CreateTest(TestContext.CurrentContext.Test.Name);
            WebDriverFactory.InitBrowser("Chrome");
            LogHelper.Info("Browser started.");
            WebDriverFactory.GoToUrl(ConfigurationManager.AppSettings["URL"]);
            LogHelper.Info($"Browser navigated to the url [{ConfigurationManager.AppSettings["URL"]}].");
            WebDriverFactory.Driver.Manage().Window.Maximize();
            LogHelper.Info("Browser maximized.");
            WebDriverFactory.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                
                switch (status)
                {
                    case TestStatus.Failed:
                        ExtentReportsHelper.GetExtentReportsHelper().SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        break;
                    case TestStatus.Skipped:
                        ExtentReportsHelper.GetExtentReportsHelper().SetTestStatusSkipped();
                        break;
                    default:
                        ExtentReportsHelper.GetExtentReportsHelper().SetTestStatusPass();
                        break;
                }
            }
            catch (Exception exc)
            {
                throw (exc);
            }
            finally
            {
                _client.Dispose();
                WebDriverFactory.CloseAllDrivers();
                LogHelper.Info("Browser closed.");
            }
        }
    }
}