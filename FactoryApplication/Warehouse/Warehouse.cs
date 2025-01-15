using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Warehouse;

public class Warehouse(int capacityMultiplier)
{
  public delegate List<AbstractProduct> ProcessOfTransferringProductsFromWarehouseToTruck(List<AbstractProduct> products);
  public event ProcessOfTransferringProductsFromWarehouseToTruck? WarehouseOverflowNotification;

  private readonly List<AbstractProduct> _products = [];
  private int CapacityMultiplier { set; get; } = capacityMultiplier;
  private int CurrentLoad { get; set; }
  
  public void RetrieveProducts(List<AbstractProduct> products)
  {
      foreach (var product in products)
      {
        _products.Add(product);
      }

      CurrentLoad = _products.Count;

      if (!(CurrentLoad >= CapacityMultiplier * 0.95)) return;
      
      var unloadedProducts = WarehouseOverflowNotification?.Invoke(_products);
      
      
  }
}