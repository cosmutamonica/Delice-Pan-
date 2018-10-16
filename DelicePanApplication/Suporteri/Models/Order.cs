﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Suporteri.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Required, Display(Name = "Produs")]
        public string ProductName { get; set; }

        [Required, Display(Name = "Data livrarii")]
        public DateTime DeliveryDate { get; set; }

        [Required, Display(Name = "Data comenzii")]
        public DateTime OrderDate { get; set; }

        [Required, Display(Name = "Metoda de transport")]
        public string DeliveryMethod { get; set; }

        [Required, Display(Name = "Cantitate")]
        [Range(0, 5000, ErrorMessage = "Introduceti o cantitate valida.")]
        public int Quantity { get; set; }
    }
}