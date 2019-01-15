using System;
using System.Windows.Input;

namespace Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface IShellViewModel : IDisposable
    {
        ICommand CloseCommand { get; }
        ILoginViewModel LoginViewModel { get; }
        IMainViewModel MainViewModel { get; }
    }
}