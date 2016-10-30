using LogoFX.Client.Mvvm.Navigation;
using LogoFX.Client.Mvvm.ViewModel.Services;
using Samples.Client.Model.Contracts;

namespace Samples.Specifications.Client.Presentation.NavigationShell.ViewModels
{
    [NavigationViewModel(ConductorType = typeof(ShellViewModel))]
    public sealed class MainViewModel : Shell.ViewModels.MainViewModel
    {
        public MainViewModel(IViewModelCreatorService viewModelCreatorService, IDataService dataService) 
            : base(viewModelCreatorService, dataService)
        {
        }
    }
}