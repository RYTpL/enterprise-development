namespace StoreApp.Server.Services
{
    public interface IItemService
    {
        IEnumerable<string> GetItems();  // Метод для получения списка элементов
    }
}
