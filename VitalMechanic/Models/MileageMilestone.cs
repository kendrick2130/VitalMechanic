using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class MileageMilestone
    {
        public MileageMilestone()
        {
            CarMileageMilestone = new HashSet<CarMileageMilestone>();
        }

        public int Mileageid { get; set; }
        public int? CarMileage { get; set; }
        public string Milestones { get; set; }

        public virtual ICollection<CarMileageMilestone> CarMileageMilestone { get; set; }
    }
}
