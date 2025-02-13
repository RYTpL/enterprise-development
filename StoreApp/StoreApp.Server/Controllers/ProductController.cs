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
public class ProductController(IDbContextFactory<StoreAppContext> _contextFactory, ILogger<ProductController> _logger, IMapper _mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<ProductGetDto>> Get()
    {
        _logger.LogInformation("GET products");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var products = await ctx.Products.ToArrayAsync();
        return _mapper.Map<IEnumerable<ProductGetDto>>(products);
    }

    [HttpGet("{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductGetDto>> Get(int productId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var getProduct = await ctx.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
        if (getProduct == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}.");
            return NotFound();
        }
        _logger.LogInformation($"GET product with ID: {productId}.");
        return Ok(_mapper.Map<ProductGetDto>(getProduct));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Post([FromBody] ProductPostDto productToPost)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        await ctx.Products.AddAsync(_mapper.Map<Product>(productToPost));
        await ctx.SaveChangesAsync();
        _logger.LogInformation($"POST product ({productToPost.ProductGroup}, {productToPost.ProductName}, {productToPost.ProductWeight}, {productToPost.ProductType}, {productToPost.ProductPrice}, {productToPost.DateStorage})");
        return Ok();
    }

    [HttpPut("{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int productId, [FromBody] ProductPostDto productToPut)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}");
            return NotFound();
        }
        _logger.LogInformation($"PUT product with ID: {productId} ({product.ProductName}->{productToPut.ProductName}, {product.ProductPrice}->{productToPut.ProductPrice})");
        _mapper.Map(productToPut, product);
        await ctx.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{productId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int productId)
    {
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var product = await ctx.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
        if (product == null)
        {
            _logger.LogInformation($"Not found product with ID: {productId}");
            return NotFound();
        }
        _logger.LogInformation($"DELETE product with ID: {productId}");
        ctx.Products.Remove(product);
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
