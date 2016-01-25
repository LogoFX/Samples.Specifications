using System.ComponentModel.Composition;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Data.Real.Providers
{
    [Export(typeof(ICompositionModule))]
    class Module : ICompositionModule<UnityContainerAdapter>
    {
        public void RegisterModule(UnityContainerAdapter iocContainer)
        {
            iocContainer.RegisterSingleton<IWarehouseProvider, WarehouseProvider>();
        }
    }
}
