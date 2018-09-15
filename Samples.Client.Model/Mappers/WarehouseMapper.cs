using AutoMapper;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model.Mappers
{
    internal static class WarehouseMapper
    {
        internal static IWarehouseItem MapToWarehouseItem(WarehouseItemDto warehouseItemDto)
        {
            var item = Mapper.Map<WarehouseItem>(warehouseItemDto);
            return item;
        }

        internal static WarehouseItemDto MapToWarehouseDto(IWarehouseItem warehouseItem)
        {
            return Mapper.Map<WarehouseItemDto>(warehouseItem);
        }
    }
}
