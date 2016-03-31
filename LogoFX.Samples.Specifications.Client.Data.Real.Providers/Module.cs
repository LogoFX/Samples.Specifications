using JetBrains.Annotations;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Data.Real.Providers
{    
    [UsedImplicitly]
    class Module : ICompositionModule<IIocContainer>
    {
        public void RegisterModule(IIocContainer iocContainer)
        {
            iocContainer.RegisterSingleton<IWarehouseProvider, WarehouseProvider>();
        }
    }
}
