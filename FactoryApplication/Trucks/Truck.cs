using FactoryApplication.Products.Abstract_products;

namespace FactoryApplication.Trucks;

public class Truck(string name, int capacity)
{
    private readonly object _lock = new();
    private string Name { get; } = name;
    public int Capacity { get; } = capacity;
    public TruckStatus Status { get; private set; } = TruckStatus.Free;

    public void WarehouseUnloading(List<AbstractProduct> products)
    {
        Status = TruckStatus.OnTheRoad;

        var threadWarehouseUnloading = new Thread(() =>
        {
            List<AbstractProduct> unloadedProduct = new(Capacity);
            unloadedProduct.AddRange(products);

            // Подсчет статистики
            var productStatistics = new Dictionary<string, int>();

            foreach (var product in unloadedProduct)
            {
                if (productStatistics.ContainsKey(product.Name))
                    productStatistics[product.Name]++;
                else
                    productStatistics[product.Name] = 1;
            }


            unloadedProduct.Clear();

            Console.WriteLine();
            // Вывод статистики
            Console.WriteLine($"Статистика выгрузки для грузовика {Name}:");
            Console.WriteLine($"Всего продуктов {productStatistics.Count}");

            foreach (var stat in productStatistics)
            {
                Console.WriteLine($"Продукт: {stat.Key}, Количество: {stat.Value}");
            }

            Console.WriteLine();

            lock (_lock)
            {
                Status = TruckStatus.Free;
            }
        });

        threadWarehouseUnloading.Start();
    }
}

public enum TruckStatus
{
    OnTheRoad,
    Free
}