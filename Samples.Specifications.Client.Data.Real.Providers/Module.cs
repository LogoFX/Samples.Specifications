using System.Configuration;
using JetBrains.Annotations;
using RestSharp;
using Samples.Client.Data.Contracts.Providers;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Data.Real.Providers
{    
    [UsedImplicitly]
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<ILoginProvider, LoginProvider>();
            iocContainer.RegisterSingleton<IWarehouseProvider, WarehouseProvider>();
            iocContainer.RegisterSingleton<IEventsProvider, EventsProvider>();
            iocContainer.RegisterSingleton<RestClient>(() => new RestClient(RetrieveEndpoint()));
        }

        private string RetrieveEndpoint()
        {            
            var exeConfigPath = GetType().Assembly.Location;
            var config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
            return GetAppSetting(config, "ServerEndpoint");
        }

        private string GetAppSetting(Configuration config, string key)
        {
            var element = config.AppSettings.Settings[key];
            var value = element?.Value;
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }
    }


}
