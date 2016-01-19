using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class GivenMainStepsAdapter
    {
        [Given(@"warehouse contains the following items:")]
        public void GivenWarehouseContainsTheFollowingItems(Table table)
        {
            var warehouseItems = table.CreateSet<WarehouseItemDto>();
            var warehouseProviderBuilder = GivenMainSteps.SetupWarehouseItems(warehouseItems);
        }

    }
}
