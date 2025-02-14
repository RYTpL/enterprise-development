using AutoMapper;
using StoreApp.Model;
using StoreApp.Server.Dto;

namespace StoreApp.Server;

/// <summary>
/// Профиль маппинга для AutoMapper, определяющий соответствие между сущностями и DTO.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Конструктор, в котором настраиваются все маппинги.
    /// </summary>
    public MappingProfile()
    {
        ConfigureCustomerMappings();
        ConfigureProductMappings();
        ConfigureSaleMappings();
        ConfigureStoreMappings();
    }

    /// <summary>
    /// Настройка маппинга для сущности Customer.
    /// </summary>
    private void ConfigureCustomerMappings()
    {
        CreateMap<Customer, CustomerGetDto>(); // Маппинг Customer -> CustomerGetDto
        CreateMap<CustomerPostDto, Customer>(); // Маппинг CustomerPostDto -> Customer
    }

    /// <summary>
    /// Настройка маппинга для сущности Product.
    /// </summary>
    private void ConfigureProductMappings()
    {
        CreateMap<Product, ProductGetDto>(); // Маппинг Product -> ProductGetDto
        CreateMap<ProductPostDto, Product>(); // Маппинг ProductPostDto -> Product
        CreateMap<ProductSale, ProductSaleGetDto>(); // Маппинг ProductSale -> ProductSaleGetDto
        CreateMap<ProductSalePostDto, ProductSale>(); // Маппинг ProductSalePostDto -> ProductSale
        CreateMap<ProductStore, ProductStoreGetDto>(); // Маппинг ProductStore -> ProductStoreGetDto
        CreateMap<ProductStorePostDto, ProductStore>(); // Маппинг ProductStorePostDto -> ProductStore
    }

    /// <summary>
    /// Настройка маппинга для сущности Sale.
    /// </summary>
    private void ConfigureSaleMappings()
    {
        CreateMap<Sale, SaleGetDto>(); // Маппинг Sale -> SaleGetDto
        CreateMap<SalePostDto, Sale>(); // Маппинг SalePostDto -> Sale
    }

    /// <summary>
    /// Настройка маппинга для сущности Store.
    /// </summary>
    private void ConfigureStoreMappings()
    {
        CreateMap<Store, StoreGetDto>(); // Маппинг Store -> StoreGetDto
        CreateMap<StorePostDto, Store>(); // Маппинг StorePostDto -> Store
    }
}
