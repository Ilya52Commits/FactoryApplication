using FactoryApplication.Factories.Factories;
using FactoryApplication.Trucks;
using FactoryApplication.Warehouse;

var fabricA = new FactoryClass("Фабрика А", 1);
var fabricB = new FactoryClass("Фабрика Б", 1.1);
var fabricC = new FactoryClass("Фабрика C", 1.2);

var warehouse = new WarehouseClass(10);

var truckFirst = new TruckClass("Truck First", 6);
var truckSecond = new TruckClass("Truck Second", 4);

fabricA.GiveNoticeOfManufacture += warehouse.RetrieveProducts;
fabricB.GiveNoticeOfManufacture += warehouse.RetrieveProducts;
fabricC.GiveNoticeOfManufacture += warehouse.RetrieveProducts;

warehouse.WarehouseOverflowNotification += truckFirst.WarehouseUnloading;

fabricA.StartFactory();
fabricB.StartFactory();
fabricC.StartFactory();
// обезопасить склад (синглтон)

Console.WriteLine();