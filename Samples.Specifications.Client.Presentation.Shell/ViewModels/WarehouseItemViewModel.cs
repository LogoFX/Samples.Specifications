using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class WarehouseItemViewModel : WarehouseItemViewModelBase
    {
        public WarehouseItemViewModel(IWarehouseItem model, IDataService dataService) 
            : base(model, dataService)
        {
        }
    }

    [UsedImplicitly]
    public class NewWarehouseItemViewModel : WarehouseItemViewModelBase
    {
        private readonly IDataService _dataService;

        public NewWarehouseItemViewModel(IWarehouseItem model, IDataService dataService)
            : base(model, dataService)
        {
            _dataService = dataService;
        }
    }

    public abstract class WarehouseItemViewModelBase : EditableObjectViewModel<IWarehouseItem>
    {
        private readonly IDataService _dataService;

        protected WarehouseItemViewModelBase(IWarehouseItem model, IDataService dataService) 
            : base(model)
        {
            Debug.Assert(model != null, "model != null");
            _dataService = dataService;
        }

        protected override async Task<bool> SaveMethod(IWarehouseItem model)
        {
            await _dataService.SaveWarehouseItemAsync(Model);
            return true;
        }

    }
}
