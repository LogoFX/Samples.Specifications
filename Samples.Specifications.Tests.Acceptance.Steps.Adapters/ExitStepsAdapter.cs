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

        [When(@"I select save with changes option")]
        public void WhenISelectSaveWithChangesOption()
        {
            ExitSteps.WhenISelectExitWithChangesOption();
        }

        [Then(@"the exit application options are displayed")]
        public void ThenTheExitAppicationOptionsAreDisplayed()
        {
            ExitSteps.ThenTheExitApplicationOptionsDisplayStatusIs(true);
        }

        [Then(@"the exit application options are not displayed")]
        public void ThenTheExitAppicationOptionsAreNotDisplayed()
        {
            ExitSteps.ThenTheExitApplicationOptionsDisplayStatusIs(false);
        }
    }
}
