using StoreApp.Model;

namespace StoreApp.Server.Repository
{
    /// Интерфейс репозитория для работы с данными приложения StoreApp.
    /// Предоставляет доступ к коллекциям сущностей, таких как покупатели, товары, магазины и продажи.
    public interface IStoreAppRepository
    {
        /// Получает список всех клиентов.
        List<Customer> Customers { get; }

        /// Получает список всех продуктов.
        List<Product> Products { get; }


        /// Получает список всех магазинов.
        List<Store> Stores { get; }

        /// Получает список всех продаж продуктов.
        List<ProductSale> ProductSales { get; }

        /// Получает список всех связей между продуктами и магазинами.
        List<ProductStore> ProductStores { get; }

        /// Получает список всех продаж.
        List<Sale> Sales { get; }
    }
}
