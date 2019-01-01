namespace Samples.Specifications.Client.Presentation.Shell.Contracts.ViewModels
{
    public interface IWarehouseItemContainerViewModel
    {
        IWarehouseItemCommandsViewModel Commands { get; }
        IWarehouseItemViewModel Item { get; }
    }
}