using Samples.Specifications.Client.Tests.Integration.Domain.ScreenObjects;
using Samples.Specifications.Tests.Domain;
using Samples.Specifications.Tests.Domain.ScreenObjects;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Client.Tests.Integration.Domain
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
