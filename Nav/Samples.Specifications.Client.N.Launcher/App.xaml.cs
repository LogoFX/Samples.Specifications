using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using LogoFX.Client.Mvvm.Navigation;
using Samples.Specifications.Client.Launcher.Shared;
using Samples.Specifications.Client.Presentation.NavigationShell.ViewModels;

namespace Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App()
        {
            var containerAdapter = new ExtendedSimpleContainerAdapter();

            var bootstrapper = new AppBootstrapper(containerAdapter);
            bootstrapper
                .UseResolver()
                .UseShared()
                .UseNavigation<ShellViewModel, ExtendedSimpleContainerAdapter>(containerAdapter)
                .Initialize();
        }
    }
}
