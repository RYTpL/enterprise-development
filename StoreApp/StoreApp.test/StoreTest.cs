using StoreApp.Model;
using System.Globalization;
using static System.Formats.Asn1.AsnWriter;
namespace StoreApp.Tests;
using Xunit;


public class StoreTest
{
    /// <summary>
    /// Initializes standart list of products for tests
    /// </summary>
    /// <returns>
    /// List containing 5 products
    /// </returns>
    private List<Product> CreateDefaulProduct()
    {
        return new List<Product>()
        {
            new Product(0, 1, "Milk", 0.940, false, 89.0, "2023.01.01"),
            new Product(0, 1, "Milk", 0.940, false, 89.0, "2023.02.23"),
            new Product(1, 1, "Butter", 0.940, false, 159.0, "2023.05.21"),
            new Product(2, 2, "Pasta", 0.400, true, 109.0, "2023.01.10"),
            new Product(3, 3, "Eggs", 0.600, false, 96.0, "2023.05.09"),
            new Product(4, 3, "Bread", 0.440, false, 36.0, "2023.02.23")

        };
    }

    /// <summary>
    /// Initializes standart list of customers for tests
    /// </summary>
    /// <returns>
    /// List containing 5 customers
    /// </returns>
    private List<Customer> CreateDefaulCustomer()
    {
        return new List<Customer>()
        {
            new Customer(1, "Michelle Padilla", 111111),
            new Customer(2, "Manuel Gomez", 222222),
            new Customer(3, "Raymond Oliver", 333333),
            new Customer(4, "Enrique Morgan", 444444),
            new Customer(5, "Walter Mullins", 555555)
        };
    }

    /// <summary>
    /// Initializes standart list of stores for tests
    /// </summary>
    /// <returns>
    /// List containing 5 stores
    /// </returns>
    private List<Store> CreateDefaultStore()
    {
        var storeList = new List<Store>
        {
            new Store(0, "Walmart", "Polevaya 123"),
            new Store(1, "Pyaterochka", "Pushkina 1837"),
            new Store(2, "Shestorochka", "Kolotushkina 0"),
            new Store(3, "Magnit", "Moskovskoye shosse 666"),
            new Store(4, "Perekrestok", "Revolyutsionnaya 1917"),
        };
        return storeList;

    }

    /// <summary>
    /// Initializes a standard list of "product-store-quantity" relationships for tests
    /// </summary>
    /// <returns>
    /// List containing 6 links "product-shop-quantity"
    /// </returns>
    private List<ProductStore> CreateDefaultProductStore()
    {
        var productStoreList = new List<ProductStore>
        {
            new ProductStore(1, 0, 1, 10),
            new ProductStore(2, 1, 1, 2),
            new ProductStore(3, 2, 1, 5),
            new ProductStore(4, 2, 2, 15),
            new ProductStore(5, 3, 1, 0),
            new ProductStore(6, 3, 2, 20)
        };
        return productStoreList;
    }

    /// <summary>
    /// Initializes standart list of sales for tests
    /// </summary>
    /// <returns>
    /// List containing 7 sales
    /// </returns>
    private List<Sale> CreateDefaultSales()
    {
        var saleList = new List<Sale>
        {
            new Sale(1, "2023.03.03", 1, 0, new List<int> {0, 1, 2}, 357.0),
            new Sale(2, "2023.01.20", 0, 1, new List<int> {3, 4, 0}, 221.0),
            new Sale(3, "2023.02.15", 1, 0, new List<int> {1, 2, 3}, 364.0),
            new Sale(4, "2023.02.18", 2, 2, new List<int> {4, 0, 1}, 284.0),
            new Sale(5, "2023.02.16", 3, 3, new List<int> {2, 3, 4}, 241.0),
            new Sale(6, "2023.03.28", 4, 1, new List<int> {1, 2, 3}, 364.0),
            new Sale(7, "2023.03.01", 4, 0, new List<int> {4, 0, 3}, 284.0),
        };
        return saleList;
    }

    /// <summary>
    /// Product class constructor test
    /// </summary>
    [Fact]
    public void ProductConstructorTest()
    {
        var molochko = new Product(0, 1, "Milk", 0.940, false, 89.0, "2023.02.20");
        Assert.Equal(0, molochko.ProductId);
        Assert.Equal(1, molochko.ProductGroup);
        Assert.Equal("Milk", molochko.ProductName);
        Assert.Equal(0.940, molochko.ProductWeight);
        Assert.False(molochko.ProductType);
        Assert.Equal(89.0, molochko.ProductPrice);
        Assert.Equal(DateTime.ParseExact("2023.02.20", "yyyy.MM.dd", CultureInfo.InvariantCulture), molochko.DateStorage);

    }

