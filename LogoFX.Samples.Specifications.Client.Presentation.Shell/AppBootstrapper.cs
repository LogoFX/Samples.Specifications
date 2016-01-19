using Caliburn.Micro;
using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleInjector;
using LogoFX.Client.Mvvm.ViewModel.Contracts;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.SimpleInjector;
using LogoFX.Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell
{
    public class AppBootstrapper : BootstrapperContainerBase<ShellViewModel, SimpleInjectorAdapter>
    {
        public AppBootstrapper() 
            : base(new SimpleInjectorAdapter(), useApplication : true, reuseCompositionInformation : false)
        {
        }

        protected override void OnConfigure(SimpleInjectorAdapter iocContainerAdapter)
        {
            base.OnConfigure(iocContainerAdapter);
            iocContainerAdapter.RegisterSingleton<IWindowManager, WindowManager>();
            iocContainerAdapter.RegisterSingleton<IViewModelCreatorService, ViewModelCreatorService>();
            iocContainerAdapter.RegisterSingleton<IViewModelFactory, ViewModelFactory>();
        }
    }
}
