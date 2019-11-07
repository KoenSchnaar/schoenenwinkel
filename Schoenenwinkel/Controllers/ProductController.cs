using Schoenenwinkel.Models;
using Schoenenwinkel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schoenenwinkel.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository ProductRepo;
        private VestigingVoorraadRepository VestigingVoorraadRepo = new VestigingVoorraadRepository();

        public ProductController(IProductRepository productRepo)
        {
            this.ProductRepo = productRepo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Producten()
        {
            ViewBag.Message = "Zie hier alle producten";

            return View(ProductRepo.GetAllProducts());
        }

        public ActionResult Add()
        {
            return View(new ProductModel());
        }


        [HttpPost]
        public ActionResult Add(ProductModel productModel)
        {
            if (!ModelState.IsValid)
                return (View(productModel));
            var newProduct = ProductRepo.AddProduct(productModel);
            VestigingVoorraadRepo.AddVoorraadVestiging(newProduct.ProductID);
            return RedirectToAction("Producten");
        }

        public ActionResult Update(int ProductID)
        {
            var productModel = ProductRepo.GetOneProduct(ProductID);
            return View(productModel);
        }

        [HttpPost]
        public ActionResult Update(ProductModel productModel)
        {
            if (!ModelState.IsValid)
                return View(productModel);
            ProductRepo.UpdateProduct(productModel);
            return RedirectToAction("Producten");
        }

        public ActionResult Delete(int productID)
        {
            VestigingVoorraadRepo.DeleteVoorraadVestiging(productID);
            ProductRepo.DeleteProduct(productID);
            return RedirectToAction("Producten");
        }
    }
}