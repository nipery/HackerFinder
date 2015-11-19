using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerFinder.Test.PfofileSearcherTests
{
    [TestClass]
    public class GetProfilesForLocationShould
    {
        [TestMethod, TestCategory("Unit"), TestCategory("Proven")]
        public async Task Return_Profile_With_FirstName_Set_to_Erik()
        {
            var target = new ProfileSearcher();

            var firstProfile = await (target.GetProfilesForLocation("Wheeling,IL").ConfigureAwait(false));
            var profile = firstProfile.First();
            Assert.AreEqual("Erik", profile.FirstName);
        }

        [TestMethod, TestCategory("Unit"), TestCategory("Proven")]
        public async Task Return_EmptyEnumeration_For_Nonsence()
        {
            var target = new ProfileSearcher();

            var profiles = await target.GetProfilesForLocation("{1A57363C-E976-4325-B4AF-EF3BDFB8752F}");

            Assert.AreEqual(0,profiles.Count());
        }
    }
}