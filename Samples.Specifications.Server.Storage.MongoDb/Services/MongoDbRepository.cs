using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Samples.Specifications.Server.Storage.Contracts;
using Samples.Specifications.Server.Storage.Contracts.Models;
using Samples.Specifications.Server.Storage.MongoDb.Models;

namespace Samples.Specifications.Server.Storage.MongoDb.Services
{
    public class MongoDbRepository : IWarehouseRepository
    {
        readonly MongoDatabase _db;

        public MongoDbRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var server = client.GetServer();
            _db = server.GetDatabase("WarehouseDB");
        }

        public WarehouseItem Add(WarehouseItem warehouseItem)
        {
            _db.GetCollection<MongoWarehouseItem>("WarehouseItems").Save(new MongoWarehouseItem
            {
                Id = new ObjectId(),
                Kind = warehouseItem.Kind,
                Price = warehouseItem.Price,
                Quantity = warehouseItem.Quantity
            });
            return warehouseItem;
        }

        public IEnumerable<WarehouseItem> GetAll()
        {
            var rows = _db.GetCollection<MongoWarehouseItem>("WarehouseItems").FindAll().ToArray();
            return rows.Select(t => new WarehouseItem
            {
                Kind = t.Kind,
                Price = t.Price,
                Quantity = t.Quantity
            });
        }

        public WarehouseItem GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(WarehouseItem warehouseItem)
        {
            throw new System.NotImplementedException();
        }

        public void Update(WarehouseItem warehouseItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
