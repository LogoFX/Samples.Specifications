using System.Collections.Generic;
using Samples.Client.Data.Contracts.Dto;

namespace Samples.Specifications.Tests.Steps
{
    public interface IGivenMainSteps
    {
        void SetupWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems);
    }
}
