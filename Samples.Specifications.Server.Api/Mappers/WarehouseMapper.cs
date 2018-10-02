using AutoMapper;
using Samples.Specifications.Server.Api.Models;
using Samples.Specifications.Server.Domain.Entities;

namespace Samples.Specifications.Server.Api.Mappers
{
    internal static class WarehouseMapper
    {
        internal static WarehouseItem MapToWarehouseItem(WarehouseItemDto warehouseItemDto) =>
            Mapper.Map<WarehouseItem>(warehouseItemDto);

        internal static WarehouseItemDto MapToWarehouseItemDto(WarehouseItem warehouseItem) =>
            Mapper.Map<WarehouseItemDto>(warehouseItem);
    }
}
