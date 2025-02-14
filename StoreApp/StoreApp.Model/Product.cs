using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace StoreApp.Model;

public class Product
{
    /// <summary>
    /// Product ID, corresponds to its barcode
    /// </summary>
    [Key]
    public int ProductId { get; set; }

    /// <summary>
    /// Product Group
    /// </summary>
    public required int ProductGroup { get; set; } = -1;

    /// <summary>
    /// Product name
    /// </summary>
    public required string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Product weight
    /// </summary>
    public required double ProductWeight { get; set; } = 0.0;

    /// <summary>
    /// Product type (piece, weighted) piece -> true | weighted -> false
    /// </summary>
    public required bool ProductType { get; set; } = false;

    /// <summary>
    /// Product price
    /// </summary>
    public required double ProductPrice { get; set; } = -1.0;

    /// <summary>
    /// Product deadline date storage
    /// </summary>
    public required DateTime DateStorage { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Collection ProductSale
    /// </summary>
    public List<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    /// <summary>
    /// Collection ProductStore
    /// </summary>
    public List<ProductStore> ProductStores { get; set; } = new List<ProductStore>();

    public Product() { }

    public Product(int productId, int productGroup, string productName, double productWeight, bool productType, double productPrice, string dateStorage)
    {
        ProductId = productId;
        ProductGroup = productGroup;
        ProductName = productName;
        ProductWeight = productWeight;
        ProductType = productType;
        ProductPrice = productPrice;
        DateStorage = DateTime.ParseExact(dateStorage, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        ProductSales = new List<ProductSale>();
        ProductStores = new List<ProductStore>();
    }
}
