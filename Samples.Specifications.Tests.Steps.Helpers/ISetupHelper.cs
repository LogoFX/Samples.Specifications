using Samples.Client.Data.Contracts.Dto;

namespace Samples.Specifications.Tests.Steps.Helpers
{
    public interface ISetupHelper
    {
        void AddWarehouseItem(WarehouseItemDto warehouseItem);
        void AddUser(string login, string password);
        void Initialize();
    }
}