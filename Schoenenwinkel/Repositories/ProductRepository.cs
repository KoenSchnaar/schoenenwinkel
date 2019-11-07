using EntityFrameworkDB;
using Schoenenwinkel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schoenenwinkel.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private SneakerWinkelEntities context = new SneakerWinkelEntities();
        private ConvertProduct converteerder = new ConvertProduct();


        public List<ProductModel> GetAllProducts()
        {
            return context.Products.ToList().Select(p => converteerder.Converteer(p))
                .ToList();
        }

        public ProductModel GetOneProduct(int productID)
        {
            var entity = context.Products.Single(p => p.Product_ID == productID);
            return converteerder.Converteer(entity);

        }

        public void UpdateProduct(ProductModel model)
        {
            var entity = context.Products.Single(p => p.Product_ID == model.ProductID);
            entity.Merk = model.Merk;
            entity.Model = model.Model;
            entity.Naam = model.Naam;
            entity.Voorraad = model.Voorraad;
            entity.Gewicht = model.Gewicht;
            entity.Foto = model.FotoPath;
            context.SaveChanges();
        }

        public ProductModel AddProduct(ProductModel productModel)
        {
            var newProduct = new Product
            {
                Merk = productModel.Merk,
                Model = productModel.Model
            };
            context.Products.Add(newProduct);
            context.SaveChanges();

            productModel.ProductID = newProduct.Product_ID;
            return productModel;
        }

        public void DeleteProduct(int productID)
        {
            var entity = context.Products.Single(p => p.Product_ID == productID);
            context.Products.Remove(entity);
            context.SaveChanges();
        }
    }
}