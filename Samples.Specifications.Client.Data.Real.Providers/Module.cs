using JetBrains.Annotations;
using RestSharp;
using Samples.Client.Data.Contracts.Providers;
using Samples.Specifications.Client.Data.Real.Providers.Properties;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Data.Real.Providers
{    
    [UsedImplicitly]
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<ILoginProvider, LoginProvider>()
                .AddSingleton<IWarehouseProvider, WarehouseProvider>()
                .AddSingleton<IEventsProvider, EventsProvider>()
                .AddSingleton(() => new RestClient(Settings.Default.ServerEndpoint));
        }             
    }
}
