namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для создания нового клиента.
/// </summary>
/// <param name="CustomerName">Полное имя клиента.</param>
/// <param name="CustomerCardNumber">Номер карты клиента.</param>
public record CustomerPostDto(string CustomerName, int CustomerCardNumber);
