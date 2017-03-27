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
    public class KampanyaController : Controller
    {
        private lodos_DBEntities db = new lodos_DBEntities();

        // GET: Kampanya
        public ActionResult Index()
        {
            var kampanya = db.Kampanya.Include(k => k.Firma).Include(k => k.Kategori_2);
            return View(kampanya.ToList());
        }

        // GET: Kampanya/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanya.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            return View(kampanya);
        }

        // GET: Kampanya/Create
        public ActionResult Create()
        {
            ViewBag.FId = new SelectList(db.Firma, "FId", "FAdi");
            ViewBag.K2Id = new SelectList(db.Kategori_2, "K2Id", "K2Ad");
            return View();
        }

        // POST: Kampanya/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KId,K2Id,FId,Ad,Aciklama,Eski_Fiyat,Yeni_Fiyat,resim")] Kampanya kampanya)
        {
            if (ModelState.IsValid)
            {
                db.Kampanya.Add(kampanya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FId = new SelectList(db.Firma, "FId", "FAdi", kampanya.FId);
            ViewBag.K2Id = new SelectList(db.Kategori_2, "K2Id", "K2Ad", kampanya.K2Id);
            return View(kampanya);
        }

        // GET: Kampanya/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanya.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            ViewBag.FId = new SelectList(db.Firma, "FId", "FAdi", kampanya.FId);
            ViewBag.K2Id = new SelectList(db.Kategori_2, "K2Id", "K2Ad", kampanya.K2Id);
            return View(kampanya);
        }

        // POST: Kampanya/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KId,K2Id,FId,Ad,Aciklama,Eski_Fiyat,Yeni_Fiyat,resim")] Kampanya kampanya)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kampanya).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FId = new SelectList(db.Firma, "FId", "FAdi", kampanya.FId);
            ViewBag.K2Id = new SelectList(db.Kategori_2, "K2Id", "K2Ad", kampanya.K2Id);
            return View(kampanya);
        }

        // GET: Kampanya/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanya.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            return View(kampanya);
        }

        // POST: Kampanya/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kampanya kampanya = db.Kampanya.Find(id);
            db.Kampanya.Remove(kampanya);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
