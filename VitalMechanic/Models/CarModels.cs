using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class CarModels
    {

        public int CarModelsId { get; set; }
        public string Model { get; set; }
        public int CarMakesId { get; set; }

        public virtual CarMakes Make { get; set; }

    }
}
