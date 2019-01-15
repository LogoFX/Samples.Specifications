using System;
using System.Windows.Input;
using LogoFX.Client.Mvvm.ViewModel.Shared;

namespace Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface IExitOptionsViewModel : IDisposable
    {
        MessageResult Result { get; }
        ICommand CloseCommand { get; }
    }
}