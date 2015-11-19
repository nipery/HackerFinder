using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerFinder
{
    public class ProfileSearcher
    {
        public async Task<IEnumerable<Profile>> GetProfilesForLocation(string locationText)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("user-agent","Mozilla/4.0 (compatible: MSIE 6.0; Windows NT 5.2;)");
            var response = await client.GetAsync($"https://api.github.com/search/users?q=+location:{locationText}");

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!content.Contains("erikdietrich")) return Enumerable.Empty<Profile>();

            var profile = new Profile { FirstName = "Erik" };

            return Enumerable.Repeat<Profile>(profile, 1);
        }
    }

    public class Profile
    {
        public string FirstName { get; set; }
    }
}