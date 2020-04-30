using System;
using System.Collections.Generic;

namespace VitalMechanic.Models
{
    public partial class UserloginTbl
    {
        public UserloginTbl()
        {
            UserCars = new HashSet<UserCars>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserCars> UserCars { get; set; }
    }
}
