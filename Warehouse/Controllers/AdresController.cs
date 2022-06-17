using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Warehouse.DAL;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class AdresController : Controller
    {
        private MagazynContext db = new MagazynContext();

        // GET: Adres
        public ActionResult Index()
        {
            return View(db.Adres.ToList());
        }

        // GET: Adres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdresId,Ulica,NrBudynku,KodPocztowy,Miasto,Kraj")] Adres adres)
        {
            if (ModelState.IsValid)
            {
                db.Adres.Add(adres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adres);
        }

        // GET: Adres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adres adres = db.Adres.Find(id);
            if (adres == null)
            {
                return HttpNotFound();
            }
            return View(adres);
        }

        // POST: Adres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdresId,Ulica,NrBudynku,KodPocztowy,Miasto,Kraj")] Adres adres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adres);
        }

        // GET: Adres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adres adres = db.Adres.Find(id);
            if (adres == null)
            {
                return HttpNotFound();
            }
            return View(adres);
        }

        // POST: Adres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adres adres = db.Adres.Find(id);
            db.Adres.Remove(adres);
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
