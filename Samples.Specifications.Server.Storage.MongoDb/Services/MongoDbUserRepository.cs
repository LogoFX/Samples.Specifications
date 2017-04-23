using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Samples.Specifications.Server.Domain.Models;
using Samples.Specifications.Server.Domain.Services.Storage;
using MongoUser = Samples.Specifications.Server.Storage.MongoDb.Models.MongoUser;

namespace Samples.Specifications.Server.Storage.MongoDb.Services
{
    public class MongoDbUserRepository : IUserRepository
    {
        private readonly MongoDatabase _db;

        public MongoDbUserRepository(MongoClient client)
        {                        
            var server = client.GetServer();
            _db = server.GetDatabase("SamplesDB");
        }

        public IEnumerable<User> GetAll()
        {
            var rows = _db.GetCollection<MongoUser>("Users").FindAll().ToArray();
            return rows.Select(t => new User
            {
                Login = t.Login,
                Password = t.Password
            });
        }
    }
}