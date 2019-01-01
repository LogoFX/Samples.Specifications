using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface IMainViewModel : INotifyPropertyChanged, IDisposable
    {
        ICommand NewCommand { get; }
        ICommand DeleteCommand { get; }
        IWarehouseItemContainerViewModel ActiveWarehouseItem { get; set; }
        IWarehouseItemsViewModel WarehouseItems { get; }
        IEventsViewModel Events { get; }
        bool IsActive { get; }
    }
}