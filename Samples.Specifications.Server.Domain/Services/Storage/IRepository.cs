using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Samples.Specifications.Server.Domain.Models;

namespace Samples.Specifications.Server.Domain.Services.Storage
{
    public interface IWarehouseRepository
    {
        Task<WarehouseItem> Add(WarehouseItem warehouseItem);
        Task<IEnumerable<WarehouseItem>> GetAll();
        Task<WarehouseItem> GetById(Guid id);
        Task Delete(WarehouseItem warehouseItem);
        Task Update(WarehouseItem warehouseItem);
    }
}
