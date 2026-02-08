using ParkingLotSystem;

class Program
{
    public static void Main()
    {
        var _slotAssignmentStrategy = new NearestSlotAssignmentStrategy();
        var _pricingStrategy = new HourlyPricingStrategy();
        var parkinglot = ParkingLot.GetInstance(_slotAssignmentStrategy,_pricingStrategy);


        // ceate ground floor with some slots
        ParkingFloor _groundFloor = new ParkingFloor(0);
        _groundFloor.AddSlots(new CarSlot(new Random().Next(1000, 9999)));
        _groundFloor.AddSlots(new BikeSlot(new Random().Next(1000, 9999)));
        _groundFloor.AddSlots(new TruckSlot(new Random().Next(1000, 9999)));

        // add floor
        parkinglot.AddFloor(_groundFloor);

        // now one vehicle come for parking

        Vehicle vehicle1 = new Car(123);
        Ticket vehicle1_ticket = parkinglot.ParkVehicle(vehicle1);

        Thread.Sleep(2000);

        // after some time vehicle1 come to exit
        var cost = parkinglot.UnparkVehicle(vehicle1_ticket);
        Console.WriteLine(cost);
    }
}