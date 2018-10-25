using JetBrains.Annotations;
using MongoDB.Driver;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps.Real.Helpers
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .AddSingleton<ISetupHelper, MongoDbSetupHelper>()
            //TODO: put into configuration
            .AddTransient<IMongoClient>(() => new MongoClient("mongodb://localhost:27017"));
    }
}
