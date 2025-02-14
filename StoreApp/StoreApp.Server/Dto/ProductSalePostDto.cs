namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для создания записи о продаже продукта.
/// </summary>
/// <param name="ProductId">ID продукта.</param>
/// <param name="SaleId">ID продажи.</param>
/// <param name="Quantity">Количество продукта.</param>
public record ProductSalePostDto(
    int ProductId = -1,
    int SaleId = -1,
    int Quantity = 0
);
