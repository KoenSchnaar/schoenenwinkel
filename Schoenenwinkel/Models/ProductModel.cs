using Schoenenwinkel.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schoenenwinkel.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "vul iets in")]
        [StringLength (30, ErrorMessage = "Gebruik minder dan 30 karakters.")]
        public string Merk { get; set; }

        [Required(ErrorMessage = "vul iets in")]
        [StringLength(30, ErrorMessage = "Gebruik minder dan 30 karakters.")]
        public string Model { get; set; }
        public string Naam { get; set; }
        public int Voorraad { get; set; }
        public int Gewicht { get; set; }
        public string FotoPath { get; set; }   

    }
}