using Samples.Client.Data.Contracts.Dto;

namespace Samples.Specifications.Tests.Steps.Real.Helpers
{
    public interface ISetupHelper
    {
        void AddWarehouseItem(WarehouseItemDto warehouseItem);
        void AddUser(string login, string password);
        void Initialize();
    }
}