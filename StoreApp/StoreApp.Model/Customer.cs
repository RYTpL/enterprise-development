using System.ComponentModel.DataAnnotations;

namespace StoreApp.Model;

public class Customer
{
    /// <summary>
    /// ID of customer
    /// </summary>
    [Key]
    public int CustomerId { get; set; }

    /// <summary>
    /// Full name of customer
    /// </summary>
    public required string CustomerName { get; set; }

    /// <summary>
    /// Customer card number
    /// </summary>
    public required int CustomerCardNumber { get; set; }

    /// <summary>
    /// Customer sales collection
    /// </summary>
    public List<Sale> Sales { get; set; } = new List<Sale>();

    public Customer() { }

    public Customer(int customerId, string customerName, int customerCardNumber)
    {
        CustomerId = customerId;
        CustomerName = customerName;  // Это обязательное свойство, теперь оно передается в конструктор
        CustomerCardNumber = customerCardNumber;
        Sales = new List<Sale>();
    }

}
