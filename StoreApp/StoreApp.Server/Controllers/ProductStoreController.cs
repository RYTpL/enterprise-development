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
public class ProductStoreController(IDbContextFactory<StoreAppContext> _contextFactory, ILogger<ProductStoreController> _logger, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ProductStoreGetDto>> Get()
    {
        _logger.LogInformation("GET productStores");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productStores = await ctx.ProductStores.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductStoreGetDto>>(productStores);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductStoreGetDto>> Get(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productStore = await ctx.ProductStores.FirstOrDefaultAsync(x => x.Id == id);
        if (productStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}.");
            return NotFound();
        }
        _logger.LogInformation($"GET productStore with ID: {id}.");
        return Ok(_mapper.Map<ProductStoreGetDto>(productStore));
    }

    [HttpGet("product/{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ProductStoreGetDto>> GetByProduct(int productId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productStores = await ctx.ProductStores.Where(x => x.ProductId == productId).ToListAsync();
        _logger.LogInformation(productStores.Any() ? $"GET productStores for product ID: {productId}." : $"Not found productStores for product ID: {productId}.");
        return _mapper.Map<IEnumerable<ProductStoreGetDto>>(productStores);
    }

    [HttpGet("store/{storeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ProductStoreGetDto>> GetByStore(int storeId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productStores = await ctx.ProductStores.Where(x => x.StoreId == storeId).ToListAsync();
        _logger.LogInformation(productStores.Any() ? $"GET productStores for store ID: {storeId}." : $"Not found productStores for store ID: {storeId}.");
        return _mapper.Map<IEnumerable<ProductStoreGetDto>>(productStores);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] ProductStorePostDto productStoreToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.ProductStores.AddAsync(_mapper.Map<ProductStore>(productStoreToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST productStore ({productStoreToPost.ProductId}, {productStoreToPost.StoreId}, {productStoreToPost.Quantity})");
        return Ok();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int id, [FromBody] ProductStorePostDto productStoreToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productStore = await ctx.ProductStores.FirstOrDefaultAsync(x => x.Id == id);
        if (productStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}");
            return NotFound();
        }
        _logger.LogInformation($"PUT productStore with ID: {id} ({productStore.ProductId}->{productStoreToPut.ProductId}, {productStore.StoreId}->{productStoreToPut.StoreId}, {productStore.Quantity}->{productStoreToPut.Quantity})");
        _mapper.Map(productStoreToPut, productStore);
        await ctx.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var productStore = await ctx.ProductStores.FirstOrDefaultAsync(x => x.Id == id);
        if (productStore == null)
        {
            _logger.LogInformation($"Not found productStore with ID: {id}");
            return NotFound();
        }
        _logger.LogInformation($"DELETE productStore with ID: {id}");
        ctx.ProductStores.Remove(productStore);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
