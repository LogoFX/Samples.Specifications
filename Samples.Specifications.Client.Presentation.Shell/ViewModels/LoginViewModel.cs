using System;
using System.Windows.Input;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;
using Samples.Specifications.Client.Presentation.Shell.Properties;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{    
    [UsedImplicitly]
    public sealed class LoginViewModel : BusyScreen, ILoginViewModel
    {
        private readonly ILoginService _loginService;

        public LoginViewModel(
            ILoginService loginService)
        {
            SavePassword = Settings.Default.SavePassword;
            UserName = Settings.Default.SavedUsername;
            Password = SavePassword ? Settings.Default.SavedPassword : string.Empty;
            _loginService = loginService;
            DisplayName = "Login View";
        }

        public event EventHandler LoggedInSuccessfully;

        private IActionCommand _loginCommand;
        public ICommand LoginCommand =>
            CommandFactory.GetCommand(ref _loginCommand,                
                async () =>
                {
                    LoginFailureCause = null;

                    try
                    {
                        IsBusy = true;
                        await _loginService.LoginAsync(UserName, Password);
                        OnLoginSuccess();
                    }

                    catch (Exception ex)
                    {
                        LoginFailureCause = "Failed to log in: " + ex.Message;
                    }

                    finally
                    {
                        Password = string.Empty;
                        IsBusy = false;
                    }
                }, 
                () => !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password));

        private IActionCommand _cancelCommand;
        public ICommand LoginCancelCommand =>
            CommandFactory.GetCommand(ref _cancelCommand, () => TryClose());

        private bool _savePassword;
        public bool SavePassword
        {
            get => _savePassword;
            set
            {
                if (_savePassword == value)
                {
                    return;
                }

                _savePassword = value;
                NotifyOfPropertyChange();
            }
        }

        private string _loginFailureCause;
        public string LoginFailureCause
        {
            get => _loginFailureCause;
            set
            {
                if (_loginFailureCause == value)
                    return;

                _loginFailureCause = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(() => IsLoginFailureTextVisible);
            }
        }

        public bool IsLoginFailureTextVisible => string.IsNullOrWhiteSpace(LoginFailureCause) == false;

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                NotifyOfPropertyChange();
            }
        }
       
        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                if (_password == value)
                    return;

                _password = value;
                NotifyOfPropertyChange();
            }
        }        
                
        private void OnLoginSuccess()
        {
            Settings.Default.SavePassword = SavePassword;
            Settings.Default.SavedUsername = UserName;
            Settings.Default.SavedPassword = SavePassword ? Password : string.Empty;

            TryClose(true);
            LoggedInSuccessfully?.Invoke(this, new EventArgs());
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            if (close)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _cancelCommand.Dispose();
            _loginCommand.Dispose();
        }
    }
}
