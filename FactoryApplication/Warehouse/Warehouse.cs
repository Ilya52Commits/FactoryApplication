using System.Collections.Concurrent;
using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Warehouse;

public class Warehouse(int capacityMultiplier)
{
  public delegate List<AbstractProduct> ProcessOfTransferringProductsFromWarehouseToTruck(List<AbstractProduct> products);
  public event ProcessOfTransferringProductsFromWarehouseToTruck? WarehouseOverflowNotification;

  private readonly List<AbstractProduct> _products = [];
  private readonly ConcurrentDictionary<int, List<AbstractProduct>> _unloadedProducts = new(); // словарь для сохранения не разгруженных продуктов
  private int CapacityMultiplier { get; } = capacityMultiplier;
  private int CurrentLoad { get; set; }
  
  public void RetrieveProducts(List<AbstractProduct> products)
  {
    Console.WriteLine($"Поступление на склад продукта:\n" +
                      $"название - {products[0].Name};\n" +
                      $"фабрика - {products[0].NameFactory};\n" +
                      $"количество - {products.Count};\n");
    
    _products.AddRange(products);

    CurrentLoad = _products.Count;

    if (!(CurrentLoad >= CapacityMultiplier * 0.95)) return;

    var returnedProducts = WarehouseOverflowNotification?.Invoke(_products);

    if (returnedProducts == null) return;
    // если возвращаемая коллекция не null
    var rnd = new Random();
    var randomIndexDictionary = rnd.Next(1, 101); // Случайное число от 1 до 100
    // добавление данных в словарь
    _unloadedProducts.TryAdd(randomIndexDictionary, returnedProducts);
    // освобождение коллекции склада от возвращаемых продуктов
    if (returnedProducts.Count != 0)
      _products.RemoveRange(0, returnedProducts.Count);
      
    // вызов метода для повторной разгрузки
    UnloadingOfReturnedProducts(); 
  }

  private void UnloadingOfReturnedProducts()
  {
    var unloadingThread = new Thread(() =>
    {
      // пока словарь не пустой
      while (!_unloadedProducts.IsEmpty)
        // проход по словарю
        foreach (var product in _unloadedProducts)
        {
          // вызов события грузовика
          var returnedProducts = WarehouseOverflowNotification?.Invoke(product.Value);
          // если набор возвращаемых элементов null, то коллекция удаляется
          if (returnedProducts == null)
            _unloadedProducts.TryRemove(product);
        }
    });
    
    unloadingThread.Start();
  }
}