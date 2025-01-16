using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Factories.Abstract_factories;

public abstract class AbstractFactory( string nameFactory, string manufacturedProduct, double productionCoefficient)
{
  protected string NameFactory { get; } = nameFactory;
  protected string ManufacturedProduct { get; } = manufacturedProduct;
  protected const int N = 3;
  protected const int Time = 5;
  protected double ProductionCoefficient { get; } = productionCoefficient;

  protected abstract AbstractProduct CreateProduct(string name, string weidth, string typeOfPackaging);
} 