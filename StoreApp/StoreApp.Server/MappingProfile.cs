using AutoMapper;
using StoreApp.Model;
using StoreApp.Server.Dto;

namespace StoreApp.Server;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ConfigureCustomerMappings();
        ConfigureProductMappings();
        ConfigureSaleMappings();
        ConfigureStoreMappings();
    }

    private void ConfigureCustomerMappings()
    {
        CreateMap<Customer, CustomerGetDto>();
        CreateMap<CustomerPostDto, Customer>();
    }

    private void ConfigureProductMappings()
    {
        CreateMap<Product, ProductGetDto>();
        CreateMap<ProductPostDto, Product>();
        CreateMap<ProductSale, ProductSaleGetDto>();
        CreateMap<ProductSalePostDto, ProductSale>();
        CreateMap<ProductStore, ProductStoreGetDto>();
        CreateMap<ProductStorePostDto, ProductStore>();
    }

    private void ConfigureSaleMappings()
    {
        CreateMap<Sale, SaleGetDto>();
        CreateMap<SalePostDto, Sale>();
    }

    private void ConfigureStoreMappings()
    {
        CreateMap<Store, StoreGetDto>();
        CreateMap<StorePostDto, Store>();
    }
}
