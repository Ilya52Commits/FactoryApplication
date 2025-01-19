using FactoryApplication.Factories.Factories;
using FactoryApplication.Trucks;
using FactoryApplication.Warehouse;

var fabricA = new Factory("Фабрика А", "a", 1);
var fabricB = new Factory("Фабрика Б", "b", 1.1);
var fabricC = new Factory("Фабрика C", "c", 1.2);

var sumOfFactories = fabricA.SumOfProductsProducedOverTime + fabricB.SumOfProductsProducedOverTime + fabricC.SumOfProductsProducedOverTime;

var warehouse = new Warehouse(sumOfFactories);

// Рассчитываем 60% и 40% от CapacityMultiplier
var warehouseSize = warehouse.WarehouseSize;
var capacityForTruckFirst = (int)(warehouseSize * 0.6);
var capacityForTruckSecond = (int)(warehouseSize * 0.4);

// Создаем грузовики с рассчитанными емкостями
var truckFirst = new Truck("Truck First", capacityForTruckFirst);
var truckSecond = new Truck("Truck Second", capacityForTruckSecond);

var truckManager = new TruckManager([truckFirst, truckSecond]);

fabricA.GiveNoticeOfManufacture += warehouse.RetrieveProducts;
fabricB.GiveNoticeOfManufacture += warehouse.RetrieveProducts;
fabricC.GiveNoticeOfManufacture += warehouse.RetrieveProducts;

warehouse.WarehouseOverflowNotification += truckManager.StartTruckManager;

fabricA.StartFactory();
fabricB.StartFactory();
fabricC.StartFactory();

Console.WriteLine();