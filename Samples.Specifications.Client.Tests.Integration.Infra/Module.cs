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
            dependencyRegistrator.RegisterSingleton<IBuilderRegistrationService, BuilderRegistrationService>();
            dependencyRegistrator.RegisterSingleton<IStartApplicationService, StartApplicationService>();
            Helper.RegisterBuilders(dependencyRegistrator);
        }
    }
}
