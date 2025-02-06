using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Trucks;

/// <summary>
/// Класс грузовика
/// </summary>
/// <param name="name"></param>
/// <param name="capacity"></param>
public class Truck(string name, int capacity)
{
  #region Свойства

  // объект-заглушка
  private readonly object _lock = new();
  private string Name { get; } = name;

  public int Capacity { get; } = capacity;

  // статус занятости грузовика
  public TruckStatus Status { get; private set; } = TruckStatus.Free;

  #endregion

  /// <summary>
  /// Получение продуктов со склада
  /// </summary>
  /// <param name="products"></param>
  public void WarehouseUnloading(List<AbstractProduct> products)
  {
    Status = TruckStatus.OnTheRoad;

    var threadWarehouseUnloading = new Thread(() =>
    {
      List<AbstractProduct> unloadedProduct = new(Capacity);
      unloadedProduct.AddRange(products);

      // Подсчет статистики
      var productStatistics = new Dictionary<string, int>();

      foreach (var product in unloadedProduct)
        if (productStatistics.ContainsKey(product.Name))
          productStatistics[product.Name]++;
        else
          productStatistics[product.Name] = 1;


      unloadedProduct.Clear();

      Console.WriteLine();
      // Вывод статистики
      Console.WriteLine($"Статистика выгрузки для грузовика {Name}:");
      Console.WriteLine($"Всего продуктов {productStatistics.Count}");

      foreach (var stat in productStatistics)
        Console.WriteLine($"Продукт: {stat.Key}, Количество: {stat.Value}");

      Console.WriteLine();

      lock (_lock)
      {
        Status = TruckStatus.Free;
      }
    });

    threadWarehouseUnloading.Start();
  }
}

/// <summary>
/// Тип для статуса занятости грузовика
/// </summary>
public enum TruckStatus
{
  OnTheRoad,
  Free
}