using AutoMapper;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model.Mappers
{
    internal static class WarehouseMapper
    {
        internal static IWarehouseItem MapToWarehouseItem(WarehouseItemDto warehouseItemDto) =>
            Mapper.Map<WarehouseItem>(warehouseItemDto);

        internal static WarehouseItemDto MapToWarehouseDto(IWarehouseItem warehouseItem) =>
            Mapper.Map<WarehouseItemDto>(warehouseItem);
    }
}
