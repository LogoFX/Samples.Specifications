using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Real
{
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator)
        {
            dependencyRegistrator
                .RegisterSingleton<IStartApplicationService, StartApplicationService.WithRealProviders>();
        }
    }
}
