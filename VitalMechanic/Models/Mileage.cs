using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VitalMechanic.Models
{
    public partial class Mileage
    {
        public Mileage()
        {
            CarMileageMilestone = new HashSet<CarMileageMilestone>();
        }

        public int MileageId { get; set; }
        public int CarGarageId { get; set; }
        public int CarMileage { get; set; }
        

        public virtual ICollection<CarMileageMilestone> CarMileageMilestone { get; set; }
    }
}
