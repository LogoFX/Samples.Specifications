using LogoFX.Bootstrapping;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.SimpleContainer;
using Solid.Practices.IoC;

namespace Samples.Specifications.Client.Launcher.Shared
{    
    public static class BootstrapperExtensions
    {
        public static IBootstrapperWithContainerAdapter<TContainerAdapter> UseShared<TContainerAdapter>(
            this IBootstrapperWithContainerAdapter<TContainerAdapter> bootstrapper) where TContainerAdapter : IIocContainer
        {
            return bootstrapper.UseViewModelCreatorService().UseViewModelFactory();
        }
    }
}
