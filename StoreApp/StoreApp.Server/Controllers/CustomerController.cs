using Microsoft.AspNetCore.Mvc;
using StoreApp.Server.Dto;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customerService, ILogger<CustomerController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<CustomerGetDto>> Get()
    {
        logger.LogInformation("GET customers");
        return await customerService.GetAllCustomersAsync();
    }

    [HttpGet("{customerId}")]
    public async Task<ActionResult<CustomerGetDto>> Get(int customerId)
    {
        var customer = await customerService.GetCustomerByIdAsync(customerId);
        if (customer is null)
        {
            logger.LogInformation($"Not found customer with ID: {customerId}.");
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CustomerPostDto customerDto)
    {
        await customerService.AddCustomerAsync(customerDto);
        return Ok();
    }

    [HttpPut("{customerId}")]
    public async Task<ActionResult> Put(int customerId, [FromBody] CustomerPostDto customerDto)
    {
        var updated = await customerService.UpdateCustomerAsync(customerId, customerDto);
        if (!updated)
        {
            logger.LogInformation($"Not found customer with ID: {customerId}");
            return NotFound();
        }
        return Ok();
    }

    [HttpDelete("{customerId}")]
    public async Task<ActionResult> Delete(int customerId)
    {
        var deleted = await customerService.DeleteCustomerAsync(customerId);
        if (!deleted)
        {
            logger.LogInformation($"Not found customer with ID: {customerId}");
            return NotFound();
        }
        return Ok();
    }
}
