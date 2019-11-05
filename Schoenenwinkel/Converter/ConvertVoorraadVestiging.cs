using EntityFrameworkDB;
using Schoenenwinkel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoenenwinkel.Converter
{
    public class ConvertVoorraadVestiging
    {
        public VestigingVoorraadModel Converteer(ProductVestigingVoorraad entity)
        {
            return new VestigingVoorraadModel
            {
                VestigingID = entity.Vestiging_ID,
                Vestiging = entity.Vestiging.Naam,
                Locatie = entity.Vestiging.Locatie,
                Product = entity.Product.Merk + " " + entity.Product.Model + " " + entity.Product.Naam,
                Voorraad = entity.Vestigingvoorraad.HasValue ? entity.Vestigingvoorraad.Value : 0,
                FotoPath = entity.Product.Foto
            };
        }
    }
}