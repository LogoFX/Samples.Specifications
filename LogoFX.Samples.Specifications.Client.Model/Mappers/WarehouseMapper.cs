using AutoMapper;
using LogoFX.Samples.Specifications.Client.Model.Contracts;
using Samples.Client.Data.Contracts.Dto;

namespace LogoFX.Samples.Specifications.Client.Model.Mappers
{
    static class WarehouseMapper
    {
        internal static IWarehouseItem MapToWarehouseItem(WarehouseItemDto warehouseItemDto)
        {
            return Mapper.Map<WarehouseItem>(warehouseItemDto);
        }
    }
}
