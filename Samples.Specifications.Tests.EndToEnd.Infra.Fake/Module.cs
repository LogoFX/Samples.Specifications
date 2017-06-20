using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.FakeData;
using LogoFX.Client.Testing.EndToEnd.White;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Fake
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {                
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterInstance<IStartApplicationService>(new StartApplicationService.WithFakeProviders());
            iocContainer.RegisterInstance<IBuilderRegistrationService>(new BuilderRegistrationService());
            Helper.RegisterBuilders(iocContainer);
        }        
    }
}
