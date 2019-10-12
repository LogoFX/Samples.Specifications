using AutoMapper;
using Samples.Specifications.Server.Api.Models;
using Samples.Specifications.Server.Domain.Entities;

namespace Samples.Specifications.Server.Api.Mappers
{
    public class WarehouseMapper
    {
        private readonly IMapper _mapper;

        public WarehouseMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        internal WarehouseItem MapToWarehouseItem(WarehouseItemDto warehouseItemDto) =>
            _mapper.Map<WarehouseItem>(warehouseItemDto);

        internal WarehouseItemDto MapToWarehouseItemDto(WarehouseItem warehouseItem) =>
            _mapper.Map<WarehouseItemDto>(warehouseItem);
    }
}
