using GraniteMason.Models.Entity;
using GraniteMason.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GraniteMason.Controllers
{
    public class CabinetController : Controller
    {
        // GET: Deneyim
        CabinetRepository repo = new CabinetRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CabinetEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CabinetEkle(TblCabinetsGallery p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult CabinetSil(int id)
        {
            TblCabinetsGallery t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CabinetGetir(int id)
        {
            TblCabinetsGallery t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult CabinetGetir(TblCabinetsGallery p)
        {
            TblCabinetsGallery t = repo.Find(x => x.ID == p.ID);
            t.GaleriResim = p.GaleriResim;
            t.GaleriBaslik = p.GaleriBaslik;
            t.GaleriFiyat = p.GaleriFiyat;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}