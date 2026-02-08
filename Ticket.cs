using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public class Ticket
    {
        public int ticketId;
        public Vehicle vehicle;
        public ParkingSlot parkingSlot;
        public DateTime entryTime;

        public Ticket(int ticketId, Vehicle vehicle, ParkingSlot parkingSlot)
        {
            this.ticketId = ticketId;
            this.vehicle = vehicle;
            this.parkingSlot = parkingSlot;
            this.entryTime = DateTime.Now;
        }
    }
}
