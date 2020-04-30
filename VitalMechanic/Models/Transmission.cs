using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VitalMechanic.Models
{
    public class Transmission
    {
        [Key]
        public int TransmissionID { get; set; }
        public string TransmissionType { get; set; }
    }
}
