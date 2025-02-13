using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Model;
using StoreApp.Server.Dto;
using Microsoft.Extensions.Logging;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(
    IDbContextFactory<StoreAppContext> _contextFactory,
    ILogger<AnalyticsController> _logger,
    IMapper _mapper) : Controller
{
    [HttpGet("/ProductsInSpecifiedStore/{storeId}")]
    public async Task<ActionResult> ProductsInSpecifiedStore(int storeId)
    {
        _logger.LogInformation($"Get information about products in store with ID: {storeId}");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from ps in ctx.ProductStores
                            join p in ctx.Products on ps.ProductId equals p.ProductId
                            join s in ctx.Stores on ps.StoreId equals s.StoreId
                            where s.StoreId == storeId && ps.Quantity > 0
                            select _mapper.Map<ProductGetDto>(p)).ToListAsync();

        return Ok(result);
    }

    [HttpGet("/StoresWithProduct/{productId}")]
    public async Task<ActionResult> StoresWithProduct(int productId)
    {
        _logger.LogInformation($"Get list of stores where product with ID {productId} is located in availability");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from ps in ctx.ProductStores
                            join p in ctx.Products on ps.ProductId equals p.ProductId
                            join s in ctx.Stores on ps.StoreId equals s.StoreId
                            where ps.Quantity > 0 && p.ProductId == productId
                            select _mapper.Map<StoreGetDto>(s)).ToListAsync();

        return Ok(result);
    }

    [HttpGet("/InfomationAboutAvgPrice")]
    public async Task<ActionResult> InfomationAboutAvgPrice()
    {
        _logger.LogInformation("Get information about the average cost of goods of each product group for each store.");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from ps in ctx.ProductStores
                            join p in ctx.Products on ps.ProductId equals p.ProductId
                            join s in ctx.Stores on ps.StoreId equals s.StoreId
                            group new { p, s } by new { p.ProductGroup, s.StoreId } into grp
                            select new
                            {
                                StoreId = grp.Key.StoreId,
                                ProductCategory = grp.Key.ProductGroup,
                                AveragePrice = grp.Average(x => x.p.ProductPrice)
                            }).ToListAsync();

        return Ok(result);
    }

    [HttpGet("/TopSales")]
    public async Task<ActionResult> TopSales()
    {
        _logger.LogInformation("Get top 5 purchases by total sale amount.");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await ((from sa in ctx.Sales
                             orderby sa.Sum descending
                             select _mapper.Map<SaleGetDto>(sa)).Take(5)).ToListAsync();
        return Ok(result);
    }

    [HttpGet("/ExpiredProducts")]
    public async Task<ActionResult> ExpiredProducts()
    {
        _logger.LogInformation("Display all information about products that exceed the storage date limit, indicating the store");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        var result = await (from ps in ctx.ProductStores
                            join p in ctx.Products on ps.ProductId equals p.ProductId
                            join s in ctx.Stores on ps.StoreId equals s.StoreId
                            where p.DateStorage < DateTime.Now
                            select new
                            {
                                StoreName = s.StoreName,
                                StoreAddress = s.StoreAddress,
                                ProductId = p.ProductId,
                                ProductGroup = p.ProductGroup,
                                ProductName = p.ProductName,
                                ProductWeight = p.ProductWeight,
                                ProductType = p.ProductType,
                                ProductPrice = p.ProductPrice,
                                DateStorage = p.DateStorage
                            }).ToListAsync();
        return Ok(result);
    }

    [HttpGet("/StoresWithAmountMoreThen/{minSalesAmount}")]
    public async Task<ActionResult> StoresWithAmountMoreThen(double minSalesAmount)
    {
        if (minSalesAmount <= 0)
        {
            _logger.LogInformation($"Trying to get stores with non-positive amount [minSalesAmount = {minSalesAmount}]");
            return BadRequest("Invalid minSalesAmount parameter");
        }

        _logger.LogInformation($"Display a list of stores that sold goods for the month amount more than {minSalesAmount}");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        DateTime startDate = DateTime.Now.AddMonths(-2);
        var result = await (from sale in ctx.Sales
                            where sale.DateSale >= startDate
                            group sale by sale.StoreId into storeGroup
                            select new
                            {
                                StoreId = storeGroup.Key,
                                TotalSales = storeGroup.Sum(sale => sale.Sum),
                            } into storeSales
                            where storeSales.TotalSales >= minSalesAmount
                            select new { StoreId = storeSales.StoreId, TotalSales = storeSales.TotalSales }).ToListAsync();
        return Ok(result);
    }
}
