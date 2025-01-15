using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Trucks;

public class Truck
{
  private string Name { get; }
  public  int Capacity { get; set; }
  public TruckStatus Status { get; set; }
  private readonly object _lock = new();
  public Truck(string name, int capacity)
  {
    Name = name;
    Capacity = capacity;
    Status = TruckStatus.Free;
  }

  public void WarehouseUnloading(List<AbstractProduct> products)
  {
    Status = TruckStatus.OnTheRoad;
    
    var threadWarehouseUnloading = new Thread(() =>
    {
      List<AbstractProduct> unloadedProduct = new(Capacity);
      unloadedProduct.AddRange(products);
      
      Console.WriteLine($"Выгрузка продуктов в грузовик {Name}");
      Thread.Sleep(2000);
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

// создать класс truckManager, который будет регулировать грузовики