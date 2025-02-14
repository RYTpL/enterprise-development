namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для получения информации о магазине.
/// </summary>
/// <param name="StoreId">ID магазина.</param>
/// <param name="StoreName">Название магазина.</param>
/// <param name="StoreAddress">Адрес магазина.</param>
public record StoreGetDto(
    int StoreId = -1,
    string StoreName = "",
    string StoreAddress = ""
);
