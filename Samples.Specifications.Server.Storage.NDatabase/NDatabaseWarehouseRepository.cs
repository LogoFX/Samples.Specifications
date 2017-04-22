using System;
using System.Collections.Generic;
using System.Linq;
using Samples.Client.Data.Contracts.Dto;
using Samples.Specifications.Server.Domain.Models;
using Samples.Specifications.Server.Domain.Services.Storage;

namespace Samples.Specifications.Server.Storage.NDatabase
{
    //TODO: not operable yet
    class NDatabaseWarehouseRepository : IWarehouseRepository
    {
        public WarehouseItem Add(WarehouseItem warehouseItem)
        {
            using (var storage = new Storage())
            {
                storage.Store(new WarehouseItemDto
                {
                    Id = warehouseItem.Id,
                    Kind = warehouseItem.Kind,
                    Price = warehouseItem.Price,
                    Quantity = warehouseItem.Quantity
                });
            }
            //TODO: resolve modified Id issue
            return warehouseItem;
        }

        public IEnumerable<WarehouseItem> GetAll()
        {
            using (var storage = new Storage())
            {
                return storage.Get<WarehouseItemDto>().Select(t =>
                    new WarehouseItem
                    {
                        Id = t.Id,
                        Kind = t.Kind,
                        Price = t.Price,
                        Quantity = t.Quantity
                    });
            }
        }

        public void Delete(WarehouseItem warehouseItem)
        {
            using (var storage = new Storage())
            {
                var itemToDelete = storage.Get<WarehouseItemDto>().SingleOrDefault(t => t.Id == warehouseItem.Id);
                if (itemToDelete != null)
                {
                    storage.Remove(itemToDelete);
                }
            }
        }

        public void Update(WarehouseItem warehouseItem)
        {
            using (var storage = new Storage())
            {
                var itemToUpdate = storage.Get<WarehouseItemDto>().SingleOrDefault(t => t.Id == warehouseItem.Id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Quantity = warehouseItem.Quantity;
                    itemToUpdate.Kind = warehouseItem.Kind;
                    itemToUpdate.Price = warehouseItem.Price;
                }
            }
        }                

        public WarehouseItem GetById(Guid id)
        {
            using (var storage = new Storage())
            {
                var item = storage.Get<WarehouseItemDto>().SingleOrDefault(t => t.Id == id);
                return item != null
                    ? new WarehouseItem
                    {
                        Id = item.Id,
                        Kind = item.Kind,
                        Price = item.Price,
                        Quantity = item.Quantity
                    }
                    : null;
            }
        }
    }
}