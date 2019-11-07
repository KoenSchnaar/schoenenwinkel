using Schoenenwinkel.Models;
using Schoenenwinkel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSchoenenwinkel.FakeRepositories
{
    public class FakeProductRepo : IProductRepository
    {
        public ProductModel AddProduct(ProductModel productModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProducts()
        {
            return new List<ProductModel>
            {
                new ProductModel
                {
                    FotoPath = "testfotopath",
                    Gewicht = 200,
                    Merk = "testMerk",
                    Model = "testModel",
                    Naam = "testNaam",
                    ProductID = 1,
                    Voorraad = 10
                }

            };
        }

        public ProductModel GetOneProduct(int productID)
        {
            return new ProductModel
            {
                ProductID = 1,
                Merk = "testMerk",
                Model = "testModel",
                Naam = "testNaam"
            };
        }

        public void UpdateProduct(ProductModel model)
        {
            
        }
    }
}
