namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для создания новой продажи.
/// </summary>
/// <param name="DateSale">Дата и время продажи.</param>
/// <param name="CustomerId">ID клиента.</param>
/// <param name="StoreId">ID магазина.</param>
/// <param name="Sum">Сумма покупки.</param>
public record SalePostDto(
    DateTime DateSale = default,
    int CustomerId = -1,
    int StoreId = -1,
    double Sum = 0.0
)
{
    // Устанавливаем значение по умолчанию для DateSale
    public DateTime DateSale { get; init; } = DateSale == default ? new DateTime(1970, 1, 1) : DateSale;
}
