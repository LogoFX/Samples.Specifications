using LogoFX.Client.Testing.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Real
{
    class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .AddSingleton<IStartApplicationService, StartApplicationService>()
                .AddSingleton<ISetupService, SetupService>();
        }
    }
}
