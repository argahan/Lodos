﻿using System;
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
    public class FirmaController : Controller
    {
        private lodos_DBEntities db = new lodos_DBEntities();

        // GET: Firma
        public ActionResult Index()
        {
            return View(db.Firma.ToList());
        }

        // GET: Firma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = db.Firma.Find(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // GET: Firma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Firma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FId,FAdi")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                db.Firma.Add(firma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firma);
        }

        // GET: Firma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = db.Firma.Find(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // POST: Firma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FId,FAdi")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firma);
        }

        // GET: Firma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firma firma = db.Firma.Find(id);
            if (firma == null)
            {
                return HttpNotFound();
            }
            return View(firma);
        }

        // POST: Firma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firma firma = db.Firma.Find(id);
            db.Firma.Remove(firma);
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
