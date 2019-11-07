using System.Collections.Generic;
using Schoenenwinkel.Models;

namespace Schoenenwinkel.Repositories
{
    public interface IProductRepository
    {
        ProductModel AddProduct(ProductModel productModel);
        void DeleteProduct(int productID);
        List<ProductModel> GetAllProducts();
        ProductModel GetOneProduct(int productID);
        void UpdateProduct(ProductModel model);
    }
}