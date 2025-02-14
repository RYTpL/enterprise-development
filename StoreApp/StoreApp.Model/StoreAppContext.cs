using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace StoreApp.Model;

public class StoreAppContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductStore> ProductStores { get; set; } = null!;
    public DbSet<ProductSale> ProductSales { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;

    public StoreAppContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        SeedCustomers(modelBuilder);
        SeedProducts(modelBuilder);
        SeedProductSales(modelBuilder);
        SeedProductStores(modelBuilder);
        SeedSales(modelBuilder);
        SeedStores(modelBuilder);
    }

    private void SeedCustomers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, CustomerName = "John Doe", CustomerCardNumber = 111111 },
            new Customer { CustomerId = 2, CustomerName = "Jane Smith", CustomerCardNumber = 222222 },
            new Customer { CustomerId = 3, CustomerName = "Michael Johnson", CustomerCardNumber = 333333 },
            new Customer { CustomerId = 4, CustomerName = "Emily Brown", CustomerCardNumber = 444444 },
            new Customer { CustomerId = 5, CustomerName = "David Wilson", CustomerCardNumber = 555555 }
        );
    }


    private void SeedProducts(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductGroup = 1, ProductName = "Milk", ProductWeight = 0.950, ProductType = false, ProductPrice = 2.50, DateStorage = DateTime.ParseExact("23.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
            new Product { ProductId = 2, ProductGroup = 1, ProductName = "Cheese", ProductWeight = 0.500, ProductType = false, ProductPrice = 5.00, DateStorage = DateTime.ParseExact("23.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
            new Product { ProductId = 3, ProductGroup = 2, ProductName = "Pasta", ProductWeight = 0.450, ProductType = true, ProductPrice = 1.20, DateStorage = DateTime.ParseExact("23.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
            new Product { ProductId = 4, ProductGroup = 3, ProductName = "Eggs", ProductWeight = 0.600, ProductType = true, ProductPrice = 3.00, DateStorage = DateTime.ParseExact("23.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) },
            new Product { ProductId = 5, ProductGroup = 3, ProductName = "Bread", ProductWeight = 0.480, ProductType = false, ProductPrice = 1.50, DateStorage = DateTime.ParseExact("23.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture) }
        );
    }

    private void SeedProductSales(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductSale>().HasData(
            new ProductSale { Id = 1, ProductId = 1, SaleId = 1, Quantity = 2 },
            new ProductSale { Id = 2, ProductId = 2, SaleId = 1, Quantity = 1 },
            new ProductSale { Id = 3, ProductId = 3, SaleId = 2, Quantity = 3 },
            new ProductSale { Id = 4, ProductId = 4, SaleId = 2, Quantity = 1 },
            new ProductSale { Id = 5, ProductId = 5, SaleId = 3, Quantity = 2 },
            new ProductSale { Id = 6, ProductId = 1, SaleId = 3, Quantity = 1 },
            new ProductSale { Id = 7, ProductId = 2, SaleId = 4, Quantity = 2 },
            new ProductSale { Id = 8, ProductId = 3, SaleId = 4, Quantity = 1 },
            new ProductSale { Id = 9, ProductId = 4, SaleId = 5, Quantity = 3 },
            new ProductSale { Id = 10, ProductId = 5, SaleId = 5, Quantity = 2 }
        );
    }


    private void SeedProductStores(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductStore>().HasData(
            new ProductStore { Id = 1, ProductId = 1, StoreId = 1, Quantity = 50 },
            new ProductStore { Id = 2, ProductId = 2, StoreId = 1, Quantity = 30 },
            new ProductStore { Id = 3, ProductId = 3, StoreId = 2, Quantity = 100 },
            new ProductStore { Id = 4, ProductId = 4, StoreId = 2, Quantity = 60 },
            new ProductStore { Id = 5, ProductId = 5, StoreId = 3, Quantity = 80 },
            new ProductStore { Id = 6, ProductId = 1, StoreId = 4, Quantity = 40 }
        );
    }


    private void SeedSales(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>().HasData(
            new Sale
            {
                SaleId = 1,
                DateSale = DateTime.ParseExact("23.02.2025", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                CustomerId = 1,
                StoreId = 1,
                Sum = 15.00,
                ProductSales = new List<ProductSale>
    {
        new ProductSale { ProductId = 1, SaleId = 1, Quantity = 2 },
        new ProductSale { ProductId = 2, SaleId = 1, Quantity = 3 }
    }
            },

            new Sale
            {
                SaleId = 2,
                DateSale = DateTime.ParseExact("2024-01-16", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                CustomerId = 2,
                StoreId = 2,
                Sum = 25.00,
                ProductSales = new List<ProductSale>
    {
        new ProductSale { ProductId = 3, SaleId = 2, Quantity = 1 },
        new ProductSale { ProductId = 4, SaleId = 2, Quantity = 2 }
    }
            },

            new Sale
            {
                SaleId = 3,
                DateSale = DateTime.ParseExact("2024-01-17", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                CustomerId = 3,
                StoreId = 3,
                Sum = 10.00,
                ProductSales = new List<ProductSale>
                {
                    new ProductSale { ProductId = 5, SaleId = 3, Quantity = 5 }
                }
            },

            new Sale
            {
                SaleId = 4,
                DateSale = DateTime.ParseExact("2024-01-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                CustomerId = 4,
                StoreId = 4,
                Sum = 18.00,
                ProductSales = new List<ProductSale>
                {
                    new ProductSale { ProductId = 1, SaleId = 4, Quantity = 3 },
                    new ProductSale { ProductId = 4, SaleId = 4, Quantity = 1 }
                }
            },

            new Sale
            {
                SaleId = 5,
                DateSale = DateTime.ParseExact("2024-01-19", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                CustomerId = 5,
                StoreId = 5,
                Sum = 12.00,
                ProductSales = new List<ProductSale>
                {
                    new ProductSale { ProductId = 2, SaleId = 5, Quantity = 2 },
                    new ProductSale { ProductId = 5, SaleId = 5, Quantity = 2 }
                }
            }

        );
    }




    private void SeedStores(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Store>().HasData(
            new Store { StoreId = 1, StoreName = "Store 1", StoreAddress = "Address 1" },
            new Store { StoreId = 2, StoreName = "Store 2", StoreAddress = "Address 2" },
            new Store { StoreId = 3, StoreName = "Store 3", StoreAddress = "Address 3" },
            new Store { StoreId = 4, StoreName = "Store 4", StoreAddress = "Address 4" },
            new Store { StoreId = 5, StoreName = "Store 5", StoreAddress = "Address 5" }
        );
    }
}
