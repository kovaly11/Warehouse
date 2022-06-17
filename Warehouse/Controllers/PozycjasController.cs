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
    public class PozycjasController : Controller
    {
        private MagazynContext db = new MagazynContext();

        // GET: Pozycjas
        public ActionResult Index()
        {
            var pozycja = db.Pozycja.Include(p => p.Dokument).Include(p => p.Towar);
            return View(pozycja.ToList());
        }

        // GET: Pozycjas/Create
        public ActionResult Create()
        {
            ViewBag.TowarId = new SelectList(db.Towar, "TowarId", "Nazwa");
            return View();
        }

        // POST: Pozycjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DokumentId,NrPozycji,TowarId,Ilosc")] Pozycja pozycja)
        {
            if (ModelState.IsValid)
            {
                db.Pozycja.Add(pozycja);
                db.SaveChanges();
                return RedirectToAction($"../Dokuments/Details/{pozycja.DokumentId}");
            }
            ViewBag.TowarId = new SelectList(db.Towar, "TowarId", "Nazwa", pozycja.TowarId);
            return View(pozycja);
        }

        // GET: Pozycjas/Edit/5
        public ActionResult Edit(int? id, int? nr)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozycja pozycja = db.Pozycja.Find(id, nr);
            if (pozycja == null)
            {
                return HttpNotFound();
            }
            ViewBag.DokumentId = new SelectList(db.Dokument, "DokumentId", "Typ", pozycja.DokumentId);
            ViewBag.TowarId = new SelectList(db.Towar, "TowarId", "Nazwa", pozycja.TowarId);
            return View(pozycja);
        }

        // POST: Pozycjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DokumentId,NrPozycji,TowarId,Ilosc")] Pozycja pozycja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pozycja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction($"../Dokuments/Details/{pozycja.DokumentId}");
            }
            ViewBag.DokumentId = new SelectList(db.Dokument, "DokumentId", "Typ", pozycja.DokumentId);
            ViewBag.TowarId = new SelectList(db.Towar, "TowarId", "Nazwa", pozycja.TowarId);
            return View(pozycja);
        }

        // GET: Pozycjas/Delete/5
        public ActionResult Delete(int? id, int? nr)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pozycja pozycja = db.Pozycja.Find(id, nr);
            if (pozycja == null)
            {
                return HttpNotFound();
            }
            return View(pozycja);
        }

        // POST: Pozycjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int nr)
        {
            Pozycja pozycja = db.Pozycja.Find(id, nr);
            db.Pozycja.Remove(pozycja);
            db.SaveChanges();
            return RedirectToAction($"../Dokuments/Details/{id}");
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
