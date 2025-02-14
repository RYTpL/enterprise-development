using System.ComponentModel.DataAnnotations;

namespace StoreApp.Model;

/// <summary>
/// Class describing the store
/// </summary>
public class Store
{
    [Key]
    public required int StoreId { get; set; }

    public required string StoreName { get; set; }
    public required string StoreAddress { get; set; }

    public List<Sale> Sales { get; set; } = new List<Sale>();
    public List<ProductStore> ProductStores { get; set; } = new List<ProductStore>();

    public Store() { }

    public Store(int storeId, string storeName, string storeAddress)
    {
        StoreId = storeId;
        StoreName = storeName;
        StoreAddress = storeAddress;
        Sales = new List<Sale>();
        ProductStores = new List<ProductStore>();
    }
}

