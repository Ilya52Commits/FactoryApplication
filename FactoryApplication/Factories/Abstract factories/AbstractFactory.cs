using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Factories.Abstract_factories;

/// <summary>
/// Абстрактный класс фабрики
/// </summary>
/// <param name="nameFactory"></param>
/// <param name="manufacturedProduct"></param>
/// <param name="productionCoefficient"></param>
public abstract class AbstractFactory(string nameFactory, string manufacturedProduct, double productionCoefficient)
{
    #region Свойства
    private const int N = 50;
    // время создания продуктов
    protected const int ProductionTime = 3600; // в секундах
    protected string NameFactory { get; } = nameFactory;
    // название продукта
    protected string ManufacturedProduct { get; } = manufacturedProduct;
    // сумма продуктов за время
    public double SumOfProductsProducedOverTime { get; private set; } = N * productionCoefficient;
    #endregion
    
    /// <summary>
    /// Метод создания продукта
    /// </summary>
    /// <param name="name"></param>
    /// <param name="weidth"></param>
    /// <param name="typeOfPackaging"></param>
    /// <returns></returns>
    protected abstract AbstractProduct CreateProduct(string name, string weidth, string typeOfPackaging);
}