using System;
using System.Collections.Generic;
using System.Linq;
using Samples.Client.Data.Contracts.Dto;
using Samples.Client.Data.Contracts.Providers;

namespace Samples.Specifications.Client.Data.Real.Providers
{
    class WarehouseProvider : IWarehouseProvider
    {
        public IEnumerable<WarehouseItemDto> GetWarehouseItems()
        {
            using (var storage = new Storage())
            {
                return storage.Get<WarehouseItemDto>().ToArray();
            }                      
        }

        public bool DeleteWarehouseItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveWarehouseItem(WarehouseItemDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
