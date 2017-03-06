using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Unity;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.Unity;
using LogoFX.Practices.IoC;
using Microsoft.Practices.Unity;
using Samples.Client.Model.Shared;
using Solid.Bootstrapping;

namespace Samples.Specifications.Client.Launcher.Shared
{    
    public static class BootstrapperExtensions
    {
        public static IInitializable UseShared(
            this IBootstrapperWithContainer<UnityContainerAdapter, UnityContainer> bootstrapper)             
        {
            return bootstrapper.UseSimpleCompositionModules(() => UserContext.Current)
                .UseViewModelCreatorService()
                .UseViewModelFactory();
        }
    }    
}
