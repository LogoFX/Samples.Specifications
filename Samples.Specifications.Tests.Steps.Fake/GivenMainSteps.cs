using System.Collections.Generic;
using Attest.Testing.Contracts;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace Samples.Specifications.Tests.Steps
{
    internal sealed class GivenMainSteps : IGivenMainSteps
    {
        private readonly IBuilderRegistrationService _builderRegistrationService;
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;

        public GivenMainSteps(
            IBuilderRegistrationService builderRegistrationService,
            WarehouseProviderBuilder warehouseProviderBuilder)
        {
            _builderRegistrationService = builderRegistrationService;
            _warehouseProviderBuilder = warehouseProviderBuilder;
        }

        public void SetupWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {
            _warehouseProviderBuilder.WithWarehouseItems(warehouseItems);
            _builderRegistrationService.RegisterBuilder(_warehouseProviderBuilder);
        }
    }
}
