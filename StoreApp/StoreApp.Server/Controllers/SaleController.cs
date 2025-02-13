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
public class SaleController(IDbContextFactory<StoreAppContext> _contextFactory, ILogger<SaleController> _logger, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<SaleGetDto>> Get()
    {
        _logger.LogInformation("GET sales");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var sales = await ctx.Sales.ToArrayAsync();
        return _mapper.Map<IEnumerable<SaleGetDto>>(sales);
    }

    [HttpGet("{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SaleGetDto>> Get(int saleId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var sale = await ctx.Sales.FirstOrDefaultAsync(s => s.SaleId == saleId);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}.");
            return NotFound();
        }
        _logger.LogInformation($"GET sale with ID: {saleId}.");
        return Ok(_mapper.Map<SaleGetDto>(sale));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] SalePostDto saleToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Sales.AddAsync(_mapper.Map<Sale>(saleToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST sale ({saleToPost.DateSale}, {saleToPost.CustomerId}, {saleToPost.StoreId}, {saleToPost.Sum})");
        return Ok();
    }

    [HttpPut("{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int saleId, [FromBody] SalePostDto saleToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var sale = await ctx.Sales.FirstOrDefaultAsync(x => x.SaleId == saleId);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}");
            return NotFound();
        }
        _logger.LogInformation($"PUT sale with ID: {saleId} ({sale.DateSale}->{saleToPut.DateSale}, {sale.CustomerId}->{saleToPut.CustomerId}, {sale.StoreId}->{saleToPut.StoreId}, {sale.Sum}->{saleToPut.Sum})");
        _mapper.Map(saleToPut, sale);
        await ctx.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int saleId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var sale = await ctx.Sales.FirstOrDefaultAsync(x => x.SaleId == saleId);
        if (sale == null)
        {
            _logger.LogInformation($"Not found sale with ID: {saleId}");
            return NotFound();
        }
        _logger.LogInformation($"DELETE sale with ID: {saleId}");
        ctx.Sales.Remove(sale);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
