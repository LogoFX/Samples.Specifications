using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.FakeData;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Client.Data.Fake.ProviderBuilders;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Fake
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            ;iocContainer.RegisterInstance<IStartApplicationService>(new StartApplicationService.WithFakeProviders());
            iocContainer.RegisterInstance<IBuilderRegistrationService>(new BuilderRegistrationService());
            iocContainer.RegisterInstance(LoginProviderBuilder.CreateBuilder());
            iocContainer.RegisterInstance(WarehouseProviderBuilder.CreateBuilder());
        }
    }
}
