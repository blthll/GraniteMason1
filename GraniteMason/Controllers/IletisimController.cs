using GraniteMason.Models.Entity;
using GraniteMason.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GraniteMason.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Deneyim
        IletisimRepository repo = new IletisimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
    }
}