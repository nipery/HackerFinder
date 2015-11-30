using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HackerFinder.Test.PfofileSearcherTests
{
    [TestClass]
    public class GetProfilesForLocationShould
    {
        private Mock<IGithubInquisitor> _inquisitor; 

        [TestInitialize]
        public void BeforeEachTest()
        {
            _inquisitor = new Mock<IGithubInquisitor>();
        }

        [TestMethod, TestCategory("Unit"), TestCategory("Proven")]
        public void Return_EmptyEnumeration_For_Nonsence()
        {
            _inquisitor.Setup(s => s.ExecuteUrlQuery(It.IsAny<string>())).Returns(string.Empty);

            var target = new ProfileSearcher(_inquisitor.Object);

            var profiles = target.GetProfilesForLocation("{1A57363C-E976-4325-B4AF-EF3BDFB8752F}");

            Assert.AreEqual(0,profiles.Count());
        }

        [TestMethod, TestCategory("Unit"), TestCategory("Proven")]
        public void Return_A_Profile_With_FirstName_Erik_When_GithubInquisitor_Returns_Result_With_String_erikdietrich()
        {
            _inquisitor.Setup(s => s.ExecuteUrlQuery(It.IsAny<string>())).Returns("erikdietrich");

            var target = new ProfileSearcher(_inquisitor.Object);

            var profiles = target.GetProfilesForLocation("Wheeling,IL");

            Assert.AreEqual("Erik", profiles.First().FirstName);
          
        }
    }

   
}