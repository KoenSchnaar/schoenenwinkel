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
        IVestigingVoorraadRepository VestigingVoorraadRepo;

        public VestigingController(IVestigingVoorraadRepository VestigingVoorraadRepo)
        {
            this.VestigingVoorraadRepo = VestigingVoorraadRepo;
        }

        // GET: Vestiging
        public ActionResult GetVoorraadVestiging(int productID, string fotoPath)
        {
            ViewBag.ProductInfo = productID;
            ViewBag.FotoInfo = fotoPath;
            return View(VestigingVoorraadRepo.GetVestigingVoorraad(productID));
        }

        [HttpPost]
        public ActionResult GetVoorraadVestiging(List<VestigingVoorraadModel> VVModel, string FotoPath, int productID2)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.FotoInfo = FotoPath;
                return View(VestigingVoorraadRepo.GetVestigingVoorraad(productID2));
            }
            VestigingVoorraadRepo.UpdateVoorraad(VVModel, productID2);
            return RedirectToAction("GetVoorraadVestiging", new { productID = productID2, fotoPath = FotoPath });
        }

    }
}