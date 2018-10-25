using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer;
using Solid.Bootstrapping;

namespace Samples.Specifications.Client.Launcher.Shared
{    
    public static class BootstrapperExtensions
    {
        public static IInitializable UseShared(
            this IBootstrapperWithContainerAdapter<ExtendedSimpleContainerAdapter> bootstrapper) => bootstrapper
            .UseViewModelCreatorService()
            .UseViewModelFactory();
    }
}
