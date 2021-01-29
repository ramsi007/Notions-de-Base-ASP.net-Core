using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FistProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage="Le nom est obligatoire")]
        [Display(Name = "Nom de l'employé")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Le salaire est obligatoire")]
        [Range(990, 5000, ErrorMessage = "Le salaire doit etre entre 990 et 5000")]
        [Display(Name = "Salaire")]
        public string Salary { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date de Naissance")]
        public DateTime BirthDate { get; set; }
    }
}
