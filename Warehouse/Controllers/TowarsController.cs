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
using PagedList;

namespace Warehouse.Controllers
{
    public class TowarsController : Controller
    {
        private MagazynContext db = new MagazynContext();

        // GET: Towars
        public ActionResult Index(string sortOrder, string searchString, int? page)
        {
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.NrSortParm = sortOrder == "Nr" ? "nr_desc" : "Nr";
            var towars = from t in db.Towar
                         select t;
            if(!String.IsNullOrEmpty(searchString))
            {
                towars = towars.Where(s => s.Nazwa.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "name_desc":
                    towars = towars.OrderByDescending(t => t.Nazwa);
                    break;
                case "Name":
                    towars = towars.OrderBy(t => t.Nazwa);
                    break;
                case "Nr":
                    towars = towars.OrderBy(t => t.TowarId);
                    break;
                case "nr_desc":
                    towars = towars.OrderByDescending(t => t.TowarId);
                    break;

            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(towars.ToList());
        }

        // GET: Towars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towar.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // GET: Towars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Towars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TowarId,Nazwa,NrSerijny,Wymiary,Producent")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                db.Towar.Add(towar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(towar);
        }

        // GET: Towars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towar.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // POST: Towars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TowarId,Nazwa,NrSerijny,Wymiary,Producent")] Towar towar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(towar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(towar);
        }

        // GET: Towars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towar towar = db.Towar.Find(id);
            if (towar == null)
            {
                return HttpNotFound();
            }
            return View(towar);
        }

        // POST: Towars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Towar towar = db.Towar.Find(id);
            db.Towar.Remove(towar);
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
