using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Samples.Specifications.Server.Domain.Entities;
using Samples.Specifications.Server.Domain.Services.Storage;
using Samples.Specifications.Server.Storage.MongoDb.Models;

namespace Samples.Specifications.Server.Storage.MongoDb.Services
{
    public class MongoDbWarehouseRepository : IWarehouseRepository
    {
        private readonly IMongoDatabase _db;
        private const string DbName = "SamplesDB";

        public MongoDbWarehouseRepository(IMongoClient client) => _db = client.GetDatabase(DbName);

        public async Task<WarehouseItem> Add(WarehouseItem warehouseItem)
        {
            await GetCollection().InsertOneAsync(new MongoWarehouseItem
            {
                Id = new ObjectId(),
                ActualId = Guid.NewGuid(),
                Kind = warehouseItem.Kind,
                Price = warehouseItem.Price,
                Quantity = warehouseItem.Quantity
            });
            return warehouseItem;
        }

        public async Task<IEnumerable<WarehouseItem>> GetAll()
        {
            var rows = await GetCollection().Find(new FilterDefinitionBuilder<MongoWarehouseItem>().Empty)
                .ToListAsync();
            return rows.Select(t => new WarehouseItem
            {
                Kind = t.Kind,
                Price = t.Price,
                Quantity = t.Quantity,
                Id = t.ActualId
            });
        }

        public async Task<WarehouseItem> GetById(Guid id)
        {
            var item = await GetByIdInternal(id);
            return new WarehouseItem
            {
                Id = item.ActualId,
                Kind = item.Kind,
                Price = item.Price,
                Quantity = item.Quantity
            };
        }

        public async Task Delete(WarehouseItem warehouseItem)
        {
            var collection = GetCollection();
            await collection.DeleteOneAsync(
                Builders<MongoWarehouseItem>.Filter.Where(r => r.ActualId == warehouseItem.Id));
        }

        public async Task Update(WarehouseItem warehouseItem)
        {
            var collection = GetCollection();
            var oldItem = await GetByIdInternal(warehouseItem.Id);
            collection.FindOneAndReplace(Builders<MongoWarehouseItem>.Filter.Where(r => r.ActualId == warehouseItem.Id),
                new MongoWarehouseItem
                {
                    ActualId = warehouseItem.Id,
                    Id = oldItem.Id,
                    Kind = warehouseItem.Kind,
                    Price = warehouseItem.Price,
                    Quantity = warehouseItem.Quantity
                });
        }

        private IMongoCollection<MongoWarehouseItem> GetCollection() =>
            _db.GetCollection<MongoWarehouseItem>("WarehouseItems");

        private async Task<MongoWarehouseItem> GetByIdInternal(Guid id)
        {
            var collection = GetCollection();
            var cursor = await collection.FindAsync(Builders<MongoWarehouseItem>.Filter.Where(r => r.ActualId == id));
            return cursor.SingleOrDefault();
        }
    }
}
