using AngleSharp.Html.Parser;

namespace Aula_Quinta.Services
{
    public static class HttpRequestService
    {
        private static readonly HtmlParser _parser = new();

        public static HttpClient ConfiguringHttp(string url)
        {
            HttpClient client = new();
            client.BaseAddress = new Uri(url);
            return client;
        }

        public static async Task<string> Pegar_Html(this HttpClient client)
        {
            try
            {
                string response = await client.GetStringAsync(client.BaseAddress);
                var content = await _parser.ParseDocumentAsync(response);
                return content.DocumentElement.OuterHtml;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
