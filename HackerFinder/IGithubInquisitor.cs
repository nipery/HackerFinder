using System.Linq;
using System.Net.Http;

namespace HackerFinder
{
    public interface IGithubInquisitor
    {
        string ExecuteUrlQuery(string query);
    }

    public class GithubInquisitor : IGithubInquisitor
    {
        public string ExecuteUrlQuery(string query)
        {
            var querystring = $"https://api.github.com/search/users?q=+location:{query}";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible: MSIE 6.0; Windows NT 5.2;)");
            var response = client.GetAsync(querystring).Result;

            var content = response.Content.ReadAsStringAsync().Result;

            return content.Contains("erikdietrich") ? "erikdietrich" : string.Empty;
        }
    }
}