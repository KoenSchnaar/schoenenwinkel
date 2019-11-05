using EntityFrameworkDB;
using Schoenenwinkel.Converter;
using Schoenenwinkel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoenenwinkel.Repositories
{
    public class VestigingVoorraadRepository
    {
        private SneakerWinkelEntities context = new SneakerWinkelEntities();
        private ConvertVoorraadVestiging converteerder = new ConvertVoorraadVestiging();

        public List<VestigingVoorraadModel> GetVestigingVoorraad( int productID)
        {
            return context.ProductVestigingVoorraads
                .Where(p => p.Product_ID == productID)
                .Select(p => new VestigingVoorraadModel { ProductID = p.Product_ID, 
                    VestigingID = p.Vestiging_ID, 
                    Product = p.Product.Merk +" " + p.Product.Model +" "+ p.Product.Naam, 
                    FotoPath = p.Product.Foto, Locatie = p.Vestiging.Locatie, 
                    Vestiging = p.Vestiging.Naam, 
                    Voorraad = p.Vestigingvoorraad.Value})
                .ToList();
        }

        public VestigingVoorraadModel GetProductVestiging(int productID, int vestigingID)
        {
            var entity = context.ProductVestigingVoorraads.Single(p => p.Product_ID == productID && p.Vestiging_ID == vestigingID);
            return converteerder.Converteer(entity);
        }

        public void UpdateVoorraad(VestigingVoorraadModel model)
        {
            var entity = context.ProductVestigingVoorraads.Single(p => p.Product_ID == model.ProductID && p.Vestiging_ID == model.VestigingID);
            int beginVoorraad = entity.Vestigingvoorraad.HasValue ? entity.Vestigingvoorraad.Value : 0 ;
            entity.Vestigingvoorraad = model.Voorraad;
            UpdateTotaalVoorraad(model, beginVoorraad);
            context.SaveChanges();
        }

        public void UpdateTotaalVoorraad(VestigingVoorraadModel model, int beginVoorraad)
        {
            int verschilVoorraad = model.Voorraad - beginVoorraad;
            var entity = context.Products.Single(p => p.Product_ID == model.ProductID);
            entity.Voorraad += verschilVoorraad;
            context.SaveChanges();
        }
    }
}