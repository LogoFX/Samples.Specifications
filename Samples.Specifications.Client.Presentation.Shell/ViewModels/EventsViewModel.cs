using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{    
    public sealed class EventsViewModel : BusyScreen, IEventsViewModel
    {
        private readonly IDataService _dataService;        

        public EventsViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        private IActionCommand _clearCommand;
        public ICommand ClearCommand =>
            CommandFactory.GetCommand(ref _clearCommand, async () =>
            {
                IsBusy = true;

                try
                {
                    await _dataService.ClearEventsAsync();
                }

                finally
                {
                    IsBusy = false;
                }
            });        

        private IActionCommand _startCommand;
        public ICommand StartCommand =>
            CommandFactory.GetCommand(ref _startCommand,
                    () => _dataService.StartEventMonitoring(),
                    () => !_dataService.EventMonitoringStarted
                    )
                .RequeryOnPropertyChanged(this, () => _dataService.EventMonitoringStarted);    

        private IActionCommand _stopCommand;
        public ICommand StopCommand =>
            CommandFactory.GetCommand(ref _stopCommand,
                    () => _dataService.StopEventMonitoring(),
                    () => _dataService.EventMonitoringStarted
                    )
                .RequeryOnPropertyChanged(this, () => _dataService.EventMonitoringStarted);

        private IEnumerable _events;
        public IEnumerable Events => _events ?? (_events = CreateEvents());

        private IEnumerable CreateEvents()
        {
            var result = new WrappingCollection
            {
                FactoryMethod = o => new EventViewModel((IEvent) o)
            };
            result.AddSource(_dataService.Events);

            var view = result.AsView();
            view.SortDescriptions.Add(new SortDescription("Time", ListSortDirection.Descending));

            return view;
        }

        public void Dispose()
        {
            _clearCommand?.Dispose();
            _startCommand?.Dispose();
            _stopCommand?.Dispose();
        }
    }
}