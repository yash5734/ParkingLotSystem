using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public abstract class Vehicle
    {
        public int licenceNumber;
        public VehicleType type;
        protected Vehicle(int licenceNumber, VehicleType type)
        {
            this.licenceNumber = licenceNumber;
            this.type = type;
        }
    }

    public class Car : Vehicle
    {
        public Car(int licenceNumber) : base(licenceNumber, VehicleType.CAR) { }
    }
    public class Truck : Vehicle
    {
        public Truck(int licenceNumber) : base(licenceNumber, VehicleType.TRUCK) { }
    }

    public class Bike : Vehicle
    {
        public Bike(int licenceNumber) : base(licenceNumber, VehicleType.BIKE) { }
    }

    public static class VehicleFactory
    {
        public static Vehicle CreateVehicle(VehicleType type, int licenceNumber)
        {
            return type switch
            {
                VehicleType.BIKE => new Bike(licenceNumber),
                VehicleType.CAR => new Car(licenceNumber),
                VehicleType.TRUCK => new Truck(licenceNumber),
                _ => throw new NotImplementedException()
            };

        }
    }
}
