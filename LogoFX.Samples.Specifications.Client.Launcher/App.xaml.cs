using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.Unity;

namespace LogoFX.Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App()
        {
            var bootstrapper = new AppBootstrapper();
            bootstrapper.UseViewModelCreatorService().UseViewModelFactory();
            bootstrapper.Initialize();
        }
    }
}
