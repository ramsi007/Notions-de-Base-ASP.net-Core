using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FistProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Le nom du Produit est Obligatoire")]
        [Display(Name ="Désignation du Produit ")]
        [MaxLength(20)]
        [MinLength(5)]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Prix")]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Quantité ")]
        [Range(1,1000 , ErrorMessage = "la quantité doit etre supérieur à 0")]
        public int Quantity { get; set; }
    }
}
