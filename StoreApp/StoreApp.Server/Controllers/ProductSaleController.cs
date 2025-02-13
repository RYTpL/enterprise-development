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
public class ProductSaleController(IDbContextFactory<StoreAppContext> _contextFactory, ILogger<ProductSaleController> _logger, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ProductSaleGetDto>> Get()
    {
        _logger.LogInformation("GET productSales");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productSales = await ctx.ProductSales.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductSaleGetDto>>(productSales);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductSaleGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProductSale = await ctx.ProductSales.FirstOrDefaultAsync(x => x.Id == id);
        if (getProductSale == null)
        {
            _logger.LogInformation($"Not found productSale with ID: {id}.");
            return NotFound();
        }
        _logger.LogInformation($"GET productSale with ID: {id}.");
        return Ok(_mapper.Map<ProductSaleGetDto>(getProductSale));
    }

    [HttpGet("product/{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<ProductSaleGetDto>> GetByProduct(int productId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productSales = await ctx.ProductSales.Where(x => x.ProductId == productId).ToListAsync();
        _logger.LogInformation(productSales.Any() ? $"GET productSales for product ID: {productId}." : $"Not found productSales for product ID: {productId}.");
        return _mapper.Map<IEnumerable<ProductSaleGetDto>>(productSales);
    }

    [HttpGet("sale/{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<ProductSaleGetDto>> GetBySale(int saleId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productSales = await ctx.ProductSales.Where(x => x.SaleId == saleId).ToListAsync();
        _logger.LogInformation(productSales.Any() ? $"GET productSales for sale ID: {saleId}." : $"Not found productSales for sale ID: {saleId}.");
        return _mapper.Map<IEnumerable<ProductSaleGetDto>>(productSales);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] ProductSalePostDto productSaleToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.ProductSales.AddAsync(_mapper.Map<ProductSale>(productSaleToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST productSale ({productSaleToPost.ProductId}, {productSaleToPost.SaleId}, {productSaleToPost.Quantity})");
        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int id, [FromBody] ProductSalePostDto productSaleToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productSale = await ctx.ProductSales.FirstOrDefaultAsync(x => x.Id == id);
        if (productSale == null)
        {
            _logger.LogInformation($"Not found productSale with ID: {id}");
            return NotFound();
        }
        _logger.LogInformation($"PUT productSale with ID: {id} ({productSale.ProductId}->{productSaleToPut.ProductId}, {productSale.SaleId}->{productSaleToPut.SaleId}, {productSale.Quantity}->{productSaleToPut.Quantity})");
        _mapper.Map(productSaleToPut, productSale);
        await ctx.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productSale = await ctx.ProductSales.FirstOrDefaultAsync(x => x.Id == id);
        if (productSale == null)
        {
            _logger.LogInformation($"Not found productSale with ID: {id}");
            return NotFound();
        }
        _logger.LogInformation($"DELETE productSale with ID: {id}");
        ctx.ProductSales.Remove(productSale);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
