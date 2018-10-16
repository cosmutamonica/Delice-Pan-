using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Suporteri.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name = "Denumire")]
        public string ProductName { get; set; }

        [Required, StringLength(10000), Display(Name = "Descriere"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Required, Display(Name = "Pret")]
        [Range(0, 1000, ErrorMessage = "Introduceti un pret valid.")]
        public double? UnitPrice { get; set; }

        [Display(Name = "Categorie")]
        public string Category { get; set; }
        
       // public virtual Category Category { get; set; }
    }
}