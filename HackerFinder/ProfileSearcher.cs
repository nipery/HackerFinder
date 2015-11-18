using System.Collections.Generic;
using System.Linq;

namespace HackerFinder
{
    public class ProfileSearcher
    {
        public IEnumerable<Profile> GetProfilesForLocation(string locationText)
        {
            var profile = new Profile {FirstName = "Erik"};

            return Enumerable.Repeat<Profile>(profile, 1 );
        }
    }

    public class Profile
    {
        public string FirstName { get; set; }
    }
}