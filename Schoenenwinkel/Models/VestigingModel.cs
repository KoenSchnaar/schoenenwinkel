using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoenenwinkel.Models
{
    public class VestigingModel
    {
        public int VestigingID { get; set; }
        public string Locatie { get; set; }
        public string Naam { get; set; }
        public string Telefoon { get; set; }
        public int Personeelsleden { get; set; }
    }
}