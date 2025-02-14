namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для получения информации о клиенте.
/// </summary>
/// <param name="CustomerId">ID клиента.</param>
/// <param name="CustomerName">Полное имя клиента.</param>
/// <param name="CustomerCardNumber">Номер карты клиента.</param>
public record CustomerGetDto(int CustomerId, string CustomerName, int CustomerCardNumber);
