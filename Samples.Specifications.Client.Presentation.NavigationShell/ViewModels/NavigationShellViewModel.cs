using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Core;
using Samples.Client.Model.Shared;
using Samples.Specifications.Client.Presentation.NavigationShell.Properties;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;
using Solid.Practices.Scheduling;

namespace Samples.Specifications.Client.Presentation.NavigationShell.ViewModels
{
    [UsedImplicitly]
    public sealed class NavigationShellViewModel : Conductor<INotifyPropertyChanged>.Collection.OneActive
    {
        #region Fields

        private readonly IWindowManager _windowManager;
        private readonly IViewModelCreatorService _viewModelCreatorService;

        #endregion

        #region Constructors

        public NavigationShellViewModel(
            IWindowManager windowManager,
            IViewModelCreatorService viewModelCreatorService)
        {
            _windowManager = windowManager;
            _viewModelCreatorService = viewModelCreatorService;

            EventHandler strongHandler = OnLoggedInSuccessfully;
            LoginViewModel.LoggedInSuccessfully += WeakDelegate.From(strongHandler);
        }

        #endregion

        #region Commands

        private ICommand _closeCommand;

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ??
                       (_closeCommand = ActionCommand
                           .Do(() =>
                           {
                               TryClose();
                           }));
            }
        }

        #endregion

        #region Public Properties

        public override string DisplayName
        {
            get { return string.Empty; }
            set { }
        }

        private LoginViewModel _loginViewModel;
        public LoginViewModel LoginViewModel
        {
            get { return _loginViewModel ?? (_loginViewModel = CreateLoginViewModel()); }
        }

        private LoginViewModel CreateLoginViewModel()
        {
            return _viewModelCreatorService.CreateViewModel<LoginViewModel>();
        }

        private MainViewModel _mainViewModel;
        public MainViewModel MainViewModel
        {
            get { return _mainViewModel ?? (_mainViewModel = CreateMainViewModel()); }
        }

        private MainViewModel CreateMainViewModel()
        {
            return _viewModelCreatorService.CreateViewModel<MainViewModel>();
        }

        #endregion

        #region Private Members

        private async Task Close()
        {
            await TaskRunner.RunAsync(() => Dispatch.Current.OnUiThread(() =>
            {
                TryClose();
            }));
        }

        private void OnLoggedInSuccessfully(object sender, EventArgs eventArgs)
        {
            ActivateItem(MainViewModel);
        }

        #endregion

        #region Overrides

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            _windowManager.ShowDialog(LoginViewModel);

            if (UserContext.Current == null)
            {
                await Close();
            }
        }

        protected override void OnDeactivate(bool close)
        {
            if (close)
            {
                Settings.Default.Save();
            }

            base.OnDeactivate(close);
        }

        #endregion
    }
}