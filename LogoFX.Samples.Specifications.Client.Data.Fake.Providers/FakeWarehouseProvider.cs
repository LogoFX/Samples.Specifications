using System;
using System.Collections.Generic;
using System.Threading;
using Attest.Fake.Builders;
using JetBrains.Annotations;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;
using LogoFX.Samples.Specifications.Client.Data.Fake.Containers;
using LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace LogoFX.Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    class FakeWarehouseProvider : FakeProviderBase<WarehouseProviderBuilder, IWarehouseProvider>, IWarehouseProvider
    {
        private readonly WarehouseProviderBuilder _warehouseProviderBuilder;
        private readonly Random _random = new Random();

        public FakeWarehouseProvider(
            WarehouseProviderBuilder warehouseProviderBuilder,
            IWarehouseContainer warehouseContainer)
        {
            _warehouseProviderBuilder = warehouseProviderBuilder;
            _warehouseProviderBuilder.WithWarehouseItems(warehouseContainer.WarehouseItems);
        }

        IEnumerable<WarehouseItemDto> IWarehouseProvider.GetWarehouseItems()
        {
            Thread.Sleep(_random.Next(2000));
            var service = GetService(() => _warehouseProviderBuilder, b => b);
            return service.GetWarehouseItems();
        }
    }
}
