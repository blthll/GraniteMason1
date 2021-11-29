using GraniteMason.Models.Entity;
using GraniteMason.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GraniteMason.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Deneyim
        GaleriCategoryRepository repo = new GaleriCategoryRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CategoryEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryEkle(TblCategory p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult CategorySil(int id)
        {
            TblCategory t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CategoryGetir(int id)
        {
            TblCategory t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult CategoryGetir(TblCategory p)
        {
            TblCategory t = repo.Find(x => x.ID == p.ID);
            t.Kategori = p.Kategori;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}