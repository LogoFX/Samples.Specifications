using System.Collections.Generic;
using Attest.Tests.Core;
using LogoFX.Client.Tests.Contracts;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;
using LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public static class GivenMainSteps
    {
        public static void SetupWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {
            var warehouseProviderBuilder = ScenarioHelper.GetOrCreate(WarehouseProviderBuilder.CreateBuilder);
            warehouseProviderBuilder.WithWarehouseItems(warehouseItems);
            ScenarioHelper.Get<IBuilderRegistrationService>().RegisterBuilder(warehouseProviderBuilder);
        }
    }
}
