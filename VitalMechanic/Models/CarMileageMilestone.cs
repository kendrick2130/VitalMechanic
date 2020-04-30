using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class CarMileageMilestone
    {
        public int UserCarId { get; set; }
        public int? Mileageid { get; set; }
        public DateTime? MaintenanceCompletionDate { get; set; }

        public virtual MileageMilestone Mileage { get; set; }
    }
}
