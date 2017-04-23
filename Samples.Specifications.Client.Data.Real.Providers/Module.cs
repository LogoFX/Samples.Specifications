using System;
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
            iocContainer.RegisterHandler<RestClient>(() => new RestClient(RetrieveEndpoint()));
        }

        private string RetrieveEndpoint()
        {
            Configuration config = null;
            string exeConfigPath = GetType().Assembly.Location;
            try
            {
                config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
            }
            catch (Exception ex)
            {
                //handle errror here.. means DLL has no sattelite configuration file.
            }
            return config != null ? GetAppSetting(config, "ServerEndpoint") : string.Empty;
        }

        string GetAppSetting(Configuration config, string key)
        {
            var element = config.AppSettings.Settings[key];
            var value = element?.Value;
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }
    }


}
