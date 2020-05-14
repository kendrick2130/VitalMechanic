using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VitalMechanic.Models
{
    public class CarGarage
    {
        [Key]
        public int CarGarageID { get; set; }
        public int CarYear { get; set; }        
        public string CarMake { get; set; }
        [ForeignKey("CarModelsId")]
        public int CarModelsId { get; set; }   
        public string CarModels { get; set; }
        public string DriveTran { get; set; }
        public string EngineSize { get; set; }
        public string Transmission { get; set; }


    }
}
