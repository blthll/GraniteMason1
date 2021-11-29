using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using GraniteMason.Models.Entity;

namespace GraniteMason.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCabinetMasonEntities db = new DbCabinetMasonEntities();
        // GET: Default
        public PartialViewResult Navbar()
        {
            return PartialView();
        }
        public PartialViewResult HomeAbout()
        {
            var hakkinda = db.TblHomes.ToList();
            return PartialView(hakkinda);
        }
        public PartialViewResult GalleryCategory()
        {
            var category = db.TblCategories.ToList();
            return PartialView(category);
        }
        public PartialViewResult Footer()
        {
            return PartialView();
        }
        public ActionResult Index()
        {
            var degerler = db.TblHomeGalleries.ToList();
            return View(degerler);
        }
        public ActionResult About()
        {
            var hakkinda = db.TblAbouts.ToList();
            return View(hakkinda);
        }
        public ActionResult Cabinets()
        {
            var cabinets = db.TblCabinetsGalleries.ToList();
            return View(cabinets);
        }
        public ActionResult Gallery()
        {
            var gallery = db.TblGalleryPhotoes.ToList();
            return View(gallery);
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult mailgonderme()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult mailgonderme(TblContact p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContacts.Add(p);
            db.SaveChanges();
            MailMessage mailim = new MailMessage();
            mailim.To.Add("halilbolat.hb@gmail.com");
            mailim.From = new MailAddress("halilbolat.hb@gmail.com");
            mailim.Subject = "Cabinet Mason Webmail ";
            mailim.Body = "Dear website owner,<br>" + p.Isim + " sent you a message. <br>Email: "+p.Email+ "<br>Phone: "+p.Telefon + "<br>Date: " + p.Tarih+"<br>Message:" + p.Aciklama;
            mailim.IsBodyHtml = true;      
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("halilbolat.hb@gmail.com", "Ka355map"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mailim);
            return PartialView();
        }
    }
}