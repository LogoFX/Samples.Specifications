using Attest.Tests.Core;
using LogoFX.Client.Tests.Contracts;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps.Adapters
{
    [Binding]
    class GivenMainStepsAdapter
    {
        private readonly IBuilderRegistrationService _builderRegistrationService = ScenarioHelper.Get<IBuilderRegistrationService>();

        [Given(@"warehouse contains the following items:")]
        public void GivenWarehouseContainsTheFollowingItems(Table table)
        {
            var warehouseItems = table.CreateSet<WarehouseItemDto>();
            var warehouseProviderBuilder = GivenMainSteps.SetupWarehouseItems(warehouseItems);
            _builderRegistrationService.RegisterBuilder(warehouseProviderBuilder);
        }

    }
}
