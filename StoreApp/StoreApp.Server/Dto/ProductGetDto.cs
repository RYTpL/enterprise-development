namespace StoreApp.Server.Dto;

/// <summary>
/// DTO для получения информации о продукте.
/// </summary>
/// <param name="ProductId">ID продукта (соответствует его штрих-коду).</param>
/// <param name="ProductGroup">Группа продукта.</param>
/// <param name="ProductName">Название продукта.</param>
/// <param name="ProductWeight">Вес продукта.</param>
/// <param name="ProductType">Тип продукта (piece - true, weighted - false).</param>
/// <param name="ProductPrice">Цена продукта.</param>
/// <param name="DateStorage">Дата окончания срока хранения продукта.</param>
public record ProductGetDto(
    int ProductId = -1,
    int ProductGroup = -1,
    string ProductName = "",
    double ProductWeight = 0.0,
    bool ProductType = false,
    double ProductPrice = -1.0,
    DateTime DateStorage = default
)
{
    // Если DateStorage не указан, то присваиваем значение по умолчанию
    public DateTime DateStorage { get; init; } = DateStorage == default ? new DateTime(1970, 1, 1) : DateStorage;
}
