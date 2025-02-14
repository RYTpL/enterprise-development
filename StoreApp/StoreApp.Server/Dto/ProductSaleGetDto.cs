namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для получения информации о продаже продукта.
/// </summary>
/// <param name="Id">ID клиента.</param>
/// <param name="ProductId">ID продукта.</param>
/// <param name="SaleId">ID продажи.</param>
/// <param name="Quantity">Количество продукта.</param>
public record ProductSaleGetDto(
    int Id = -1,
    int ProductId = -1,
    int SaleId = -1,
    int Quantity = 0
);
