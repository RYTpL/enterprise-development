using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreApp.Model;
using StoreApp.Server.Dto;

public class CustomerService(
    IDbContextFactory<StoreAppContext> contextFactory,
    IMapper mapper,
    ILogger<CustomerService> logger) : ICustomerService
{
    public async Task<IEnumerable<CustomerGetDto>> GetAllCustomersAsync()
    {
        using var ctx = await contextFactory.CreateDbContextAsync();
        var customers = await ctx.Customers.ToArrayAsync();
        return mapper.Map<IEnumerable<CustomerGetDto>>(customers);
    }

    public async Task<CustomerGetDto?> GetCustomerByIdAsync(int customerId)
    {
        using var ctx = await contextFactory.CreateDbContextAsync();
        var customer = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        return customer is null ? null : mapper.Map<CustomerGetDto>(customer);
    }

    public async Task AddCustomerAsync(CustomerPostDto customerDto)
    {
        using var ctx = await contextFactory.CreateDbContextAsync();
        await ctx.Customers.AddAsync(mapper.Map<Customer>(customerDto));
        await ctx.SaveChangesAsync();
        logger.LogInformation($"Added customer: {customerDto.CustomerName}");
    }

    public async Task<bool> UpdateCustomerAsync(int customerId, CustomerPostDto customerDto)
    {
        using var ctx = await contextFactory.CreateDbContextAsync();
        var customer = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        if (customer is null) return false;

        mapper.Map(customerDto, customer);
        await ctx.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCustomerAsync(int customerId)
    {
        using var ctx = await contextFactory.CreateDbContextAsync();
        var customer = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        if (customer is null) return false;

        ctx.Customers.Remove(customer);
        await ctx.SaveChangesAsync();
        return true;
    }
}
