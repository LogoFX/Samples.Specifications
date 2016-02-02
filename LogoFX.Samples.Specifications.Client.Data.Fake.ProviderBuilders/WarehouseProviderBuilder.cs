using System;
using System.Collections.Generic;
using Attest.Fake.Setup;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders
{
    [Serializable]
    public class WarehouseProviderBuilder : BuilderBase<IWarehouseProvider>
    {
        private readonly List<WarehouseItemDto> _warehouseItemsStorage = new List<WarehouseItemDto>();

        private WarehouseProviderBuilder()
        {
            
        }

        public static WarehouseProviderBuilder CreateBuilder()
        {
            return new WarehouseProviderBuilder();
        }

        public void WithWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {
            _warehouseItemsStorage.Clear();
            _warehouseItemsStorage.AddRange(warehouseItems);
        }

        protected override void SetupFake()
        {
            var initSetup = ServiceCall<IWarehouseProvider>.CreateServiceCall(FakeService);
            
            var setup = initSetup
                .AddMethodCall(MethodCallWithResult<IWarehouseProvider, IEnumerable<WarehouseItemDto>>
                        .CreateMethodCall(t => t.GetWarehouseItems())
                        .BuildCallbacks(r => r.Complete(GetWarehouseItems())));
           
            setup.SetupService();
        }

        private IEnumerable<WarehouseItemDto> GetWarehouseItems()
        {
            return _warehouseItemsStorage;
        }
    }
}
