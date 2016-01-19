using System.Collections;
using Caliburn.Micro;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel;
using LogoFX.Client.Mvvm.ViewModel.Services;
using LogoFX.Samples.Specifications.Client.Model.Contracts;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class WarehouseItemsViewModel : PropertyChangedBase
    {
        private readonly IDataService _dataService;
        private readonly IViewModelCreatorService _viewModelCreatorService;

        public WarehouseItemsViewModel(
            IDataService dataService,
            IViewModelCreatorService viewModelCreatorService)
        {
            _dataService = dataService;
            _viewModelCreatorService = viewModelCreatorService;
        }

        private WrappingCollection _warehouseItems;
        public IEnumerable WarehouseItems
        {
            get { return _warehouseItems ?? (_warehouseItems = CreateWarehouseItems()); }
        }

        private WrappingCollection CreateWarehouseItems()
        {
            var wc = new WrappingCollection
            {
                FactoryMethod =
                    o =>
                        _viewModelCreatorService.CreateViewModel<IWarehouseItem, WarehouseItemViewModel>(
                            (IWarehouseItem) o)
            }.WithSource(_dataService.WarehouseItems);

            return wc;
        }
    }
}
