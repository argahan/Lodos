using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lodos.Models;

namespace Lodos.Controllers
{
    public class KategoriController : Controller
    {
        private lodos_DBEntities db = new lodos_DBEntities();
       

        public ActionResult Kategori()
        {
            var ktgr = db.Kategori_1;
            return View(ktgr.ToList());
        }
        public ActionResult Moda()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());
        }
        public ActionResult Elektronik()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());
        }
        public ActionResult Ev_Bahce_Ofis()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());

        }
        public ActionResult Hobi_Eglence()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());
        }
        public ActionResult Kirtasiye()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());
        }
        public ActionResult Kitap_Film_Muzik()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());
        }
        public ActionResult Kozmetik()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());
        }
        public ActionResult Otomobil_Motosiklet()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());
        }
        public ActionResult Spor_Outdoor()
        {
            var ktgr = db.Kategori_2;
            return View(ktgr.ToList());
        }
        public ActionResult Supermarket()
        {
            var ktgr = db.Kategori_2;
            
            return View(ktgr.ToList());
        }
        public ActionResult Detail( int? id)
        {
            
            var kampanya = db.Kampanya.Include(k => k.Firma).Include(k => k.Kategori_2);
            
            return View(kampanya.ToList());
        }
        public ActionResult Detail2()
        {
            var kampanya = db.Kampanya.Include(k => k.Firma).Include(k => k.Kategori_2);
            return View(kampanya.ToList());
        }

    }

}