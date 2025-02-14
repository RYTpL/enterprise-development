using StoreApp.Server.Dto;

public interface ICustomerService
{
    Task<IEnumerable<CustomerGetDto>> GetAllCustomersAsync();
    Task<CustomerGetDto?> GetCustomerByIdAsync(int customerId);
    Task AddCustomerAsync(CustomerPostDto customerDto);
    Task<bool> UpdateCustomerAsync(int customerId, CustomerPostDto customerDto);
    Task<bool> DeleteCustomerAsync(int customerId);
}
