using System.Collections.Generic;
using Samples.Specifications.Server.Storage.Contracts.Models;

namespace Samples.Specifications.Server.Storage.Contracts
{
    public interface IWarehouseRepository
    {
        WarehouseItem Add(WarehouseItem warehouseItem);
        IEnumerable<WarehouseItem> GetAll();
        WarehouseItem GetById(int id);
        void Delete(WarehouseItem warehouseItem);
        void Update(WarehouseItem warehouseItem);
    }
}
