using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Products.Products;

/// <summary>
/// Класс продукта
/// </summary>
public class Product:AbstractProduct
{
    /// <summary>
    /// Конструктор класса продукта
    /// </summary>
    /// <param name="name"></param>
    /// <param name="weidth"></param>
    /// <param name="typeOfPackaging"></param>
    /// <param name="nameFactory"></param>
    public Product(string name, string weidth, string typeOfPackaging, string nameFactory):base(name, weidth, typeOfPackaging, nameFactory)
    {
        Name = name;
        Weidth = weidth;
        TypeOfPackaging = typeOfPackaging;
        NameFactory = nameFactory;
    }
}