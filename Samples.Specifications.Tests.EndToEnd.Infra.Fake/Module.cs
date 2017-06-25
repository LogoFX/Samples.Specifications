using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd;
using LogoFX.Client.Testing.EndToEnd.FakeData;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Fake
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {                
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<IStartApplicationService, StartApplicationService.WithFakeProviders>();
            iocContainer.RegisterSingleton<IBuilderRegistrationService, BuilderRegistrationService>();
            Helper.RegisterBuilders(iocContainer);
        }        
    }
}
