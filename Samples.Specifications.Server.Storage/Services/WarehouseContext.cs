using Microsoft.EntityFrameworkCore;
using Samples.Specifications.Server.Host.Models;

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
