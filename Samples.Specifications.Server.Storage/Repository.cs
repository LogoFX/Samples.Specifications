using System;
using System.Collections.Generic;
using System.Linq;
using Samples.Specifications.Server.Host.Models;
using Samples.Specifications.Server.Storage.Services;

namespace Samples.Specifications.Server.Storage
{
    public interface IWarehouseRepository
    {
        WarehouseItem Add(WarehouseItem warehouseItem);
        IEnumerable<WarehouseItem> GetAll();
        WarehouseItem GetById(int id);
        void Delete(WarehouseItem warehouseItem);
        void Update(WarehouseItem warehouseItem);
    }

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


        public WarehouseItem GetById(int id)
        {
            throw new NotImplementedException();
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
