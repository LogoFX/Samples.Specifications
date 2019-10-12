using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Api.Mappers;
using Samples.Specifications.Server.Api.Models;
using Samples.Specifications.Server.Domain.Services.Storage;

namespace Samples.Specifications.Server.Api.Controllers
{
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly WarehouseMapper _warehouseMapper;
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(
            WarehouseMapper warehouseMapper,
            IWarehouseRepository warehouseRepository)
        {
            _warehouseMapper = warehouseMapper;
            _warehouseRepository = warehouseRepository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<WarehouseItemDto>> Get()
        {
            var warehouseItems = await _warehouseRepository.GetAll();
            return warehouseItems.Select(_warehouseMapper.MapToWarehouseItemDto);            
        }               
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]WarehouseItemDto warehouseItem)
        {
            await _warehouseRepository.Add(_warehouseMapper.MapToWarehouseItem(warehouseItem));
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]WarehouseItemDto warehouseItem)
        {
            await _warehouseRepository.Update(_warehouseMapper.MapToWarehouseItem(warehouseItem));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _warehouseRepository.GetById(id);
            await _warehouseRepository.Delete(item);
            return Ok();
        }
    }
}