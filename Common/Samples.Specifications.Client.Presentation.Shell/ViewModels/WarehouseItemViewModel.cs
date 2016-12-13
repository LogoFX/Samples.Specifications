using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;
using Solid.Practices.Scheduling;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class WarehouseItemViewModel : EditableObjectViewModel<IWarehouseItem>
    {
        public WarehouseItemViewModel(IWarehouseItem model) 
            : base(model)
        {
            IsEnabled = model != null;
        }

        protected override Task<bool> SaveMethod(IWarehouseItem model)
        {
            return TaskRunner.RunAsync(() => true);
        }
    }
}
