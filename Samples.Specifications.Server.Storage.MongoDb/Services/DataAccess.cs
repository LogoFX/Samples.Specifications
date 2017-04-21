using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Samples.Specifications.Server.Storage.MongoDb.Models;

namespace Samples.Specifications.Server.Storage.MongoDb.Services
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("EmployeeDB");
        }

        public IEnumerable<MongoWarehouseItem> GetAll()
        {
            return _db.GetCollection<MongoWarehouseItem>("WarehouseItems").FindAll();
        }

        public MongoWarehouseItem GetProduct(ObjectId id)
        {
            var res = Query<MongoWarehouseItem>.EQ(p => p.Id, id);
            return _db.GetCollection<MongoWarehouseItem>("WarehouseItems").FindOne(res);
        }

        public MongoWarehouseItem Create(MongoWarehouseItem p)
        {
            _db.GetCollection<MongoWarehouseItem>("WarehouseItems").Save(p);
            return p;
        }

        public void Update(ObjectId id, MongoWarehouseItem p)
        {
            p.Id = id;
            var res = Query<MongoWarehouseItem>.EQ(pd => pd.Id, id);
            var operation = Update<MongoWarehouseItem>.Replace(p);
            _db.GetCollection<MongoWarehouseItem>("WarehouseItems").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<MongoWarehouseItem>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<MongoWarehouseItem>("WarehouseItems").Remove(res);
        }
    }
}
