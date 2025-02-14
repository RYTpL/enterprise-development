using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Model;

public class ProductSale
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Product ID
    /// </summary>
    [ForeignKey("Product")]
    public required int ProductId { get; set; } = -1;

    /// <summary>
    /// Sale ID
    /// </summary>
    [ForeignKey("Sale")]
    public required int SaleId { get; set; } = -1;

    /// <summary>
    /// Product quantity
    /// </summary>
    public required int Quantity { get; set; } = 0;

    public ProductSale() { }

    public ProductSale(int id, int productId, int saleId, int quantity)
    {
        Id = id;
        ProductId = productId;
        SaleId = saleId;
        Quantity = quantity;
    }
}
