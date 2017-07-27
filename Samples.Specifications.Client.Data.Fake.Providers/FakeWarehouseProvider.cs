using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Attest.Fake.Builders;
using JetBrains.Annotations;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;
using Samples.Specifications.Client.Data.Fake.Containers;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;

namespace Samples.Specifications.Client.Data.Fake.Providers
{
    [UsedImplicitly]
    class FakeWarehouseProvider : FakeProviderBase<WarehouseProviderBuilder, IWarehouseProvider>, IWarehouseProvider
    {
        private readonly Random _random = new Random();

        public FakeWarehouseProvider(
            WarehouseProviderBuilder warehouseProviderBuilder,
            IWarehouseContainer warehouseContainer)
            :base(warehouseProviderBuilder)
        {
            warehouseProviderBuilder.WithWarehouseItems(warehouseContainer.WarehouseItems);
        }

        IEnumerable<WarehouseItemDto> IWarehouseProvider.GetWarehouseItems()
        {
            Task.Delay(_random.Next(2000));
            var service = GetService();
            var warehouseItems = service.GetWarehouseItems();
            return warehouseItems;
        }

        bool IWarehouseProvider.DeleteWarehouseItem(Guid id)
        {
            Task.Delay(_random.Next(2000));
            var service = GetService();
            var retVal = service.DeleteWarehouseItem(id);
            return retVal;
        }

        bool IWarehouseProvider.UpdateWarehouseItem(WarehouseItemDto dto)
        {
            var delayTask = Task.Delay(_random.Next(2000));
            delayTask.Wait();
            var service = GetService();
            return service.UpdateWarehouseItem(dto);
        }

        void IWarehouseProvider.CreateWarehouseItem(WarehouseItemDto dto)
        {
            var delayTask = Task.Delay(_random.Next(2000));
            delayTask.Wait();
            var service = GetService();
            service.CreateWarehouseItem(dto);
        }
    }
}
