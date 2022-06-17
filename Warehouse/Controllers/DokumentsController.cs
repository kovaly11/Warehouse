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
    public class DokumentsController : Controller
    {
        private MagazynContext db = new MagazynContext();

        // GET: Dokuments
        public ActionResult Index()
        {
            var dokument = db.Dokument.Include(d => d.Firma).Include(d => d.Pracownik);
            return View(dokument.ToList());
        }

        // GET: Dokuments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokument.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            return View(dokument);
        }

        // GET: Dokuments/Create
        public ActionResult Create()
        {
            ViewBag.FirmaId = new SelectList(db.Firma, "FirmaId", "Nazwa");
            ViewBag.PracownikId = new SelectList(db.Pracownik, "PracownikId", "Imie");
            return View();
        }

        // POST: Dokuments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DokumentId,PracownikId,FirmaId,DokumentDate,Typ")] Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                db.Dokument.Add(dokument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirmaId = new SelectList(db.Firma, "FirmaId", "Nazwa", dokument.FirmaId);
            ViewBag.PracownikId = new SelectList(db.Pracownik, "PracownikId", "Imie", dokument.PracownikId);
            return View(dokument);
        }

        // GET: Dokuments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokument.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirmaId = new SelectList(db.Firma, "FirmaId", "Nazwa", dokument.FirmaId);
            ViewBag.PracownikId = new SelectList(db.Pracownik, "PracownikId", "Imie", dokument.PracownikId);
            return View(dokument);
        }

        // POST: Dokuments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DokumentId,PracownikId,FirmaId,DokumentDate,Typ")] Dokument dokument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dokument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirmaId = new SelectList(db.Firma, "FirmaId", "Nazwa", dokument.FirmaId);
            ViewBag.PracownikId = new SelectList(db.Pracownik, "PracownikId", "Imie", dokument.PracownikId);
            return View(dokument);
        }

        // GET: Dokuments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dokument dokument = db.Dokument.Find(id);
            if (dokument == null)
            {
                return HttpNotFound();
            }
            return View(dokument);
        }

        // POST: Dokuments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dokument dokument = db.Dokument.Find(id);
            db.Dokument.Remove(dokument);
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
