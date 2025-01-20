using System.Collections.Concurrent;
using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Warehouse;

/// <summary>
/// Класс склада
/// </summary>
/// <param name="sumOfProductsOfFactories"></param>
public class Warehouse(double sumOfProductsOfFactories)
{
    #region События
    // Событие переполнения склада
    public event ProcessOfTransferringProductsFromWarehouseToTruck? WarehouseOverflowNotification;
    // Делегат для события
    public delegate List<AbstractProduct> ProcessOfTransferringProductsFromWarehouseToTruck(List<AbstractProduct> products);

    private const int M = 100;

    private readonly object _lockObject = new();

    // Главная коллекция склада
    private readonly List<AbstractProduct> _products = [];
    // Коллекция для не разгруженных продуктов
    private readonly ConcurrentQueue<AbstractProduct> _unloadedProducts = new();
    public double WarehouseSize { get; } = M * sumOfProductsOfFactories;
    private int _currentLoad { get; set; }
    #endregion
    
    #region Методы
    /// <summary>
    /// Метод добавления продуктов на склад
    /// </summary>
    /// <param name="products"></param>
    public void RetrieveProducts(List<AbstractProduct> products)
    {
        lock (_lockObject)
        {
            Console.WriteLine($"Поступление на склад продукта:\n" +
                              $"название - {products[0].Name};\n" +
                              $"фабрика - {products[0].NameFactory};\n" +
                              $"количество - {products.Count};\n");

            _products.AddRange(products);

            _currentLoad = _products.Count;

            if (!(_currentLoad >= WarehouseSize * 0.95)) return;

            var returnedProducts = WarehouseOverflowNotification?.Invoke(_products);

            if (returnedProducts == null) return;

            // если возвращаемая коллекция не null
            foreach (var product in returnedProducts)
            {
                _unloadedProducts.Enqueue(product);
            }

            // освобождение коллекции склада от возвращаемых продуктов
            if (returnedProducts.Count != 0)
                _products.RemoveRange(0, returnedProducts.Count);

            // вызов метода для повторной разгрузки
            UnloadingOfReturnedProducts();
        }
    }

    /// <summary>
    /// Метод для передачи в грузовик возвращённых продуктов
    /// </summary>
    private void UnloadingOfReturnedProducts()
    {
        var unloadingThread = new Thread(() =>
        {
            // пока очередь не пуста
            while (!_unloadedProducts.IsEmpty)
            {
                var returnedProducts = WarehouseOverflowNotification?.Invoke(_unloadedProducts.ToList());

                _unloadedProducts.Clear();

                if (returnedProducts == null)
                    return;

                foreach (var product in returnedProducts)
                {
                    _unloadedProducts.Enqueue(product);
                }
            }
        });

        unloadingThread.Start();
    }
    #endregion
}