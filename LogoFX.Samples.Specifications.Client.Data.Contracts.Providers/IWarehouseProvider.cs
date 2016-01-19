using System.Collections.Generic;
using LogoFX.Samples.Specifications.Client.Data.Contracts.Dto;

namespace LogoFX.Samples.Specifications.Client.Data.Contracts.Providers
{
    public interface IWarehouseProvider
    {
        IEnumerable<WarehouseItemDto> GetWarehouseItems();
    }
}
