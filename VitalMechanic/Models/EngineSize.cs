using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VitalMechanic.Models
{
    public class EngineSize
    {
        [Key]
        public int EngineID { get; set; }
        public string EngineType { get; set; }
    }
}
