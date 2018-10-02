using System;
using System.Collections.Generic;
using System.Linq;
using Attest.Fake.Builders;
using Attest.Fake.Core;
using Attest.Fake.Setup.Contracts;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Fake.ProviderBuilders
{    
    public sealed class WarehouseProviderBuilder : FakeBuilderBase<IWarehouseProvider>.WithInitialSetup
    {
        private readonly List<WarehouseItemDto> _warehouseItemsStorage = new List<WarehouseItemDto>();

        private WarehouseProviderBuilder()
        {
            
        }

        public static WarehouseProviderBuilder CreateBuilder() => new WarehouseProviderBuilder();

        public void WithWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {
            _warehouseItemsStorage.Clear();
            _warehouseItemsStorage.AddRange(warehouseItems);
        }        

        protected override IServiceCall<IWarehouseProvider> CreateServiceCall(IHaveNoMethods<IWarehouseProvider> serviceCallTemplate)
        {
            var setup = serviceCallTemplate
                .AddMethodCallWithResult(t => t.GetWarehouseItems(),
                    r => r.Complete(GetWarehouseItems))
                .AddMethodCallWithResult<Guid, bool>(t => t.DeleteWarehouseItem(It.IsAny<Guid>()),
                    (r, id) => r.Complete(DeleteWarehouseItem(id)))
                .AddMethodCallWithResult<WarehouseItemDto, bool>(t => t.UpdateWarehouseItem(It.IsAny<WarehouseItemDto>()),
                    (r, dto) => r.Complete(k =>
                    {
                        SaveWarehouseItem(k);
                        return true;
                    }))
                    .AddMethodCall<WarehouseItemDto>(t => t.CreateWarehouseItem(It.IsAny<WarehouseItemDto>()),
                    (r, dto) => r.Complete(SaveWarehouseItem));
            return setup;
        }

        private IEnumerable<WarehouseItemDto> GetWarehouseItems()
        {
            return _warehouseItemsStorage;
        }

        private bool DeleteWarehouseItem(Guid id)
        {
            var dto = _warehouseItemsStorage.SingleOrDefault(x => x.Id == id);
            if (dto == null)
            {
                return false;
            }
            return _warehouseItemsStorage.Remove(dto);
        }

        private void SaveWarehouseItem(WarehouseItemDto dto)
        {
            var oldDto = _warehouseItemsStorage.SingleOrDefault(x => x.Id == dto.Id);
            if (oldDto == null)
            {
                _warehouseItemsStorage.Add(dto);
                return;
            }

            oldDto.Kind = dto.Kind;
            oldDto.Price = dto.Price;
            oldDto.Quantity = dto.Quantity;
        }               
    }
}
