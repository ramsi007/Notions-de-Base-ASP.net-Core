using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Repository_DesignPattern.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Veuillez Entrez le nom de l'employée ")]
        [Display(Name="Nom de l'employé :")]
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
    }
}
