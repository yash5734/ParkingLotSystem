using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public class ParkingFloor
    {
        public int floorId;
        public List<ParkingSlot> _slots;

        public ParkingFloor(int floorId)
        {
            this.floorId = floorId;
            this._slots = new List<ParkingSlot>();
        }

        public void AddSlots(ParkingSlot slot)
        {
            _slots.Add(slot);
        }

        public List<ParkingSlot> GetSlots()
        {
            return _slots;
        }

    }
}
