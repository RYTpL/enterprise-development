namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для создания нового магазина.
/// </summary>
/// <param name="StoreName">Название магазина.</param>
/// <param name="StoreAddress">Адрес магазина.</param>
public record StorePostDto(
    string StoreName = "",
    string StoreAddress = ""
);
