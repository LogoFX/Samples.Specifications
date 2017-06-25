using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Real
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<IStartApplicationService, StartApplicationService.WithRealProviders>();
        }
    }
}
