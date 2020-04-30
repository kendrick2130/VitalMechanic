using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class CarModels
    {
        public CarModels()
        {
            UserCars = new HashSet<UserCars>();
        }

        public int ModelId { get; set; }
        public string Model { get; set; }
        public int MakeId { get; set; }

        public virtual CarMakes Make { get; set; }
        public virtual ICollection<UserCars> UserCars { get; set; }
    }
}
