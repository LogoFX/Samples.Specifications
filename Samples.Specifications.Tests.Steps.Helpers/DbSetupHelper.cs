using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Samples.Client.Data.Contracts.Dto;

namespace Samples.Specifications.Tests.Steps.Helpers
{
    public class MongoWarehouseItem
    {
        public ObjectId Id { get; set; }
        [BsonElement("Kind")]
        public string Kind { get; set; }
        [BsonElement("Price")]
        public double Price { get; set; }
        [BsonElement("Quantity")]
        public int Quantity { get; set; }
    }

    public class DbSetupHelper
    {
        private readonly IMongoDatabase _db;

        public DbSetupHelper()
        {
            var client = new MongoClient("mongodb://localhost:27017");       
            _db = client.GetDatabase("WarehouseDB");                       
        }

        public void Add(WarehouseItemDto warehouseItem)
        {
            _db.GetCollection<MongoWarehouseItem>("WarehouseItems").InsertOne(new MongoWarehouseItem
            {
                Id = new ObjectId(),
                Kind = warehouseItem.Kind,
                Price = warehouseItem.Price,
                Quantity = warehouseItem.Quantity
            });            
        }

        public void Clear()
        {
            _db.DropCollection("WarehouseItems");
        }     
    }
}
