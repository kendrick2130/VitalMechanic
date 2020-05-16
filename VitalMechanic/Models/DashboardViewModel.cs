using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public struct VehicleMilestoneViewModel
    {
        public VehicleMilestoneViewModel(int vehicleMileStones, string mileStoneDescription)
        {
            VehicleMileStones = vehicleMileStones;
            MileStoneDescription = mileStoneDescription;
        }

        public int VehicleMileStones { get; }
        public string MileStoneDescription { get; }
    }

    public class DashboardViewModel
    {
        public int CarGarageID { get; }
        public int Mileage { get; }
        public IEnumerable<VehicleMilestoneViewModel> Milestones { get; }

        public DashboardViewModel(int carGarageID, int mileage, IEnumerable<VehicleMilestoneViewModel> vehicleMileStones)
        {
            CarGarageID = carGarageID;
            Mileage = mileage;
            Milestones = vehicleMileStones;
        }
    }
}
