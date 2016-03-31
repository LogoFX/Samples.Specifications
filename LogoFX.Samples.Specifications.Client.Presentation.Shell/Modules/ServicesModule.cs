using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel.Contracts;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Client.Mvvm.ViewModelFactory.Unity;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell.Modules
{
    [UsedImplicitly]
    class ServicesModule : ICompositionModule<IIocContainer>
    {
        public void RegisterModule(IIocContainer iocContainer)
        {
            iocContainer.RegisterSingleton<IViewModelCreatorService, ViewModelCreatorService>();
            iocContainer.RegisterSingleton<IViewModelFactory, ViewModelFactory>();
        }
    }
}
