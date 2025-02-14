using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Server.Services;

namespace StoreApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnalyticsController(AnalyticsService _analyticsService, ILogger<AnalyticsController> _logger) : Controller
{
    [HttpGet("ProductsInSpecifiedStore/{storeId}")]
    public async Task<ActionResult> ProductsInSpecifiedStore(int storeId)
    {
        var result = await _analyticsService.GetProductsInSpecifiedStore(storeId);
        return Ok(result);
    }

    [HttpGet("StoresWithProduct/{productId}")]
    public async Task<ActionResult> StoresWithProduct(int productId)
    {
        var result = await _analyticsService.GetStoresWithProduct(productId);
        return Ok(result);
    }

    [HttpGet("InfomationAboutAvgPrice")]
    public async Task<ActionResult> InfomationAboutAvgPrice()
    {
        var result = await _analyticsService.GetAvgPriceByCategoryAndStore();
        return Ok(result);
    }

    [HttpGet("TopSales")]
    public async Task<ActionResult> TopSales()
    {
        var result = await _analyticsService.GetTopSales();
        return Ok(result);
    }

    [HttpGet("ExpiredProducts")]
    public async Task<ActionResult> ExpiredProducts()
    {
        var result = await _analyticsService.GetExpiredProducts();
        return Ok(result);
    }

    [HttpGet("StoresWithAmountMoreThen/{minSalesAmount}")]
    public async Task<ActionResult> StoresWithAmountMoreThen(double minSalesAmount)
    {
        try
        {
            var result = await _analyticsService.GetStoresWithSalesAbove(minSalesAmount);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}
