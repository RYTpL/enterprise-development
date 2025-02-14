using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Model;

public class ProductStore
{
    /// <summary>
    /// CustomerId
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Product ID
    /// </summary>
    [ForeignKey("Product")]
    public required int ProductId { get; set; } = -1;

    /// <summary>
    /// Store ID
    /// </summary>
    [ForeignKey("Store")]
    public required int StoreId { get; set; } = -1;

    /// <summary>
    /// Product quantity
    /// </summary>
    public required int Quantity { get; set; } = 0;

    public ProductStore() { }

    public ProductStore(int id, int productId, int storeId, int quantity)
    {
        Id = id;
        ProductId = productId;
        StoreId = storeId;
        Quantity = quantity;
    }
}
