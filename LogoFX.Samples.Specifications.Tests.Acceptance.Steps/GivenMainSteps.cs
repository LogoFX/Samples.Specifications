using System.Collections.Generic;
#if FAKE
using Attest.Testing.Core;
using LogoFX.Client.Testing.Contracts;
#endif
using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;
#if FAKE
using LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders;
#endif
#if REAL
#endif

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public static class GivenMainSteps
    {
        public static void SetupWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {
#if FAKE
            var warehouseProviderBuilder = ScenarioHelper.GetOrCreate(WarehouseProviderBuilder.CreateBuilder);
            warehouseProviderBuilder.WithWarehouseItems(warehouseItems);
            ScenarioHelper.Get<IBuilderRegistrationService>().RegisterBuilder(warehouseProviderBuilder);
#endif

#if REAL
    //put here real Setup
#endif
        }
    }
}
