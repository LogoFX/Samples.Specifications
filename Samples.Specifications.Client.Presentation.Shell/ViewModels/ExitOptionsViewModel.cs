﻿using System.Windows.Input;
using Caliburn.Micro;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Shared;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{    
    public class ExitOptionsViewModel : Screen, IExitOptionsViewModel
    {
        public ExitOptionsViewModel()
        {
            DisplayName = "Exit options";
        }

        public MessageResult Result { get; private set; }

        private IActionCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = ActionCommand<MessageResult>.When(r => true).Do(r =>
                {
                    Result = r;
                    TryClose(true);
                }));
            }
        }

        public void Dispose()
        {
            _closeCommand?.Dispose();
        }
    }
}
