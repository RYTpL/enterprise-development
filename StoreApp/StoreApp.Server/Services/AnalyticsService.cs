using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreApp.Model;
using StoreApp.Server.Dto;

namespace StoreApp.Server.Services;

public class AnalyticsService
{
    private readonly IDbContextFactory<StoreAppContext> _contextFactory;
    private readonly IMapper _mapper;
    private readonly ILogger<AnalyticsService> _logger;

    public AnalyticsService(IDbContextFactory<StoreAppContext> contextFactory, IMapper mapper, ILogger<AnalyticsService> logger)
    {
        _contextFactory = contextFactory;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<ProductGetDto>> GetProductsInSpecifiedStore(int storeId)
    {
        _logger.LogInformation($"Fetching products for store ID: {storeId}");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return await (from ps in ctx.ProductStores
                      join p in ctx.Products on ps.ProductId equals p.ProductId
                      where ps.StoreId == storeId && ps.Quantity > 0
                      select _mapper.Map<ProductGetDto>(p)).ToListAsync();
    }

    public async Task<List<StoreGetDto>> GetStoresWithProduct(int productId)
    {
        _logger.LogInformation($"Fetching stores that have product ID: {productId}");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return await (from ps in ctx.ProductStores
                      join s in ctx.Stores on ps.StoreId equals s.StoreId
                      where ps.ProductId == productId && ps.Quantity > 0
                      select _mapper.Map<StoreGetDto>(s)).ToListAsync();
    }

    public async Task<List<object>> GetAvgPriceByCategoryAndStore()
    {
        _logger.LogInformation("Fetching average product prices by category and store");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return await (from ps in ctx.ProductStores
                      join p in ctx.Products on ps.ProductId equals p.ProductId
                      group p by new { p.ProductGroup, ps.StoreId } into grp
                      select new
                      {
                          StoreId = grp.Key.StoreId,
                          ProductCategory = grp.Key.ProductGroup,
                          AveragePrice = grp.Average(x => x.ProductPrice)
                      }).ToListAsync<object>();
    }

    public async Task<List<SaleGetDto>> GetTopSales()
    {
        _logger.LogInformation("Fetching top 5 sales by total amount");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return await ctx.Sales
            .OrderByDescending(s => s.Sum)
            .Take(5)
            .Select(s => _mapper.Map<SaleGetDto>(s))
            .ToListAsync();
    }

    public async Task<List<object>> GetExpiredProducts()
    {
        _logger.LogInformation("Fetching expired products");
        using var ctx = await _contextFactory.CreateDbContextAsync();
        return await (from ps in ctx.ProductStores
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
                      }).ToListAsync<object>();
    }

    public async Task<List<object>> GetStoresWithSalesAbove(double minSalesAmount)
    {
        _logger.LogInformation($"Fetching stores with sales above {minSalesAmount}");
        if (minSalesAmount <= 0)
        {
            throw new ArgumentException("minSalesAmount must be greater than zero");
        }

        using var ctx = await _contextFactory.CreateDbContextAsync();
        DateTime startDate = DateTime.Now.AddMonths(-2);

        return await (from sale in ctx.Sales
                      where sale.DateSale >= startDate
                      group sale by sale.StoreId into storeGroup
                      where storeGroup.Sum(s => s.Sum) >= minSalesAmount
                      select new
                      {
                          StoreId = storeGroup.Key,
                          TotalSales = storeGroup.Sum(s => s.Sum)
                      }).ToListAsync<object>();
    }
}
