using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Domain.Models;
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
        public IEnumerable<WarehouseItem> Get()
        {
            return _warehouseRepository.GetAll();            
        }               
        
        [HttpPost]
        public void Post([FromBody]WarehouseItem warehouseItem)
        {
            _warehouseRepository.Add(warehouseItem);
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]WarehouseItem warehouseItem)
        {
            _warehouseRepository.Update(warehouseItem);
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