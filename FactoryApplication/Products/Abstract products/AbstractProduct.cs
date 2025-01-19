namespace FactoryApplication.Products.Abstract_products;

public abstract class AbstractProduct(string name, string weidth, string typeOfPackaging, string nameFactory)
{
    public string Name { get; protected init; } = name;
    public string Weidth { get; protected init; } = weidth;
    public string TypeOfPackaging { get; protected init; } = typeOfPackaging;

    public string NameFactory { get; protected init; } = nameFactory;
}