using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Trucks;

public class TruckClass
{
  private string Name { get; }
  private static int Capacity { get; set; }
  
  private readonly List<AbstractProduct> _unloadedProduct = new(Capacity);

  public TruckClass(string name, int capacity)
  {
    Name = name;
    Capacity = capacity;
  }

  public void WarehouseUnloading(List<AbstractProduct> products)
  {
    var threadWarehouseUnloading = new Thread(() =>
    {
      _unloadedProduct.AddRange(products);
      Console.WriteLine($"Выгрузка продуктов в грузовик {Name}");
      Thread.Sleep(2000);
      _unloadedProduct.Clear();
      Console.WriteLine($"Груз доставлен грузовиком {Name}");
    });
    
    threadWarehouseUnloading.Start();
  }
}