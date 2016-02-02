using System.Composition;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Client.Tests.EndToEnd.FakeData.Modularity;
using LogoFX.Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Providers
{
    [Export(typeof(ICompositionModule))]
    public class Module : ProvidersModuleBase<UnityContainerAdapter>
    {
        protected override void OnRegisterProviders(IIocContainer iocContainer)
        {
            base.OnRegisterProviders(iocContainer);
            RegisterAllBuilders(iocContainer, WarehouseProviderBuilder.CreateBuilder);            
        }
    }
}
