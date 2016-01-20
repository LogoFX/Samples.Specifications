using LogoFX.Samples.Specifications.Tests.Acceptance.TestData;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class MainStepsAdapter
    {
        [Then(@"I expect to see the following data on the screen:")]
        public void ThenIExpectToSeeTheFollowingDataOnTheScreen(Table table)
        {
            var warehouseItems = table.CreateSet<WarehouseItemAssertionTestData>();
            MainSteps.ThenIExpectToSeeTheFollowingDataOnTheScreen(warehouseItems);
        }
    }
}
