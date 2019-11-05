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
                .Where(p => p.Product_ID == productID).ToList()
                .Select(p => converteerder.Converteer(p))
                .ToList();
        }

        public VestigingVoorraadModel GetProductVestiging(int productID, int vestigingID)
        {
            var entity = context.ProductVestigingVoorraads.Single(p => p.Product_ID == productID && p.Vestiging_ID == vestigingID);
            return converteerder.Converteer(entity);
        }

        public void UpdateVoorraad(List<VestigingVoorraadModel> model, int productID)
        {
            foreach (var modelItem in model)
            {
                var entity = context.ProductVestigingVoorraads.Single(p => p.Product_ID == productID && p.Vestiging_ID == modelItem.VestigingID);
                int beginVoorraad = entity.Vestigingvoorraad.HasValue ? entity.Vestigingvoorraad.Value : 0;
                entity.Vestigingvoorraad = modelItem.Voorraad;
                UpdateTotaalVoorraad(modelItem, beginVoorraad, productID);
                context.SaveChanges();
            }
        }

        public void UpdateTotaalVoorraad(VestigingVoorraadModel model, int beginVoorraad, int productID)
        {
            int verschilVoorraad = model.Voorraad - beginVoorraad;
            var entity = context.Products.Single(p => p.Product_ID == productID);
            entity.Voorraad += verschilVoorraad;
            context.SaveChanges();
        }

        public void AddVoorraadVestiging(int productID)
        {
            var vestigingen = context.Vestigings.ToList();

            foreach(var vestiging in vestigingen)
            {
            context.ProductVestigingVoorraads.Add(new ProductVestigingVoorraad
            {
                Product_ID = productID,
                Vestiging_ID = vestiging.Vestiging_ID,
                Vestigingvoorraad = 0
            });
            context.SaveChanges();
            }
        }

        public void DeleteVoorraadVestiging(int productID)
        {
            var vestigingen = context.ProductVestigingVoorraads.Where(v => productID == v.Product_ID).ToList();

            foreach(var vestiging in vestigingen)
            {
                context.ProductVestigingVoorraads.Remove(vestiging);
            }
            context.SaveChanges();
        }
    }
}