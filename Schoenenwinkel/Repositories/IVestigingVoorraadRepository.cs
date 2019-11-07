using System.Collections.Generic;
using Schoenenwinkel.Models;

namespace Schoenenwinkel.Repositories
{
    public interface IVestigingVoorraadRepository
    {
        void AddVoorraadVestiging(int productID);
        void DeleteVoorraadVestiging(int productID);
        VestigingVoorraadModel GetProductVestiging(int productID, int vestigingID);
        List<VestigingVoorraadModel> GetVestigingVoorraad(int productID);
        void UpdateTotaalVoorraad(VestigingVoorraadModel model, int beginVoorraad, int productID);
        void UpdateVoorraad(List<VestigingVoorraadModel> model, int productID);
    }
}