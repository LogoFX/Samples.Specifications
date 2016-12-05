using JetBrains.Annotations;
using LogoFX.Client.Testing.EndToEnd.FakeData.Modularity;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.IoC;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Providers
{    
    [UsedImplicitly]
    public class Module : ProvidersModuleBase
    {
        protected override void OnRegisterProviders(IIocContainerRegistrator iocContainer)
        {
            base.OnRegisterProviders(iocContainer);
            RegisterAllBuilders(iocContainer, LoginProviderBuilder.CreateBuilder);
            RegisterAllBuilders(iocContainer, WarehouseProviderBuilder.CreateBuilder);            
        }
    }
}
