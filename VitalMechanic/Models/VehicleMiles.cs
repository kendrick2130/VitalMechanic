using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VitalMechanic.Models
{
    public class VehicleMiles
    {
        [Key]
        public int MileId { get; set; }
        public int CarGarageID { get; set; }
        [ForeignKey("CarGarageID")]
        public int Mileage { get; set; }
    }
}
