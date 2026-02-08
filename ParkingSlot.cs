using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public class ParkingSlot
    {
        public int slotId;
        public SlotType slotType;
        public SlotStatus slotStatus;

        protected ParkingSlot(int slotId, SlotType slotType)
        {
            this.slotId = slotId;
            this.slotType = slotType;
            this.slotStatus = SlotStatus.Available;
        }

        public bool isAvailable()
        {
            return this.slotStatus == SlotStatus.Available;
        }

        public void free()
        {
            slotStatus = SlotStatus.Available;
        }

        public void occupy() 
        {
            slotStatus = SlotStatus.Occupied;
        }
    }

    public class CarSlot:ParkingSlot
    {
        public CarSlot(int slotId) : base(slotId, SlotType.CAR) { }
    }
    public class BikeSlot : ParkingSlot
    {
        public BikeSlot(int slotId) : base(slotId, SlotType.BIKE) { }
    }
    public class TruckSlot : ParkingSlot
    {
        public TruckSlot(int slotId) : base(slotId, SlotType.TRUCK) { }
    }
}
