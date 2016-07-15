using LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.ScreenObjects.EndToEnd
{
    class Module : ICompositionModule<IIocContainerRegistrator>
    {
        public void RegisterModule(IIocContainerRegistrator iocContainer)
        {
            iocContainer.RegisterInstance<ILoginScreenObject>(new LoginScreenObject());
            iocContainer.RegisterInstance<IShellScreenObject>(new ShellScreenObject());
            iocContainer.RegisterInstance<IMainScreenObject>(new MainScreenObject());
        }
    }
}
