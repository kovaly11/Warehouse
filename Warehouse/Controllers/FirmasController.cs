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
    public class FirmasController : Controller
    {
        private MagazynContext db = new MagazynContext();

        // GET: Firmas
        public ActionResult Index()
        {
            var firma = db.Firma.Include(f => f.Adres);
            return View(firma.ToList());
        }

        // GET: Firmas/Details/5
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

        // GET: Firmas/Create
        public ActionResult Create()
        {
            ViewBag.AdresId = new SelectList(db.Adres, "AdresId", "Ulica");
            return View();
        }

        // POST: Firmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirmaId,Nazwa,NIP,OsobaKontaktowa,Telefon,StonaInternetowa,AdresId")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                db.Firma.Add(firma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdresId = new SelectList(db.Adres, "AdresId", "Ulica", firma.AdresId);
            return View(firma);
        }

        // GET: Firmas/Edit/5
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
            ViewBag.AdresId = new SelectList(db.Adres, "AdresId", "Ulica", firma.AdresId);
            return View(firma);
        }

        // POST: Firmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirmaId,Nazwa,NIP,OsobaKontaktowa,Telefon,StonaInternetowa,AdresId")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdresId = new SelectList(db.Adres, "AdresId", "Ulica", firma.AdresId);
            return View(firma);
        }

        // GET: Firmas/Delete/5
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

        // POST: Firmas/Delete/5
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
