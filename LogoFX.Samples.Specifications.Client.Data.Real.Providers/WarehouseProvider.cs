using System.Collections.Generic;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Providers;

namespace LogoFX.Samples.Specifications.Client.Data.Real.Providers
{
    class WarehouseProvider : IWarehouseProvider
    {
        public IEnumerable<WarehouseItemDto> GetWarehouseItems()
        {
            //put here real data logic
            return new WarehouseItemDto[]
            {
                new WarehouseItemDto
                {
                    Kind = "Acme",
                    Price = 10,
                    Quantity = 10
                }
            };           
        }
    }
}
