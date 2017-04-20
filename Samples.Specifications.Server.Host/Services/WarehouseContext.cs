using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Samples.Specifications.Server.Host.Models;

namespace Samples.Specifications.Server.Host.Services
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<WarehouseItem> Books { get; set; }
    }

    public interface IBookRepository
    {
        WarehouseItem Add(WarehouseItem warehouseItem);
        IEnumerable<WarehouseItem> GetAll();
        WarehouseItem GetById(int id);
        void Delete(WarehouseItem warehouseItem);
        void Update(WarehouseItem warehouseItem);
    }

    public class InMemoryBookRepository : IBookRepository
    {
        public WarehouseItem Add(WarehouseItem warehouseItem)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<WarehouseItem> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public WarehouseItem GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(WarehouseItem warehouseItem)
        {
            throw new System.NotImplementedException();
        }

        public void Update(WarehouseItem warehouseItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
