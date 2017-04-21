using Microsoft.EntityFrameworkCore;
using Samples.Specifications.Server.Storage.Contracts.Models;

namespace Samples.Specifications.Server.Storage.Services
{
    public class WarehouseContext : DbContext
    {
        public WarehouseContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<WarehouseItem> WarehouseItems { get; set; }
    }    
}
