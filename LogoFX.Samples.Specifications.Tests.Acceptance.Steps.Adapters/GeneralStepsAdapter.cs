using TechTalk.SpecFlow;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class GeneralStepsAdapter
    {
        [When(@"I open the application")]
        public void WhenIOpenTheApplication()
        {            
            ScenarioContext.Current.Pending();
        }
    }
}
