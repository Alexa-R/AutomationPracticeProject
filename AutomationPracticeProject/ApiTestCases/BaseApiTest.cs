using System.Net.Http;
using NUnit.Framework;

namespace AutomationPracticeProject.ApiTestCases
{
    public class BaseApiTest
    {
        protected HttpClient _client;

        [SetUp]
        public void SetUpTest()
        {
            _client = new HttpClient();
        }

        [TearDown]
        public void TearDownTest()
        {
            _client.Dispose();
        }
    }
}