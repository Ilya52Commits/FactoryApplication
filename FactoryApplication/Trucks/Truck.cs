using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Trucks;

public class Truck(string name, int capacity)
{
  private string Name { get; } = name;
  public  int Capacity { get; } = capacity;
  public TruckStatus Status { get; private set; } = TruckStatus.Free;
  private readonly object _lock = new();

  public void WarehouseUnloading(List<AbstractProduct> products)
  {
    Status = TruckStatus.OnTheRoad;
    
    var threadWarehouseUnloading = new Thread(() =>
    {
      List<AbstractProduct> unloadedProduct = new(Capacity);
      unloadedProduct.AddRange(products);
      
      Console.WriteLine($"Выгрузка продуктов в грузовик {Name}");
      unloadedProduct.Clear();
      Console.WriteLine($"Груз доставлен грузовиком {Name}");
      
      lock (_lock)
      {
        Status = TruckStatus.Free;
      }
    });
    
    threadWarehouseUnloading.Start();
  }
}

public enum TruckStatus
{
  OnTheRoad, 
  Free
}