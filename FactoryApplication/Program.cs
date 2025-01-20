using FactoryApplication.Factories.Factories;
using FactoryApplication.Trucks;
using FactoryApplication.Warehouse;

// Создание фабрик
var factoryA = new Factory("Фабрика А", "a", 1);
var factoryB = new Factory("Фабрика B", "b", 1.1);
var factoryC = new Factory("Фабрика C", "c", 1.2);

var sumOfFactories = factoryA.SumOfProductsProducedOverTime + factoryB.SumOfProductsProducedOverTime + factoryC.SumOfProductsProducedOverTime;

// Создание склада
var warehouse = new Warehouse(sumOfFactories);

// Рассчитываем 60% и 40% от WarehouseSize
var warehouseSize = warehouse.WarehouseSize;
var capacityForTruckFirst = (int)(warehouseSize * 0.6);
var capacityForTruckSecond = (int)(warehouseSize * 0.4);

// Создаем грузовики с рассчитанными емкостями
var truckFirst = new Truck("Большой грузовик", capacityForTruckFirst);
var truckSecond = new Truck("Малый грузовик", capacityForTruckSecond);

var truckManager = new TruckManager([truckFirst, truckSecond]);

factoryA.GiveNoticeOfManufacture += warehouse.RetrieveProducts;
factoryB.GiveNoticeOfManufacture += warehouse.RetrieveProducts;
factoryC.GiveNoticeOfManufacture += warehouse.RetrieveProducts;

warehouse.WarehouseOverflowNotification += truckManager.StartTruckManager;

// Запуск работы фабрик
factoryA.StartFactory();
factoryB.StartFactory();
factoryC.StartFactory();

Console.WriteLine();