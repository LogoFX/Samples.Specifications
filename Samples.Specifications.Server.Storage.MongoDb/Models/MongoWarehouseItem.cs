using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Samples.Specifications.Server.Storage.MongoDb.Models
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
}
