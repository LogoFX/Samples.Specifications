using System;
using System.Collections.Generic;
using Samples.Client.Data.Contracts.Dto;

namespace Samples.Client.Data.Contracts.Providers
{
    public interface IWarehouseProvider
    {
        IEnumerable<WarehouseItemDto> GetWarehouseItems();
        bool DeleteWarehouseItem(Guid id);
        void UpdateWarehouseItem(WarehouseItemDto dto);
        void CreateWarehouseItem(WarehouseItemDto dto);
    }
}
