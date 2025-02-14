namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для добавления продукта в магазин.
/// </summary>
/// <param name="ProductId">ID продукта.</param>
/// <param name="StoreId">ID магазина.</param>
/// <param name="Quantity">Количество продукта.</param>
public record ProductStorePostDto(
    int ProductId = -1,
    int StoreId = -1,
    int Quantity = 0
);
