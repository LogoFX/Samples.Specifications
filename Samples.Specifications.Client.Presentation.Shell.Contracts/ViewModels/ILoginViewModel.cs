using System;
using System.Windows.Input;

namespace Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface ILoginViewModel : IDisposable
    {
        ICommand LoginCommand { get; }
        ICommand LoginCancelCommand { get; }
        string UserName { get; set; }
        string Password { get; set; }
        bool IsActive { get; }
        string LoginFailureCause { get; }
        event EventHandler LoggedInSuccessfully;
    }
}