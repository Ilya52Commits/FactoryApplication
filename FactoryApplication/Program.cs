using FactoryApplication.Factories.Factories;
using FactoryApplication.Trucks;
using FactoryApplication.Warehouse;

var fabricA = new Factory("Фабрика А", 1);
var fabricB = new Factory("Фабрика Б", 1.1);
var fabricC = new Factory("Фабрика C", 1.2);

var warehouse = new Warehouse(10);


var truckFirst = new Truck("Truck First", 6);
var truckSecond = new Truck("Truck Second", 4);

var truckManager = new TruckManager([truckFirst, truckSecond]);

fabricA.GiveNoticeOfManufacture += warehouse.RetrieveProducts;
fabricB.GiveNoticeOfManufacture += warehouse.RetrieveProducts;
fabricC.GiveNoticeOfManufacture += warehouse.RetrieveProducts;

warehouse.WarehouseOverflowNotification += truckManager.StartTruckManager;

fabricA.StartFactory();
fabricB.StartFactory();
fabricC.StartFactory();
// обезопасить склад (синглтон)

Console.WriteLine();