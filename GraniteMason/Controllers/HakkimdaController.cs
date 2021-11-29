using GraniteMason.Models.Entity;
using GraniteMason.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraniteMason.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Deneyim
        HakkimdaRepository repo = new HakkimdaRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult HakkimdaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HakkimdaEkle(TblAbout p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult HakkimdaSil(int id)
        {
            TblAbout t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HakkimdaGetir(int id)
        {
            TblAbout t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult HakkimdaGetir(TblAbout p)
        {
            TblAbout t = repo.Find(x => x.ID == p.ID);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            t.Resim1 = p.Resim1;
            t.Resim2 = p.Resim2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}