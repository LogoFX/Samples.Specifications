using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd.White;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Real
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterInstance<IStartApplicationService>(new StartApplicationService.WithRealProviders());
        }
    }
}
