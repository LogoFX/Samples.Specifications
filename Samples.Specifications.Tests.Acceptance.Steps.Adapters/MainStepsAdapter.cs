using Samples.Specifications.Tests.Steps;
using TechTalk.SpecFlow;

namespace Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    internal sealed class MainStepsAdapter
    {
        public MainSteps MainSteps { get; set; }

        public MainStepsAdapter(
            MainSteps mainSteps)
        {
            MainSteps = mainSteps;
        }

        [Then(@"Application navigates to the main screen")]
        public void ThenApplicationNavigatesToTheMainScreen()
        {
            //for readability reasons
        }
    }
}
