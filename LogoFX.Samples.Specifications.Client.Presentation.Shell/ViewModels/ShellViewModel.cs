using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel.Services;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class ShellViewModel : Conductor<INotifyPropertyChanged>.Collection.OneActive
    {
        private readonly IViewModelCreatorService _viewModelCreatorService;

        public ShellViewModel(IViewModelCreatorService viewModelCreatorService)
        {
            _viewModelCreatorService = viewModelCreatorService;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Items.Add(_viewModelCreatorService.CreateViewModel<MainViewModel>());
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            ActivateItem(Items.First());
        }
    }
}
