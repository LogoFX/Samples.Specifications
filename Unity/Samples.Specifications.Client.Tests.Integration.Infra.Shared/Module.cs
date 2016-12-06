using LogoFX.Client.Testing.Contracts;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Shared
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<IStartApplicationService, StartApplicationService>();
            iocContainer.RegisterInstance(LoginProviderBuilder.CreateBuilder());
            iocContainer.RegisterInstance(WarehouseProviderBuilder.CreateBuilder());
        }
    }
}
