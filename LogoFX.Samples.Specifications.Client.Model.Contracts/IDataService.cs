using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogoFX.Samples.Specifications.Client.Model.Contracts
{
    public interface IWarehouseItem
    {
        string Kind { get; }   
        double Price { get; }
        int Quantity { get; }
        double TotalCost { get; }
    }

    public interface IDataService
    {
        IEnumerable<IWarehouseItem> WarehouseItems { get; }

        Task WarehouseItemsAsync { get; }
    }
}
