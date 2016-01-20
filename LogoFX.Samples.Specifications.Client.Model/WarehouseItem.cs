using JetBrains.Annotations;
using LogoFX.Samples.Specifications.Client.Model.Contracts;

namespace LogoFX.Samples.Specifications.Client.Model
{
    [UsedImplicitly]
    class WarehouseItem : IWarehouseItem
    {
        public WarehouseItem(
            string kind, 
            double price, 
            int quantity)
        {
            Kind = kind;
            Price = price;
            Quantity = quantity;
            TotalCost = Price*Quantity;
        }

        public string Kind { get; }
        public double Price { get; }
        public int Quantity { get; }
        public double TotalCost { get; }
    }
}
