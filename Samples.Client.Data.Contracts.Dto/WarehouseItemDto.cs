using System;

namespace Samples.Client.Data.Contracts.Dto
{    
    public sealed class WarehouseItemDto
    {
        public WarehouseItemDto()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Kind { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}