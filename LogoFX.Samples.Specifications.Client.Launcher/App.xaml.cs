using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.Unity;

namespace LogoFX.Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App()
        {
            var container = new UnityContainerAdapter();
            var bootstrapper = new AppBootstrapper(container);

            bootstrapper
                .UseViewModelCreatorService()
                .UseViewModelFactory()
                .UseResolver(container);
            bootstrapper.Initialize();
        }
    }
}
