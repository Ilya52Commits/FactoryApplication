using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Trucks;

public class TruckManager(List<Truck> trucks)
{
  private List<Truck> Trucks { get; set; } = trucks;

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