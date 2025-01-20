namespace FactoryApplication.Products.Abstract_products;

/// <summary>
/// Абстрактный класс продукта
/// </summary>
/// <param name="name"></param>
/// <param name="weidth"></param>
/// <param name="typeOfPackaging"></param>
/// <param name="nameFactory"></param>
public abstract class AbstractProduct(string name, string weidth, string typeOfPackaging, string nameFactory)
{
    #region Свойства
    public string Name { get; protected init; } = name;
    public string Weidth { get; protected init; } = weidth;
    public string TypeOfPackaging { get; protected init; } = typeOfPackaging;
    public string NameFactory { get; protected init; } = nameFactory;
    #endregion
}