using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Factories.Abstract_factories;

public abstract class AbstractFactory(string nameFactory, string manufacturedProduct, double productionCoefficient)
{
    private const int N = 50;
    protected const int ProductionTime = 3600; // в секундах
    protected string NameFactory { get; } = nameFactory;
    protected string ManufacturedProduct { get; } = manufacturedProduct;
    public double SumOfProductsProducedOverTime { get; private set; } = N * productionCoefficient;

    protected abstract AbstractProduct CreateProduct(string name, string weidth, string typeOfPackaging);
}