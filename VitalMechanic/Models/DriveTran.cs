using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VitalMechanic.Models
{
    public class DriveTran
    {
        [Key]
        public int DriveTranID { get; set; }
        public string DriveTranType { get; set; }
    }
}
