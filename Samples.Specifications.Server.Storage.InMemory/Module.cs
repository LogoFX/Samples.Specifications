using Microsoft.Extensions.DependencyInjection;
using Samples.Specifications.Server.Storage.InMemory.Services;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Server.Storage.InMemory
{
    class Module : ICompositionModule<IServiceCollection>
    {
        public void RegisterModule(IServiceCollection dependencyRegistrator)
        {
            dependencyRegistrator.AddDbContext<WarehouseContext>(s => s.UseInMemoryDatabase());
        }
    }
}
