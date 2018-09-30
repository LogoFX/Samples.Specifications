using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Tests.Steps.Helpers;

namespace Samples.Specifications.Tests.Steps.Real.Helpers
{
    public sealed class MongoWarehouseItem
    {
        public ObjectId Id { get; set; }
        [BsonElement("Kind")]
        public string Kind { get; set; }
        [BsonElement("Price")]
        public double Price { get; set; }
        [BsonElement("Quantity")]
        public int Quantity { get; set; }
        [BsonElement("ActualId")]
        public Guid ActualId { get; set; }
    }

    public sealed class MongoUser
    {
        public ObjectId Id { get; set; }
        [BsonElement("Login")]
        public string Login { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }        
    }

    public sealed class MongoDbSetupHelper : ISetupHelper
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _db;
        private const string DbName = "SamplesDB";

        public MongoDbSetupHelper(IMongoClient client)
        {
            _client = client;       
            _db = _client.GetDatabase(DbName);                       
        }

        public void AddWarehouseItem(WarehouseItemDto warehouseItem)
        {
            _db.GetCollection<MongoWarehouseItem>("WarehouseItems").InsertOne(new MongoWarehouseItem
            {
                Id = new ObjectId(),
                ActualId = warehouseItem.Id,
                Kind = warehouseItem.Kind,
                Price = warehouseItem.Price,
                Quantity = warehouseItem.Quantity
            });            
        }

        public void AddUser(string login, string password)
        {
            _db.GetCollection<MongoUser>("Users").InsertOne(new MongoUser
            {
                Id = new ObjectId(),
                Login = login,
                Password = password,                
            });
        }       

        public void Initialize()
        {
            _client.DropDatabase(DbName);
        }
    }
}
