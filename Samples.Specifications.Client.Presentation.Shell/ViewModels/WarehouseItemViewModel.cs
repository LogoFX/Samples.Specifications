using System.Threading.Tasks;
using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;
using Solid.Practices.Scheduling;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class WarehouseItemViewModel : ObjectViewModel<IWarehouseItem>
    {
        public WarehouseItemViewModel(IWarehouseItem model) 
            : base(model)
        {
            
        }

        public bool IsEnabled
        {
            get { return Model != null; }
        }

        //protected override Task<bool> SaveMethod(IWarehouseItem model)
        //{
        //    return TaskRunner.RunAsync(() => true);
        //}
    }
}
