using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Domain.Models;
using Samples.Specifications.Server.Host.Data;
using Samples.Specifications.Server.Storage.Contracts;

namespace Samples.Specifications.Server.Host.Controllers
{
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        
        [HttpGet]
        public IEnumerable<WarehouseItemDto> Get()
        {
            return _warehouseRepository.GetAll().Select(t => 
            new WarehouseItemDto
            {
                Id = t.Id,
                Kind = t.Kind,
                Price = t.Price,
                Quantity = t.Quantity
            });            
        }               
        
        [HttpPost]
        public void Post([FromBody]WarehouseItemDto warehouseItem)
        {
            _warehouseRepository.Add(new WarehouseItem
            {
                Id = warehouseItem.Id,
                Kind = warehouseItem.Kind,
                Price = warehouseItem.Price,
                Quantity = warehouseItem.Quantity
            });
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]WarehouseItemDto warehouseItem)
        {
            _warehouseRepository.Update(new WarehouseItem
            {
                Id = warehouseItem.Id,
                Kind = warehouseItem.Kind,
                Price = warehouseItem.Price,
                Quantity = warehouseItem.Quantity
            });
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var item = _warehouseRepository.GetById(id);
            _warehouseRepository.Delete(item);
            return Ok();
        }
    }
}