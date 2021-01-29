using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_WebApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int Age { get; set; }
        public string City { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirmer le mot de passe :")]
        [Compare("Password", ErrorMessage =" Le mot de passe et la confirmation sont pas identique")] // Compare c'est pour comparer le ConfirmPassword avec le Password
        public string ConfirmPassword { get; set; }
    }
}
