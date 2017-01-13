using System;
using System.Windows.Input;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using LogoFX.Client.Mvvm.ViewModel.Services;
using Samples.Client.Model.Contracts;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class MainViewModel : BusyScreen
    {
        private readonly IViewModelCreatorService _viewModelCreatorService;
        private readonly IDataService _dataService;

        public MainViewModel(
            IViewModelCreatorService viewModelCreatorService,
            IDataService dataService)
        {
            _viewModelCreatorService = viewModelCreatorService;
            _dataService = dataService;

            NewWarehouseItem();
        }

        private ICommand _newCommand;

        public ICommand NewCommand
        {
            get
            {
                return _newCommand ?? (_newCommand = ActionCommand.Do(NewWarehouseItem));
            }
        }

        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??
                       (_deleteCommand = ActionCommand
                           .When(() => ActiveWarehouseItem is WarehouseItemViewModel)
                           .Do(DeleteSelectedItem)
                           .RequeryOnPropertyChanged(this, () => ActiveWarehouseItem));
            }
        }

        private EditableObjectViewModel<IWarehouseItem> _activeWarehouseItem;

        public EditableObjectViewModel<IWarehouseItem> ActiveWarehouseItem
        {
            get { return _activeWarehouseItem; }
            set
            {
                if (_activeWarehouseItem == value)
                {
                    return;
                }

                if (_activeWarehouseItem != null)
                {
                    _activeWarehouseItem.Saving -= OnSaving;
                    _activeWarehouseItem.Saved -= OnSaved;
                }

                _activeWarehouseItem = value;

                if (_activeWarehouseItem != null)
                {
                    _activeWarehouseItem.Saving += OnSaving;
                    _activeWarehouseItem.Saved += OnSaved;
                }

                NotifyOfPropertyChange();
            }
        }

        private async void OnSaved(object sender, ResultEventArgs e)
        {
            IsBusy = true;
            try
            {
                await _dataService.GetWarehouseItemsAsync();
            }

            finally
            {
                IsBusy = false;
            }
            NewWarehouseItem();
        }

        private void OnSaving(object sender, EventArgs e)
        {
            IsBusy = true;
        }

        private WarehouseItemsViewModel _warehouseItems;
        public WarehouseItemsViewModel WarehouseItems
        {
            get { return _warehouseItems ?? (_warehouseItems = CreateWarehouseItems()); }
        }

        private WarehouseItemsViewModel CreateWarehouseItems()
        {
            var warehouseItemsViewModel = _viewModelCreatorService.CreateViewModel<WarehouseItemsViewModel>();
            warehouseItemsViewModel.WarehouseItems.SelectionChanged += WarehouseItems_SelectionChanged;
            return warehouseItemsViewModel;
        }

        private void WarehouseItems_SelectionChanged(object sender, System.EventArgs e)
        {
            ActiveWarehouseItem = (WarehouseItemViewModel) WarehouseItems.WarehouseItems.SelectedItem;
        }

        private EventsViewModel _events;
        public EventsViewModel Events
        {
            get { return _events ?? (_events = CreateEvents()); }
        }

        private EventsViewModel CreateEvents()
        {
            return _viewModelCreatorService.CreateViewModel<EventsViewModel>();
        }

        private async void NewWarehouseItem()
        {            
            IsBusy = true;

            try
            {
                var warehouseItem = await _dataService.NewWarehouseItemAsync();
                var newItem = _viewModelCreatorService.CreateViewModel<IWarehouseItem, NewWarehouseItemViewModel>(warehouseItem);
                ActiveWarehouseItem = newItem;
            }

            finally
            {
                IsBusy = false;
            }
        }

        private async void DeleteSelectedItem()
        {            
            IsBusy = true;

            try
            {
                await _dataService.DeleteWarehouseItemAsync(ActiveWarehouseItem.Model);
            }

            finally
            {
                IsBusy = false;
            }

            NewWarehouseItem();
        }

        private async void Apply()
        {            
            IsBusy = true;

            try
            {
                await _dataService.SaveWarehouseItemAsync(ActiveWarehouseItem.Model);
                await _dataService.GetWarehouseItemsAsync();
            }

            finally
            {
                IsBusy = false;
            }
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();
            await _dataService.GetWarehouseItemsAsync();
        }
    }
}