using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.Navigation;
using LogoFX.Client.Mvvm.ViewModel.Services;

namespace Samples.Specifications.Client.Presentation.NavigationShell.ViewModels
{
    [UsedImplicitly]
    public sealed class ShellViewModel :
        Shell.ViewModels.ShellViewModel,
        INavigationConductor
    {
        #region Fields

        private readonly INavigationService _navigationService;

        #endregion

        #region Constructors

        public ShellViewModel(
            IWindowManager windowManager,
            INavigationService navigationService,
            IViewModelCreatorService viewModelCreatorService)
            :base(windowManager, viewModelCreatorService)
        {
            _navigationService = navigationService;
            _navigationService = navigationService;
            _navigationService.Navigated += (s, e) =>
            {
                NotifyOfPropertyChange(() => NavigationBackStack);
                NotifyOfPropertyChange(() => NavigationCurrentEntry);
            };

        }

        #endregion

        #region Public Properties

        public IEnumerable<INavigationStackEntry> NavigationBackStack
        {
            get { return _navigationService.BackStack.OfType<INavigationStackEntry>(); }
        }

        public INavigationStackEntry NavigationCurrentEntry
        {
            get { return _navigationService.CurrentEntry; }
        }

        #endregion

        #region Private Members

        #endregion

        #region Overrides

        protected override void OnLoggedInSuccessfully(object sender, EventArgs eventArgs)
        {
            _navigationService.Navigate(typeof(MainViewModel));
        }

        #endregion

        #region INavigationConductor

        public void NavigateTo(object viewModel, object argument)
        {
            ActivateItem((INotifyPropertyChanged) viewModel);
        }

        #endregion
    }
}