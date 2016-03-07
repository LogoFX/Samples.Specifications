using Caliburn.Micro;
using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Client.Mvvm.ViewModel.Contracts;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.Unity;
using LogoFX.Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell
{
    public class AppBootstrapper : BootstrapperContainerBase<ShellViewModel, UnityContainerAdapter>
    {
        public AppBootstrapper() 
            : base(new UnityContainerAdapter(), useApplication : true, reuseCompositionInformation : false)
        {
        }

        protected override void OnConfigure(UnityContainerAdapter iocContainerAdapter)
        {
            base.OnConfigure(iocContainerAdapter);
            iocContainerAdapter.RegisterSingleton<IWindowManager, WindowManager>();
            iocContainerAdapter.RegisterSingleton<IViewModelCreatorService, ViewModelCreatorService>();
            iocContainerAdapter.RegisterSingleton<IViewModelFactory, ViewModelFactory>();
        }        
    }
}
