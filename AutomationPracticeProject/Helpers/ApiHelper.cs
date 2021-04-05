using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AutomationPracticeProject.Helpers
{
    public static class ApiHelper
    {
        public static Task<HttpResponseMessage> SendPostRequest(HttpClient client, string requestUri, HttpContent requestContent, string contentType)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri) {Content = requestContent};
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            var response = client.SendAsync(request);
            return response;
        }
    }
}