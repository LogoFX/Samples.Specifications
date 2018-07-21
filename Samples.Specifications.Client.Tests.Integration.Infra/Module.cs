using Attest.Testing.Contracts;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.Integration.xUnit;
using Samples.Specifications.Client.Data.Fake.Shared;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration.Infra
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {           
            dependencyRegistrator
                .AddSingleton<IBuilderRegistrationService, BuilderRegistrationService>()
                .AddSingleton<IStartApplicationService, StartApplicationService>()
                .RegisterBuilders();
        }
    }
}
