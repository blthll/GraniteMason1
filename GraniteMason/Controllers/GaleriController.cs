using GraniteMason.Models.Entity;
using GraniteMason.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GraniteMason.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        GaleriResimRepository repo = new GaleriResimRepository();
        DbCabinetMasonEntities db = new DbCabinetMasonEntities();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult GaleriEkle()
        {
            List<SelectListItem> listItems = db.TblCategories.
                     Select(i => new SelectListItem { Text = i.Kategori, Value = i.Kategori.ToString() }).ToList();
            ViewBag.dgr = listItems;
            return View();
        }
        [HttpPost]
        public ActionResult GaleriEkle(TblGalleryPhoto p)
        {
            var ktg = db.TblCategories.Where(m => m.Kategori == p.GaleriKategori).FirstOrDefault();
            p.GaleriKategori = ktg.Kategori;
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult GaleriSil(int id)
        {
            TblGalleryPhoto t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GaleriGetir(int id)
        {
            TblGalleryPhoto t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GaleriGetir(TblGalleryPhoto p)
        {
            TblGalleryPhoto t = repo.Find(x => x.ID == p.ID);
            t.GaleriResim = p.GaleriResim;
            t.GaleriKategori = p.GaleriKategori;
            t.GaleriAciklama = p.GaleriAciklama;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}