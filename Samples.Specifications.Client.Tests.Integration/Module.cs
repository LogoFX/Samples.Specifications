using Samples.Specifications.Client.Tests.Integration.ScreenObjects;
using Samples.Specifications.Tests.Acceptance.Contracts;
using Samples.Specifications.Tests.Acceptance.Contracts.ScreenObjects;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<ILoginScreenObject, LoginScreenObject>();
            iocContainer.RegisterSingleton<IMainScreenObject, MainScreenObject>();
            iocContainer.RegisterSingleton<IStartClientApplicationService, StartClientApplicationService>();
        }
    }
}
