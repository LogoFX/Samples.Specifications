using JetBrains.Annotations;
using LogoFX.Client.Mvvm.ViewModel;
using Samples.Client.Model.Contracts;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    [UsedImplicitly]
    public class WarehouseItemViewModel : /*Editable*/ObjectViewModel<IWarehouseItem>
    {
        public WarehouseItemViewModel(IWarehouseItem model) 
            : base(model)
        {
            IsEnabled = model != null;
        }

        //public bool IsEnabled
        //{
        //    get { return Model != null; }
        //}

        //protected override Task<bool> SaveMethod(IWarehouseItem model)
        //{
        //    return TaskRunner.RunAsync(() => true);
        //}
    }
}
