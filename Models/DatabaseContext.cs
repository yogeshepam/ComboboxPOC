using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataPOC.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
