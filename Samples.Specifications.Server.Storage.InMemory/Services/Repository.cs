using System;
using System.Collections.Generic;
using System.Linq;
using Samples.Specifications.Server.Domain.Models;
using Samples.Specifications.Server.Domain.Services.Storage;

namespace Samples.Specifications.Server.Storage.InMemory.Services
{    
    public class InMemoryWarehouseRepository : IWarehouseRepository
    {
        private readonly WarehouseContext _context;

        public InMemoryWarehouseRepository(WarehouseContext context)
        {
            _context = context;
        }


        public WarehouseItem Add(WarehouseItem book)
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(WarehouseItem book)
        {
            _context.Remove(book);
            _context.SaveChanges();
        }

        public IEnumerable<WarehouseItem> GetAll()
        {
            return _context.WarehouseItems.ToList();
        }

        public WarehouseItem GetById(Guid id)
        {
            return _context.WarehouseItems.SingleOrDefault(t => t.Id == id);
        }

        public void Update(WarehouseItem warehouseItem)
        {
            var warehouseItemToUpdate = _context.WarehouseItems.Single(t => t.Kind == warehouseItem.Kind);
            warehouseItemToUpdate.Price = warehouseItem.Price;
            warehouseItemToUpdate.Quantity = warehouseItem.Quantity;
            _context.Update(warehouseItemToUpdate);
            _context.SaveChanges();
        }
    }
}
