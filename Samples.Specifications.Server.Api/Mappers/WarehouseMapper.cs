using AutoMapper;
using Samples.Specifications.Server.Api.Models;

namespace Samples.Specifications.Server.Api.Mappers
{
    internal static class WarehouseMapper
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
