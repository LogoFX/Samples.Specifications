using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<LoginSteps, LoginSteps>();
            iocContainer.RegisterSingleton<MainSteps, MainSteps>();
            iocContainer.RegisterSingleton<GivenLoginSteps, GivenLoginSteps>();
            iocContainer.RegisterSingleton<GivenMainSteps, GivenMainSteps>();
        }
    }
}
