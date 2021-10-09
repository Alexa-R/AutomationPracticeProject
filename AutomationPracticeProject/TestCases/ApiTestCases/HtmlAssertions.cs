using AutomationPracticeProject.Helpers;
using HtmlAgilityPack;

namespace AutomationPracticeProject.TestCases.ApiTestCases
{
    public static class HtmlAssertions
    {
        public static bool IsElementExistsOnHtmlPage(string html, string xpath)
        {
            var htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(html);
            LogHelper.Info("Searching for the element on the page");
            var nodes = htmlSnippet.DocumentNode.SelectNodes(xpath);
            if (nodes != null)
            {
                if (nodes.Count == 1)
                {
                    LogHelper.Info("The element there is on the page");
                    return true;
                }
                else if (nodes.Count > 1)
                {
                    LogHelper.Error("There are more than one element on the page");
                    return false;
                }
            }
            
            LogHelper.Info("There is no such element on the page");
            return false;
        }

        public static string GetHtmlElementText(string html, string xpath)
        {
            var htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(html);
            LogHelper.Info("Searching for the element on the page");
            var nodes = htmlSnippet.DocumentNode.SelectNodes(xpath);

            if (nodes != null)
            {
                if (nodes.Count == 1)
                {
                    LogHelper.Info("The element there is on the page. Getting of the element's text");
                    foreach (HtmlNode node in nodes)
                    {
                        return node.InnerText;
                    }
                }
                else if (nodes.Count > 1)
                {
                    LogHelper.Error("There are more than one element on the page");
                }
            }

            LogHelper.Info("There is no such element on the page");
            return null;
        }
    }
}