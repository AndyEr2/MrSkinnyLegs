using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebSpider
{
    public static class Parser
    {
        public static async System.Threading.Tasks.Task<string> GetTextAsync(string webAdress)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(webAdress);
            var pageContents = await response.Content.ReadAsStringAsync();
            HtmlDocument pageDocument = new HtmlDocument();
            pageDocument.LoadHtml(pageContents);

            return pageDocument.DocumentNode.SelectSingleNode("(//div[contains(@class,'desc-text')])[1]").InnerText;
        }
    }
}
