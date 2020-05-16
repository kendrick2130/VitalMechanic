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
        public string CarModel { get; }
        public int Mileage { get; }
        public IEnumerable<VehicleMilestoneViewModel> Milestones { get; }

        public DashboardViewModel(string carModel, int mileage, IEnumerable<VehicleMilestoneViewModel> vehicleMileStones)
        {
            CarModel = carModel;
            Mileage = mileage;
            Milestones = vehicleMileStones;
        }
    }
}
