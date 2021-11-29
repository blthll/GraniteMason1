using GraniteMason.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GraniteMason.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p )
        {
            DbCabinetMasonEntities db = new DbCabinetMasonEntities();
            var bilgi = db.TblAdmins.FirstOrDefault(
                x=> x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
                if(bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Galeri");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}