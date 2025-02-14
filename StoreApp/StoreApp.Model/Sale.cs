using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Model;

public class Sale
{
    /// <summary>
    /// Sale ID
    /// </summary>
    [Key]
    public int SaleId { get; set; }

    /// <summary>
    /// Date and time of sale
    /// </summary>
    public required DateTime DateSale { get; set; } = new DateTime(1970, 1, 1);

    /// <summary>
    /// Customer
    /// </summary>
    [ForeignKey("Customer")]
    public required int CustomerId { get; set; } = -1;

    /// <summary>
    /// Store
    /// </summary>
    [ForeignKey("Store")]
    public required int StoreId { get; set; } = -1;

    /// <summary>
    /// Purchase amount
    /// </summary>
    public required double Sum { get; set; } = 0.0;

    /// <summary>
    /// Collection of ProductSales
    /// </summary>
    public List<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    public Sale() { }

    public Sale(int saleId, string dateSale, int customerId, int storeId, double sum)
    {
        SaleId = saleId;
        DateSale = DateTime.Parse(dateSale);
        CustomerId = customerId;
        StoreId = storeId;
        Sum = sum;
    }

    public Sale(int saleId, string dateSale, int customerId, int storeId, List<int> productIds, List<int> quantities, double sum)
    {
        SaleId = saleId;
        DateSale = DateTime.Parse(dateSale);
        CustomerId = customerId;
        StoreId = storeId;
        ProductSales = productIds.Select((productId, index) => new ProductSale
        {
            ProductId = productId,
            SaleId = saleId,
            Quantity = quantities[index]  // Устанавливаем значение для Quantity
        }).ToList();
        Sum = sum;
    }

}
