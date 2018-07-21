using System.Collections.Generic;
using Samples.Client.Data.Contracts.Dto;

#if FAKE
using Attest.Testing.Contracts;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
#endif

#if REAL
using Samples.Specifications.Tests.Steps.Helpers;
#endif

namespace Samples.Specifications.Tests.Steps
{
    public class GivenMainSteps
    {
#if FAKE
        private readonly IBuilderRegistrationService _builderRegistrationService;
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;

        public GivenMainSteps(
            IBuilderRegistrationService builderRegistrationService,
            WarehouseProviderBuilder warehouseProviderBuilder)
        {
            _builderRegistrationService = builderRegistrationService;
            _warehouseProviderBuilder = warehouseProviderBuilder;
        }
#endif

#if REAL
        private readonly ISetupHelper _setupHelper;

        public GivenMainSteps(ISetupHelper setupHelper)
        {
            _setupHelper = setupHelper;
        }

#endif
        public void SetupWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {
#if FAKE
            _warehouseProviderBuilder.WithWarehouseItems(warehouseItems);
            _builderRegistrationService.RegisterBuilder(_warehouseProviderBuilder);
#endif

#if REAL                        
            foreach (var warehouseItemDto in warehouseItems)
            {
                _setupHelper.AddWarehouseItem(warehouseItemDto);
            }            
#endif
        }
    }
}
