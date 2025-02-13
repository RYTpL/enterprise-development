using Microsoft.EntityFrameworkCore;
using StoreApp.Model;

namespace StoreApp.Server.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductStore> ProductStores { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
