using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.FakeData;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Fake
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator.AddSingleton<IStartApplicationService, StartApplicationService>()
                .AddSingleton<IBuilderRegistrationService, BuilderRegistrationService>();
        }
    }
}
