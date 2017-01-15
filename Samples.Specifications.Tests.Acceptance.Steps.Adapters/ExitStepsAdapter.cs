using Samples.Specifications.Tests.Steps;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class ExitStepsAdapter
    {
        public ExitSteps ExitSteps { get; set; }

        public ExitStepsAdapter(ExitSteps exitSteps)
        {
            ExitSteps = exitSteps;
        }

        [Then(@"the exit appication options are displayed")]
        public void ThenTheExitAppicationOptionsAreDisplayed()
        {
            ExitSteps.ThenTheExitAppicationOptionsDisplayStatusIs(true);
        }

        [Then(@"the exit appication options are not displayed")]
        public void ThenTheExitAppicationOptionsAreNotDisplayed()
        {
            ExitSteps.ThenTheExitAppicationOptionsDisplayStatusIs(false);
        }

    }
}
