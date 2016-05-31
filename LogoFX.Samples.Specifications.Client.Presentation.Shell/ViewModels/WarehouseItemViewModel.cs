using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel;
using Samples.Client.Model.Contracts;

namespace LogoFX.Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class WarehouseItemViewModel : ObjectViewModel<IWarehouseItem>
    {
        public WarehouseItemViewModel(IWarehouseItem model) : base(model)
        {
            
        }
    }
}
