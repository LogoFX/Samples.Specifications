using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer;

namespace Samples.Specifications.Client.Launcher
{
    partial class App
    {
        public App()
        {            
            var bootstrapper = new AppBootstrapper(new ExtendedSimpleContainerAdapter());
            bootstrapper.UseResolver().UseViewModelCreatorService().UseViewModelFactory().Initialize();            
        }
    }
}
