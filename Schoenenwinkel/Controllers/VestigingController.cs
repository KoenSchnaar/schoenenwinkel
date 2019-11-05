using Schoenenwinkel.Models;
using Schoenenwinkel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schoenenwinkel.Controllers
{
    public class VestigingController : Controller
    {
        // GET: Vestiging
        VestigingVoorraadRepository VestigingVoorraadRepo = new VestigingVoorraadRepository();
        public ActionResult GetVoorraadVestiging(int productID, string fotoPath)
        {
            ViewBag.ProductInfo = productID;
            ViewBag.FotoInfo = fotoPath;
            return View(VestigingVoorraadRepo.GetVestigingVoorraad(productID));
        }

        public ActionResult UpdateVoorraadVestiging(int productID, int vestigingID)
        {
            var entity = VestigingVoorraadRepo.GetProductVestiging(productID, vestigingID);
            return View(entity);
        }

        [HttpPost]
        public ActionResult UpdateVoorraadVestiging(VestigingVoorraadModel VVModel, string FotoPath)
        {
            if (!ModelState.IsValid)
            {
                return View(VVModel);
            }
            VestigingVoorraadRepo.UpdateVoorraad(VVModel);
            return RedirectToAction("GetVoorraadVestiging", new { productID = VVModel.ProductID, fotoPath = FotoPath });
        }

    }
}