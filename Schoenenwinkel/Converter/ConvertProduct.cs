using EntityFrameworkDB;
using Schoenenwinkel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoenenwinkel.Repositories
{
    public class ConvertProduct
    {
        public ProductModel Converteer(Product entity)
        {
            return new ProductModel
            {
                ProductID = entity.Product_ID,
                Merk = entity.Merk,
                Model = entity.Model,
                Naam = entity.Naam,
                Voorraad = entity.Voorraad.HasValue ? entity.Voorraad.Value : 0,
                Gewicht = entity.Gewicht.HasValue ? entity.Gewicht.Value : 0,
                FotoPath = entity.Foto
            };
        }
    }
}