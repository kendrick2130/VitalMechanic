using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class CarMileageMilestone
    {
        public int UserCarsId { get; set; }
        public int CarMileageMilestoneId { get; set; }
        public DateTime? MaintenanceCompletionDate { get; set; }

        public virtual Mileage Mileage { get; set; }
    }
}
