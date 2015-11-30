using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerFinder.Test.PfofileSearcherTests
{
    [TestClass]
    public class ProfileSearcherConstructor_Should
    {
        [TestMethod, TestCategory("Unit"), TestCategory("Proven")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_ArgumentNullException_when_Passed_Null_Dependency()
        {
            var searcher = new ProfileSearcher(null);
        }
    }
}