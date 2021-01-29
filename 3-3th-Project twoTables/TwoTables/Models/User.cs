using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwoTables.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Display(Name ="Nom et Prénom :")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Pseudo :")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Mot de passe :")]
        [DataType(DataType.Password)] // Définir le type Password
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }
    }
}
