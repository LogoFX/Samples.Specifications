using System.Collections.Generic;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Tests.Steps.Helpers;

namespace Samples.Specifications.Tests.Steps
{
    internal sealed class GivenMainSteps : IGivenMainSteps
    {
        private readonly ISetupHelper _setupHelper;

        public GivenMainSteps(ISetupHelper setupHelper)
        {
            _setupHelper = setupHelper;
        }

        public void SetupWarehouseItems(IEnumerable<WarehouseItemDto> warehouseItems)
        {                       
            foreach (var warehouseItemDto in warehouseItems)
            {
                _setupHelper.AddWarehouseItem(warehouseItemDto);
            }            
        }
    }
}
