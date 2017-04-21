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
}