    /// <summary>
    /// Customer class constructor test
    /// </summary>
    [Fact]
    public void CustomerConstructorTest()
    {
        var customer = new Customer(1, "Michelle Padilla", 111111);
        Assert.Equal("Michelle Padilla", customer.CustomerName);
        Assert.Equal(111111, customer.CustomerCardNumber);
    }

    /// <summary>
    /// Store class constructor test
    /// </summary>
    [Fact]
    public void StoreConstructorTest()
    {
        var store = new Store(666, "Shestorochka", "Kolotushkina 0");
        Assert.Equal(666, store.StoreId);
        Assert.Equal("Shestorochka", store.StoreName);
        Assert.Equal("Kolotushkina 0", store.StoreAddress);
    }


    /// <summary>
    /// Display information about all products in a given store
    /// </summary>
    [Fact]
    public void TestProductsInSpecifiedStore()
    {
        var products = CreateDefaulProduct();
        var stores = CreateDefaultStore();
        var productStores = CreateDefaultProductStore();


        var result = from ps in productStores
                     join p in products on ps.ProductId equals p.ProductId
                     join s in stores on ps.StoreId equals s.StoreId
                     where s.StoreId == 1 && ps.Quantity > 0
                     select new { ProductName = p.ProductName, ProductPrice = p.ProductPrice, Quantity = ps.Quantity };

        Assert.NotNull(result);
        Assert.Equal(4, result.Count());

        Assert.Contains(result, x => x.ProductName == "Butter" && x.ProductPrice == 159.0 && x.Quantity == 2);
        Assert.Contains(result, x => x.ProductName == "Pasta" && x.ProductPrice == 109.0 && x.Quantity == 5);
        Assert.DoesNotContain(result, x => x.ProductName == "Eggs" && x.ProductPrice == 96.0 && x.Quantity == 0);
    }


    /// <summary>
    /// For a given product, display a list of stores where it is located in availability
    /// </summary>
    [Fact]
    public void TestProductInAllStores()
    {
        var products = CreateDefaulProduct();
        var stores = CreateDefaultStore();
        var productStores = CreateDefaultProductStore();

        var result = from ps in productStores
                     join p in products on ps.ProductId equals p.ProductId
                     join s in stores on ps.StoreId equals s.StoreId
                     where ps.Quantity > 0 && p.ProductId == 2
                     select s;

        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Contains(result, x => x.StoreId == 1 && x.StoreAddress == "Pushkina 1837");
        Assert.Contains(result, x => x.StoreId == 2 && x.StoreAddress == "Kolotushkina 0");
    }


    /// <summary>
    /// Display information about the average cost of goods of each product group for each store.
    /// </summary>
 


    /// <summary>
    /// Display the top 5 purchases by total sale amount.
    /// </summary>
    [Fact]
    public void TestTopFivePurchases()
    {
        var products = CreateDefaulProduct();
        var stores = CreateDefaultStore();
        var productStores = CreateDefaultProductStore();
        var sales = CreateDefaultSales();

        var result = ((from sa in sales
                       orderby sa.Sum descending
                       select sa).Take(5)).ToList();

        Assert.NotNull(result);
        Assert.InRange(result.Count(), 0, 5);
        Assert.Equal(364.0, result[0].Sum);
    }


    /// <summary>
    /// Display all information about products that exceed the storage date limit, indicating the store
    /// </summary>
    [Fact]
    public void TestExpiredProducts() 
    {
        var products = CreateDefaulProduct();
        var stores = CreateDefaultStore();
        var productStores = CreateDefaultProductStore();


        var result = from ps in productStores
                     join p in products on ps.ProductId equals p.ProductId
                     join s in stores on ps.StoreId equals s.StoreId
                     where p.DateStorage < DateTime.Now
                     select new
                     {
                         StoreName = s.StoreName,
                         StoreAddress = s.StoreAddress,
                         ProductId = p.ProductId,
                         ProductGroup = p.ProductGroup,
                         ProductName = p.ProductName,
                         ProductWeight = p.ProductWeight,
                         ProductType = p.ProductType,
                         ProductPrice = p.ProductPrice,
                         DateStorage = p.DateStorage
                     };


        Assert.Equal(7, result.Count());
        Assert.Contains(result, x => x.ProductName == "Milk" && x.StoreName == "Pyaterochka");
        Assert.Contains(result, x => (x.ProductId == 0) && (x.ProductGroup == 1) && (x.ProductName == "Milk") && (x.ProductWeight == 0.940) && (x.ProductType == false) && (x.ProductPrice == 89.0));
        Assert.Contains(result, x => x.ProductName == "Pasta" && x.StoreName == "Pyaterochka");
        Assert.Contains(result, x => x.ProductName == "Pasta" && x.StoreName == "Shestorochka");

    }

    /// <summary>
    /// Display a list of stores that sold goods for the month amount in excess of the
    /// </summary>


}
