using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Storage.Contracts;
using Samples.Specifications.Server.Storage.Contracts.Models;

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
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]WarehouseItem warehouseItem)
        {
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}