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

    public class MongoUser
    {
        public ObjectId Id { get; set; }
        [BsonElement("Login")]
        public string Login { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }        
    }

    public class DbSetupHelper
    {
        private readonly IMongoDatabase _db;

        public DbSetupHelper()
        {
            var client = new MongoClient("mongodb://localhost:27017");       
            _db = client.GetDatabase("SamplesDB");                       
        }

        public void AddWarehouseItem(WarehouseItemDto warehouseItem)
        {
            _db.GetCollection<MongoWarehouseItem>("WarehouseItems").InsertOne(new MongoWarehouseItem
            {
                Id = new ObjectId(),
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

        public void ClearUsers()
        {            
            _db.DropCollection("Users");
        }

        public void ClearWarehouseItems()
        {
            _db.DropCollection("WarehouseItems");
        }  
    }
}
