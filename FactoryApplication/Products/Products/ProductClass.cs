using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Products.Products;

public class ProductClass : AbstractProduct
{
  public ProductClass(string name, string weidth, string typeOfPackaging, string nameFactory) : base(name, weidth, typeOfPackaging, nameFactory)
  {
    Name = name; 
    Weidth = weidth;
    TypeOfPackaging = typeOfPackaging;
    NameFactory = nameFactory;
  }
}