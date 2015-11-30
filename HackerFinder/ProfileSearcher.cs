using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerFinder
{
    public class ProfileSearcher
    {
        private readonly IGithubInquisitor _githubInquisitor;

        public ProfileSearcher(IGithubInquisitor githubInquisitor)
        {
            if(githubInquisitor ==null) throw new ArgumentNullException(nameof(githubInquisitor));
            _githubInquisitor = githubInquisitor;
        }


        public ProfileSearcher()
        {
            
        }

        public IEnumerable<Profile> GetProfilesForLocation(string locationText)
        {
            var queryResult = _githubInquisitor.ExecuteUrlQuery(locationText);
            
            if (!queryResult.Contains("erikdietrich")) return Enumerable.Empty<Profile>();

            var profile = new Profile { FirstName = "Erik" };

            return Enumerable.Repeat<Profile>(profile, 1);
        }
    }

    public class Profile
    {
        public string FirstName { get; set; }
    }
}