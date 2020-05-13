using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class CarMakes
    {
        public CarMakes()
        {
            CarModels = new HashSet<CarModels>();
        }

        public int CarMakesId { get; set; }
        public string Make { get; set; }

        public virtual ICollection<CarModels> CarModels { get; set; }
    }
}
