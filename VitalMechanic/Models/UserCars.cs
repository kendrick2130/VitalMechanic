using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class UserCars
    {
        public int UserCarId { get; set; }
        public int? UserId { get; set; }
        public int? ModelId { get; set; }
        public int? YearMakeId { get; set; }

        public virtual CarModels Model { get; set; }
        public virtual UserloginTbl User { get; set; }
        public virtual CarYear YearMake { get; set; }
    }
}
