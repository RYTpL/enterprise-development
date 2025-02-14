namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для получения информации о продукте в магазине.
/// </summary>
/// <param name="Id">ID клиента.</param>
/// <param name="ProductId">ID продукта.</param>
/// <param name="StoreId">ID магазина.</param>
/// <param name="Quantity">Количество продукта.</param>
public record ProductStoreGetDto(
    int Id = -1,
    int ProductId = -1,
    int StoreId = -1,
    int Quantity = 0
);
