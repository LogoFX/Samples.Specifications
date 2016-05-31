using JetBrains.Annotations;
using Samples.Client.Data.Contracts.Providers;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Data.Real.Providers
{    
    [UsedImplicitly]
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<IWarehouseProvider, WarehouseProvider>();
        }
    }
}
