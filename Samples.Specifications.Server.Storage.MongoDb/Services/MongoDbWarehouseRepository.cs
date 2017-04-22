using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Samples.Specifications.Server.Domain.Models;
using Samples.Specifications.Server.Domain.Services.Storage;
using Samples.Specifications.Server.Storage.MongoDb.Models;

namespace Samples.Specifications.Server.Storage.MongoDb.Services
{
    public class MongoDbWarehouseRepository : IWarehouseRepository
    {
        readonly MongoDatabase _db;

        public MongoDbWarehouseRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var server = client.GetServer();
            _db = server.GetDatabase("SamplesDB");
        }

        public WarehouseItem Add(WarehouseItem warehouseItem)
        {
            GetCollection().Save(new MongoWarehouseItem
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
            var rows = GetCollection().FindAll().ToArray();
            return rows.Select(t => new WarehouseItem
            {
                Kind = t.Kind,
                Price = t.Price,
                Quantity = t.Quantity,
                Id = t.ActualId
            });
        }

        public WarehouseItem GetById(Guid id)
        {
            var item = GetByIdInternal(id);
            return new WarehouseItem
            {
                Id = item.ActualId,
                Kind = item.Kind,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        public void Delete(WarehouseItem warehouseItem)
        {
            var collection = GetCollection();
            var query = Query<MongoWarehouseItem>.EQ(e => e.ActualId, warehouseItem.Id);
            collection.Remove(query);
        }

        public void Update(WarehouseItem warehouseItem)
        {
            var collection = GetCollection();
            var query = Query<MongoWarehouseItem>.EQ(e => e.ActualId, warehouseItem.Id);
            var oldItem = GetByIdInternal(warehouseItem.Id);
            var operation = Update<MongoWarehouseItem>.Replace(new MongoWarehouseItem
            {
                ActualId = warehouseItem.Id,
                Id = oldItem.Id,
                Kind = warehouseItem.Kind,
                Price = warehouseItem.Price,
                Quantity = warehouseItem.Quantity
            });
            collection.Update(query, operation);
        }

        private MongoCollection<MongoWarehouseItem> GetCollection()
        {
            return _db.GetCollection<MongoWarehouseItem>("WarehouseItems");
        }

        private MongoWarehouseItem GetByIdInternal(Guid id)
        {
            var collection = GetCollection();
            var query = Query<MongoWarehouseItem>.EQ(e => e.ActualId, id);
            var rows = collection.Find(query);
            return rows.SingleOrDefault();
        }
    }
}
