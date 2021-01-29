using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_WebApp.Models
{

    // Pour ajouter des nouveaux Chapms ds la table AspNetUsers
    public class ApplicationUser: IdentityUser  
    {
        public int Age { get; set; }
        public string City { get; set; }

    }
}
