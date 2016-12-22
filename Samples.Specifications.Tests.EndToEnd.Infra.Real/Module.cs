using LogoFX.Client.Testing.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;
using StartApplicationService = LogoFX.Client.Testing.EndToEnd.White.StartApplicationService;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Real
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterInstance<IStartApplicationService>(new StartApplicationService.WithRealProviders());
        }
    }
}
