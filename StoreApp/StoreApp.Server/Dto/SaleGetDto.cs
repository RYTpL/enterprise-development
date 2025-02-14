namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для получения информации о продаже.
/// </summary>
/// <param name="SaleId">ID продажи.</param>
/// <param name="DateSale">Дата и время продажи.</param>
/// <param name="CustomerId">ID клиента.</param>
/// <param name="StoreId">ID магазина.</param>
/// <param name="Sum">Сумма покупки.</param>
public record SaleGetDto(
    int SaleId = -1,
    int CustomerId = -1,
    int StoreId = -1,
    double Sum = 0.0
)
{
    // Инициализируем DateSale значением по умолчанию в теле конструктора.
    public DateTime DateSale { get; init; } = new DateTime(1970, 1, 1);
}
