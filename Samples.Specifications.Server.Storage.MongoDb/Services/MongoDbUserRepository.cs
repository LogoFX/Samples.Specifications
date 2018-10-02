using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Samples.Specifications.Server.Domain.Entities;
using Samples.Specifications.Server.Domain.Services.Storage;
using Samples.Specifications.Server.Storage.MongoDb.Models;

namespace Samples.Specifications.Server.Storage.MongoDb.Services
{
    public class MongoDbUserRepository : IUserRepository
    {
        private readonly IMongoDatabase _db;
        private const string DbName = "SamplesDB";

        public MongoDbUserRepository(IMongoClient client)
        {                                    
            _db = client.GetDatabase(DbName);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var rows = await GetCollection().Find(new FilterDefinitionBuilder<MongoUser>().Empty).ToListAsync();
            return rows.Select(t => new User
            {
                Login = t.Login,
                Password = t.Password
            });
        }

        private IMongoCollection<MongoUser> GetCollection()
        {
            return _db.GetCollection<MongoUser>("Users");
        }
    }
}