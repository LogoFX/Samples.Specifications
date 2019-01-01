using LogoFX.Client.Mvvm.ViewModel;

namespace Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface IWarehouseItemsViewModel
    {
        WrappingCollection.WithSelection Items { get; }
    }
}