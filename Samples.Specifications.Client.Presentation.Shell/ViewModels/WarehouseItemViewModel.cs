using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using LogoFX.Client.Mvvm.ViewModel.Services;
using Samples.Client.Model.Contracts;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class ExistingWarehouseItemViewModel : WarehouseItemViewModelBase
    {
        public ExistingWarehouseItemViewModel(
            IWarehouseItem model, 
            IDataService dataService, 
            IViewModelCreatorService viewModelCreatorService) 
            : base(model, dataService, viewModelCreatorService)
        {
        }
    }

    [UsedImplicitly]
    public class NewWarehouseItemViewModel : WarehouseItemViewModelBase
    {
        public NewWarehouseItemViewModel(
            IWarehouseItem model, 
            IDataService dataService,
            IViewModelCreatorService viewModelCreatorService)
            : base(model, dataService, viewModelCreatorService)
        {
        }
    }

    public abstract class WarehouseItemViewModelBase : EditableObjectViewModel<IWarehouseItem>
    {
        private readonly IDataService _dataService;
        private readonly IViewModelCreatorService _viewModelCreatorService;

        protected WarehouseItemViewModelBase(
            IWarehouseItem model, 
            IDataService dataService, 
            IViewModelCreatorService viewModelCreatorService) 
            : base(model)
        {
            _dataService = dataService;
            _viewModelCreatorService = viewModelCreatorService;
        }

        protected override async Task<bool> SaveMethod(IWarehouseItem model)
        {
            await _dataService.SaveWarehouseItemAsync(Model);
            return true;
        }

        private WarehouseItemViewModel _item;

        public WarehouseItemViewModel Item
        {
            get
            {
                return _item ??
                       (_item = _viewModelCreatorService.CreateViewModel<IWarehouseItem, WarehouseItemViewModel>(Model));
            }
        }
    }

    public class WarehouseItemViewModel : ObjectViewModel<IWarehouseItem>
    {
        public WarehouseItemViewModel(IWarehouseItem model) : base(model)
        {
            
        }
    }
}
