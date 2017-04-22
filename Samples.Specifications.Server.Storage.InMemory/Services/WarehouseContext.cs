using Microsoft.EntityFrameworkCore;
using Samples.Specifications.Server.Domain.Models;

namespace Samples.Specifications.Server.Storage.InMemory.Services
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<WarehouseItem> WarehouseItems { get; set; }
    }    
}
