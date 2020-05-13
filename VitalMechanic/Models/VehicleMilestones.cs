using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VitalMechanic.Models
{
    public class VehicleMilestones
    {
        [Key]
        public int MileStoneId { get; set; }

        [ForeignKey("CarGarageId")]
        public int CarGarageId { get; set; }

        [ForeignKey("MileageId")]
        public int MileageId { get; set; }
        public int MileStones { get; set; }
        public string Descriptions { get; set; }
    }
}
