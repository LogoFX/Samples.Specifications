#if REAL
using Samples.Specifications.Tests.Steps.Helpers;
#endif
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Steps
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<GeneralSteps, GeneralSteps>();
            iocContainer.RegisterSingleton<GivenLoginSteps, GivenLoginSteps>();
            iocContainer.RegisterSingleton<LoginSteps, LoginSteps>();            
            iocContainer.RegisterSingleton<MainSteps, MainSteps>();
            iocContainer.RegisterSingleton<ExitSteps, ExitSteps>();
#if REAL
            iocContainer.RegisterSingleton<ISetupHelper, MongoDbSetupHelper>();
#endif
        }
    }
}
