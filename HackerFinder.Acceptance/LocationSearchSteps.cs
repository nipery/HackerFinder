using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace HackerFinder.Acceptance
{
    [Binding]
    public class LocationSearchSteps
    {
        [When(@"I supply location (.*)")]
        public void WhenISupplyLocation(string locationText)
        {
            var searcher = new ProfileSearcher(new GithubInquisitor());

            var profiles = searcher.GetProfilesForLocation(locationText);

            ScenarioContext.Current.Set<IEnumerable<Profile>>(profiles);
        }
        
        [Then(@"I should have a user named (.*)")]
        public void ThenIShouldHaveAUserNamed(string userFirstname)
        {
            var profiles = ScenarioContext.Current.Get<IEnumerable<Profile>>();
            
            Assert.IsTrue(profiles.Any(pr => pr.FirstName == userFirstname));    
        }
    }

   
}
