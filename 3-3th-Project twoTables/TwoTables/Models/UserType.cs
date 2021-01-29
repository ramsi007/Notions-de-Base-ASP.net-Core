using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwoTables.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }

        [Display(Name="Type user")]
        public string TypeDesc { get; set; }
        public ICollection<User> Users { get; set;}
    }
}
