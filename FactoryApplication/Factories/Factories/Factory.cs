using FactoryApplication.Factories.Abstract_factories;
using FactoryApplication.Products.Abstract_products;
using FactoryApplication.Products.Products;

namespace FactoryApplication.Factories.Factories;

/// <summary>
/// Класс фабрики
/// </summary>
/// <param name="nameFactory"></param>
/// <param name="manufacturedProduct"></param>
/// <param name="productionCoefficient"></param>
public class Factory(string nameFactory, string manufacturedProduct, double productionCoefficient):AbstractFactory(nameFactory, manufacturedProduct, productionCoefficient)
{
    #region Свойства
    // Событие уведомления о создании продуктов
    public event ProcessOfTransferringProductsToWarehouse? GiveNoticeOfManufacture;
    // Делегат для события
    public delegate void ProcessOfTransferringProductsToWarehouse(List<AbstractProduct> products);
    #endregion

    #region Методы
    /// <summary>
    /// Переопределение метода создания продукта
    /// </summary>
    /// <param name="name"></param>
    /// <param name="weidth"></param>
    /// <param name="typeOfPackaging"></param>
    /// <returns></returns>
    protected override AbstractProduct CreateProduct(string name, string weidth, string typeOfPackaging) => new Product(name, weidth, typeOfPackaging, NameFactory);

    /// <summary>
    /// Метод запуска работы фабрики
    /// </summary>
    public void StartFactory()
    {
        var threadProcessFactory = new Thread(() =>
        {
            while (true)
            {
                // Имитация времени изготовления
                Thread.Sleep(ProductionTime * 1000);
                var resultManufacture = CreatingProductSetPerHour();

                GiveNoticeOfManufacture?.Invoke(resultManufacture);
            }
        });

        threadProcessFactory.Start();
    }

    /// <summary>
    /// Метод создания набора продуктов в час
    /// </summary>
    /// <returns></returns>
    private List<AbstractProduct> CreatingProductSetPerHour()
    {
        // Создаем объект для хранения результатов
        List<AbstractProduct> products = [];

        for (var i = 0; i < SumOfProductsProducedOverTime; i++)
        {
            products.Add(CreateProduct(
                                       ManufacturedProduct,
                                       "123",
                                       NameFactory));
        }

        // Возвращаем созданные продукты
        return products;
    }
    #endregion
}