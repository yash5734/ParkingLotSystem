using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public class ParkingLot
    {
        public List<ParkingFloor> _floors = new List<ParkingFloor>();
        public IPricingStrategy _pricingStrategy;
        public ISlotAssignmentStrategy _slotAssignmentStrategy;
        private static Lazy<ParkingLot> _instance;

        private ParkingLot(ISlotAssignmentStrategy slotStrategy, IPricingStrategy pricingStrategy)
        {
            _floors = new List<ParkingFloor>();
            _slotAssignmentStrategy = slotStrategy;
            _pricingStrategy = pricingStrategy;
        }

        public static ParkingLot GetInstance(ISlotAssignmentStrategy slotStrategy, IPricingStrategy pricingStrategy)
        {
            if (_instance == null)
            {
                _instance = new Lazy<ParkingLot>(() => new ParkingLot(slotStrategy, pricingStrategy));
            }
            return _instance.Value;
        }

        public void AddFloor(ParkingFloor floor)
        {
            _floors.Add(floor);
        }
        public Ticket ParkVehicle(Vehicle vehicle)
        {
            ParkingSlot slot = _slotAssignmentStrategy.AssignSlot(vehicle, _floors);
            if (slot != null)
            {
                slot.slotStatus = SlotStatus.Occupied;
                return new Ticket(new Random().Next(1000, 9999), vehicle, slot);
            }
            throw new Exception("No Free Slot.");
        }

        public double UnparkVehicle(Ticket ticket)
        {
            ticket.parkingSlot.free();
            return _pricingStrategy.CalculatePrice(ticket);
        }

    }
}
