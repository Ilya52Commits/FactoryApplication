using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Warehouse;

public class WarehouseClass
{
  public delegate void ProcessOfTransferringProductsFromWarehouseToTruck(List<AbstractProduct> products);
  public event ProcessOfTransferringProductsFromWarehouseToTruck? WarehouseOverflowNotification;

  private readonly List<AbstractProduct> _products = [];
  private int CapacityMultiplier { set; get; }
  private int CurrentLoad { get; set; }
  
  //private Thread ThreadWarehouseUnloading { get; set;}

  public WarehouseClass(int capacityMultiplier)
  {
    CapacityMultiplier = capacityMultiplier;
    //ThreadWarehouseUnloading = new Thread(  );
  }
  
  public void RetrieveProducts(List<AbstractProduct> products)
  {
      foreach (var product in products)
      {
        _products.Add(product);
      }

      CurrentLoad = _products.Count;

      if (!(CurrentLoad >= CapacityMultiplier * 0.95)) return;

      var truckingList = _products.Take((int)(CapacityMultiplier * 0.95)).ToList();

      if (truckingList.Count == 0) return;
      foreach (var product in truckingList)
      {
        Console.Write(product.Name + " ");
        _products.Remove(product);
      }

      Console.WriteLine();  

      WarehouseOverflowNotification?.Invoke(truckingList);
  }
}