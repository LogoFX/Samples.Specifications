using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer;
using LogoFX.Practices.IoC;
using Samples.Client.Model.Shared;
using Solid.Bootstrapping;

namespace Samples.Specifications.Client.Launcher.Shared
{    
    public static class BootstrapperExtensions
    {
        public static IInitializable UseShared(
            this IBootstrapperWithContainer<ExtendedSimpleContainerAdapter, ExtendedSimpleContainer> bootstrapper)             
        {
            return bootstrapper.UseSimpleCompositionModules(() => UserContext.Current)
                .UseViewModelCreatorService()
                .UseViewModelFactory();
        }
    }    
}
