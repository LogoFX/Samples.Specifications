using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Samples.Specifications.Server.Domain.Services.Storage;
using Samples.Specifications.Server.Storage.MongoDb.Services;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Server.Storage.MongoDb
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            dependencyRegistrator.AddTransient<IWarehouseRepository, MongoDbWarehouseRepository>();
            dependencyRegistrator.AddTransient<IUserRepository, MongoDbUserRepository>();
            //TODO: put into configuration
            dependencyRegistrator.AddTransient(r => new MongoClient("mongodb://localhost:27017"));
        }
    }
}
