using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Model;
using StoreApp.Server.Dto;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(IDbContextFactory<StoreAppContext> _contextFactory, ILogger<CustomerController> _logger, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<CustomerGetDto>> Get()
    {
        _logger.LogInformation("GET customers");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var customers = await ctx.Customers.ToArrayAsync();
        return _mapper.Map<IEnumerable<CustomerGetDto>>(customers);
    }

    [HttpGet("{customerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerGetDto>> Get(int customerId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getCustomer = await ctx.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == customerId);
        if (getCustomer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {customerId}.");
            return NotFound();
        }
        _logger.LogInformation($"GET customer with ID: {customerId}.");
        return Ok(_mapper.Map<CustomerGetDto>(getCustomer));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] CustomerPostDto customerToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Customers.AddAsync(_mapper.Map<Customer>(customerToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST customer ({customerToPost.CustomerName}, {customerToPost.CustomerCardNumber})");
        return Ok();
    }

    [HttpPut("{customerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int customerId, [FromBody] CustomerPostDto customerToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var customer = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {customerId}");
            return NotFound();
        }
        _logger.LogInformation($"PUT customer with ID: {customerId} ({customer.CustomerName}->{customerToPut.CustomerName}, {customer.CustomerCardNumber}->{customerToPut.CustomerCardNumber})");
        _mapper.Map(customerToPut, customer);
        await ctx.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{customerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int customerId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var customer = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        if (customer == null)
        {
            _logger.LogInformation($"Not found customer with ID: {customerId}");
            return NotFound();
        }
        _logger.LogInformation($"DELETE customer with ID: {customerId}");
        ctx.Customers.Remove(customer);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
