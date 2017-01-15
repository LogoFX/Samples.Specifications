using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class ExitStepsAdapter
    {
        [Then(@"the exit appication options are displayed")]
        public void ThenTheExitAppicationOptionsAreDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
