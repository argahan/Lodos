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
    public class Kategori_1Controller : Controller
    {
        private lodos_DBEntities db = new lodos_DBEntities();

        // GET: Kategori_1
        public ActionResult Index()
        {
            return View(db.Kategori_1.ToList());
        }

        // GET: Kategori_1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori_1 kategori_1 = db.Kategori_1.Find(id);
            if (kategori_1 == null)
            {
                return HttpNotFound();
            }
            return View(kategori_1);
        }

        // GET: Kategori_1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategori_1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "K1Id,K1Ad")] Kategori_1 kategori_1)
        {
            if (ModelState.IsValid)
            {
                db.Kategori_1.Add(kategori_1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategori_1);
        }

        // GET: Kategori_1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori_1 kategori_1 = db.Kategori_1.Find(id);
            if (kategori_1 == null)
            {
                return HttpNotFound();
            }
            return View(kategori_1);
        }

        // POST: Kategori_1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "K1Id,K1Ad")] Kategori_1 kategori_1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategori_1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori_1);
        }

        // GET: Kategori_1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori_1 kategori_1 = db.Kategori_1.Find(id);
            if (kategori_1 == null)
            {
                return HttpNotFound();
            }
            return View(kategori_1);
        }

        // POST: Kategori_1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori_1 kategori_1 = db.Kategori_1.Find(id);
            db.Kategori_1.Remove(kategori_1);
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
