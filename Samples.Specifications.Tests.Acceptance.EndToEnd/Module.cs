using Samples.Specifications.Tests.Acceptance.Contracts.ScreenObjects;
using Samples.Specifications.Tests.Acceptance.EndToEnd.ScreenObjects;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Acceptance.EndToEnd
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterSingleton<ILoginScreenObject, LoginScreenObject>();
            iocContainer.RegisterSingleton<IShellScreenObject, ShellScreenObject>();
            iocContainer.RegisterSingleton<IMainScreenObject, MainScreenObject>();
        }
    }
}
