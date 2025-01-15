using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Factories.Abstract_factories;

public abstract class AbstractFactory(string nameFactory, double productionCoefficient)
{
  protected string NameFactory { get; set; } = nameFactory;
  protected const int N = 3;
  protected const int Time = 5; 
  private double ProductionCoefficient { get; set; } = productionCoefficient;

  protected abstract AbstractProduct CreateProduct(string name, string weidth, string typeOfPackaging);
} 