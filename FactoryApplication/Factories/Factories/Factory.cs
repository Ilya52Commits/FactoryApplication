using FactoryApplication.Factories.Abstract_factories;
using FactoryApplication.Products.Abstract_products;
using FactoryApplication.Products.Products;

namespace FactoryApplication.Factories.Factories;

public class Factory(string nameFactory, double productionCoefficient) : AbstractFactory(nameFactory, productionCoefficient)
{
  public delegate void ProcessOfTransferringProductsToWarehouse(List<AbstractProduct> products);
  public event ProcessOfTransferringProductsToWarehouse? GiveNoticeOfManufacture;
  
  protected override AbstractProduct CreateProduct(string name, string weidth, string typeOfPackaging) 
    => new Product(name, weidth, typeOfPackaging, NameFactory);

  public void StartFactory()
  {
    var threadProcessFactory = new Thread(() =>
    {
      while (true)
      {
        // Имитация времени изготовления
        Thread.Sleep(Time * 1000);
        var resultManufacture = CreateProductInThread();
        
        GiveNoticeOfManufacture?.Invoke(resultManufacture);
      }
    });
    
    threadProcessFactory.Start();
  }

  private List<AbstractProduct> CreateProductInThread()
  {
    // Создаем объект для хранения результатов
    List<AbstractProduct> products = [];

    for (var i = 0; i < N * productionCoefficient; i++)
    {
      Console.WriteLine($"Изготовление продуктов в час фабрики {nameFactory}");

      var name = $"Продукт фабрики {nameFactory}";
      var weidth = $"Вес продукта фабрики {nameFactory}";
      var typeOfPackaging = $"Тип продукта фабрики {nameFactory}";

      products.Add(CreateProduct(name, weidth, typeOfPackaging));
    }
  
    // Возвращаем созданные продукты
    return products;
  }
}