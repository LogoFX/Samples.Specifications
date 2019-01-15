using LogoFX.Client.Mvvm.ViewModel;
using Samples.Client.Model.Contracts;
using Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{    
    public sealed class WarehouseItemViewModel : ObjectViewModel<IWarehouseItem>, IWarehouseItemViewModel
    {
        public WarehouseItemViewModel(
            IWarehouseItem model) : base(model)
        {
        }        
    }
}
