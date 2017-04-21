using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Samples.Specifications.Server.Host.Models;
using Samples.Specifications.Server.Storage;

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
            //return _warehouseRepository.GetAll();
            return new[]
            {
                new WarehouseItem
                {
                    Kind = "TV",
                    Price = 50,
                    Quantity = 4
                }
            };
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}