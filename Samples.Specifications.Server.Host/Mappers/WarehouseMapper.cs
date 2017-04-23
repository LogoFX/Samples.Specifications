using AutoMapper;
using Samples.Specifications.Server.Domain.Models;
using Samples.Specifications.Server.Host.Data;

namespace Samples.Specifications.Server.Host.Mappers
{
    static class WarehouseMapper
    {
        internal static WarehouseItem MapToWarehouseItem(WarehouseItemDto warehouseItemDto)
        {
            var item = Mapper.Map<WarehouseItem>(warehouseItemDto);
            return item;
        }

        internal static WarehouseItemDto MapToWarehouseItemDto(WarehouseItem warehouseItem)
        {
            return Mapper.Map<WarehouseItemDto>(warehouseItem);
        }
    }
}
