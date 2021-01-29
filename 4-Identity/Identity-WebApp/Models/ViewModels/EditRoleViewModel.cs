using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_WebApp.Models.ViewModels
{
    public class EditRoleViewModel
    {
        public string RoleId { get; set; }
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }

        public List <string> Users { get; set; }

        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
    }

}
