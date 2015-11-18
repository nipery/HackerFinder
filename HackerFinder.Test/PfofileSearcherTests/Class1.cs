using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerFinder.Test.PfofileSearcherTests
{
    [TestClass]
    public class GetProfilesForLocationShould
    {

        [TestMethod, TestCategory("Unit"), TestCategory("Proven")]
        public void Return_Profile_With_FirstName_Set_to_Erik()
        {
            var target = new ProfileSearcher();

            var firstProfile = target.GetProfilesForLocation("Chicago").First();

            Assert.AreEqual("Erik",firstProfile.FirstName);
        }

    }
}