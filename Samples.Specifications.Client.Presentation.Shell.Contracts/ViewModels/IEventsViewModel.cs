using System;
using System.Collections;
using System.Windows.Input;

namespace Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface IEventsViewModel : IDisposable
    {
        ICommand ClearCommand { get; }
        ICommand StartCommand { get; }
        ICommand StopCommand { get; }
        IEnumerable Events { get; }
    }
}
