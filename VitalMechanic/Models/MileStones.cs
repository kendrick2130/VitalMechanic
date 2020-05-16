using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VitalMechanic.Models
{
    public class MileStones
    {
        [Key]
        public int MileStoneId { get; set; }     
        public int VehicleMileStones { get; set; }
        public string MileStoneDescription { get; set; }

        [ForeignKey("CarGarageID")]
        public int CarGarageID { get; set; }
        
    }
}
