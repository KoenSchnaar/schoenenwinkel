using Schoenenwinkel.Models;
using Schoenenwinkel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSchoenenwinkel.FakeRepositories
{
    class FakeVestigingVoorraadRepo : IVestigingVoorraadRepository
    {
        public void AddVoorraadVestiging(int productID)
        {
            throw new NotImplementedException();
        }

        public void DeleteVoorraadVestiging(int productID)
        {
            throw new NotImplementedException();
        }

        public VestigingVoorraadModel GetProductVestiging(int productID, int vestigingID)
        {
            throw new NotImplementedException();
        }

        public List<VestigingVoorraadModel> GetVestigingVoorraad(int productID)
        {
            return new List<VestigingVoorraadModel>
            {
                new VestigingVoorraadModel
                {
                    ProductID = productID,
                    Vestiging = "testVestiging",
                    VestigingID = 1
                }
            };
        }

        public void UpdateTotaalVoorraad(VestigingVoorraadModel model, int beginVoorraad, int productID)
        {
            throw new NotImplementedException();
        }

        public void UpdateVoorraad(List<VestigingVoorraadModel> model, int productID)
        {
        }
    }
}
