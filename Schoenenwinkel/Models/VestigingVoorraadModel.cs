using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schoenenwinkel.Models
{
    public class VestigingVoorraadModel
    {
        public int ProductID { get; set; }
        public int VestigingID { get; set; }
        public string Vestiging { get; set; }
        public string Locatie { get; set; }
        public string Product { get; set; }
        [Required (ErrorMessage ="Dit veld mag niet leeg zijn.")]
        [Range (0.0, int.MaxValue, ErrorMessage ="Vul een getal hoger dan 0 in.")]
        public int Voorraad { get; set; }
        public string FotoPath { get; set; }
    }
}