using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Trucks;

/// <summary>
/// Класс управления работы грузовиками
/// </summary>
/// <param name="trucks"></param>
public class TruckManager(List<Truck> trucks)
{
  // Набор грузовиков
  private List<Truck> Trucks { get; } = trucks;

  /// <summary>
  /// Запуск работы менеджера грузовиков
  /// </summary>
  /// <param name="products"></param>
  /// <returns></returns>
  public List<AbstractProduct> StartTruckManager(List<AbstractProduct> products)
  {
    while (products.Count > 0)
    {
      var truck = Trucks.FirstOrDefault(truck => truck.Status == TruckStatus.Free);

      if (truck == null)
        return products;

      var submersibleProducts = products.Take(truck.Capacity).ToList();

      truck.WarehouseUnloading(submersibleProducts);

      products.RemoveAll(product => submersibleProducts.Contains(product));
    }

    return products;
  }
}