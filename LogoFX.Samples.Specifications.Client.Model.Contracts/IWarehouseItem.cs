namespace LogoFX.Samples.Specifications.Client.Model.Contracts
{
    public interface IWarehouseItem
    {
        string Kind { get; }   
        double Price { get; }
        int Quantity { get; }
        double TotalCost { get; }
    }
}