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
    public class Kategori_2Controller : Controller
    {
        private lodos_DBEntities db = new lodos_DBEntities();

        // GET: Kategori_2
        public ActionResult Index()
        {
            var kategori_2 = db.Kategori_2.Include(k => k.Kategori_1);
            return View(kategori_2.ToList());
        }

        // GET: Kategori_2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori_2 kategori_2 = db.Kategori_2.Find(id);
            if (kategori_2 == null)
            {
                return HttpNotFound();
            }
            return View(kategori_2);
        }

        // GET: Kategori_2/Create
        public ActionResult Create()
        {
            ViewBag.K1Id = new SelectList(db.Kategori_1, "K1Id", "K1Ad");
            return View();
        }

        // POST: Kategori_2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "K1Id,K2Id,K2Ad")] Kategori_2 kategori_2)
        {
            if (ModelState.IsValid)
            {
                db.Kategori_2.Add(kategori_2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.K1Id = new SelectList(db.Kategori_1, "K1Id", "K1Ad", kategori_2.K1Id);
            return View(kategori_2);
        }

        // GET: Kategori_2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori_2 kategori_2 = db.Kategori_2.Find(id);
            if (kategori_2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.K1Id = new SelectList(db.Kategori_1, "K1Id", "K1Ad", kategori_2.K1Id);
            return View(kategori_2);
        }

        // POST: Kategori_2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "K1Id,K2Id,K2Ad")] Kategori_2 kategori_2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategori_2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.K1Id = new SelectList(db.Kategori_1, "K1Id", "K1Ad", kategori_2.K1Id);
            return View(kategori_2);
        }

        // GET: Kategori_2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori_2 kategori_2 = db.Kategori_2.Find(id);
            if (kategori_2 == null)
            {
                return HttpNotFound();
            }
            return View(kategori_2);
        }

        // POST: Kategori_2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori_2 kategori_2 = db.Kategori_2.Find(id);
            db.Kategori_2.Remove(kategori_2);
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
