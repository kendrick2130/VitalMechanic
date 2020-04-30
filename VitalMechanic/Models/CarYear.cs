using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class CarYear
    {
        public CarYear()
        {
            UserCars = new HashSet<UserCars>();
        }

        public int YearMakeId { get; set; }
        public string YearOfMake { get; set; }

        public virtual ICollection<UserCars> UserCars { get; set; }
    }
}
