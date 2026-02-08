using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public interface IPricingStrategy
    {
        public double CalculatePrice(Ticket ticket);
    }

    public class HourlyPricingStrategy : IPricingStrategy
    {
        public double CalculatePrice(Ticket ticket)
        {
            TimeSpan duration = DateTime.Now - ticket.entryTime;
            return Math.Ceiling(duration.TotalHours) * GetRate(ticket.vehicle.type);
        }
        private double GetRate(VehicleType type)
        {
            switch (type)
            {
                case VehicleType.CAR:
                    return 10.0;
                case VehicleType.BIKE:
                    return 5.0;
                case VehicleType.TRUCK:
                    return 15.0;
                default:
                    return 0.0;
            }
        }
    }
}
