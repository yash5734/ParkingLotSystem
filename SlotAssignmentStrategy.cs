using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotSystem
{
    public interface ISlotAssignmentStrategy
    {
        public ParkingSlot AssignSlot(Vehicle vehicle, List<ParkingFloor> parkingFloors);
    }

    public class NearestSlotAssignmentStrategy : ISlotAssignmentStrategy
    {
        public ParkingSlot AssignSlot(Vehicle vehicle, List<ParkingFloor> parkingFloors)
        {
            foreach(var floor in parkingFloors) { 
                foreach(var slot in floor.GetSlots())
                {
                    if(slot.slotStatus == SlotStatus.Available && slot.slotType.ToString() == vehicle.type.ToString())
                    {
                        return slot;
                    }
                }
                
            }
            return null;
        }
    }
}
