using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBusiness
{
    public class ShoppingDbContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ClassifyProduct> ClassifyProducts { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
