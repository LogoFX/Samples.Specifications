using System.Configuration;
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
            dependencyRegistrator.RegisterSingleton<ILoginProvider, LoginProvider>();
            dependencyRegistrator.RegisterSingleton<IWarehouseProvider, WarehouseProvider>();
            dependencyRegistrator.RegisterSingleton<IEventsProvider, EventsProvider>();
            dependencyRegistrator.RegisterSingleton(() => new RestClient(RetrieveEndpoint()));
        }

        private string RetrieveEndpoint()
        {
            return Settings.Default.ServerEndpoint;
            //TODO: This doesn't work in case of Integration Tests - The runner doesn't copy the .config file to the temporary folder
            //var exeConfigPath = GetType().Assembly.Location;
            //var config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);
            //return GetAppSetting(config, "ServerEndpoint");
        }

        private string GetAppSetting(Configuration config, string key)
        {
            var element = config.AppSettings.Settings[key];
            var value = element?.Value;
            return string.IsNullOrEmpty(value) ? string.Empty : value;
        }
    }


}
