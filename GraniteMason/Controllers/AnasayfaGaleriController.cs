using GraniteMason.Models.Entity;
using GraniteMason.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GraniteMason.Controllers
{
    public class AnasayfaGaleriController : Controller
    {
        // GET: Deneyim
        AnasayfaGaleriRepository repo = new AnasayfaGaleriRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AnasayfaGaleriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AnasayfaGaleriEkle(TblHomeGallery p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AnasayfaGaleriSil(int id)
        {
            TblHomeGallery t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AnasayfaGaleriGetir(int id)
        {
            TblHomeGallery t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AnasayfaGaleriGetir(TblHomeGallery p)
        {
            TblHomeGallery t = repo.Find(x => x.ID == p.ID);
            t.GaleriResim = p.GaleriResim;
            t.GaleriBaslik = p.GaleriBaslik;
            t.GaleriAltBaslik = p.GaleriAltBaslik;
            t.GaleriAciklama = p.GaleriAciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}