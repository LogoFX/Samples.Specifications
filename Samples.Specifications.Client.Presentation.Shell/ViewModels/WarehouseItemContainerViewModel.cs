using System.Threading.Tasks;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using LogoFX.Client.Mvvm.ViewModel.Services;
using Samples.Client.Model.Contracts;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{   
    public sealed class WarehouseItemContainerViewModel : EditableObjectViewModel<IWarehouseItem>, IWarehouseItemContainerViewModel
    {
        private readonly IWarehouseItem _model;
        private readonly IViewModelCreatorService _viewModelCreatorService;
        private readonly IDataService _dataService;

        public WarehouseItemContainerViewModel(
            IWarehouseItem model,
            IViewModelCreatorService viewModelCreatorService,
            IDataService dataService) :
                base(model)
        {
            _model = model;
            _viewModelCreatorService = viewModelCreatorService;
            _dataService = dataService;
        }

        private WarehouseItemCommandsViewModel _commands;
        public IWarehouseItemCommandsViewModel Commands => _commands ??
                                                          (_commands = _viewModelCreatorService
                                                              .CreateViewModel<WarehouseItemCommandsViewModel>());

        private WarehouseItemViewModel _item;
        public IWarehouseItemViewModel Item => _item ??
                                              (_item =
                                                  _viewModelCreatorService
                                                      .CreateViewModel<IWarehouseItem, WarehouseItemViewModel>(_model));

        protected override async Task<bool> SaveMethod(IWarehouseItem model)
        {
            await _dataService.SaveWarehouseItemAsync(Model);
            return true;
        }
    }
}