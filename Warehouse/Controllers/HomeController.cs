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
    public class HomeController : Controller
    {
        private MagazynContext db = new MagazynContext();
        public ActionResult Start()
        {
            return View();
        }
        public ActionResult Index(string sortOrder)
        {
            //var pozyc = new List<Pozycja>() ;
            var pozycja = from t in db.Pozycja
                         select t;
            var pozyc = db.Pozycja.Include(p => p.Dokument).Include(p => p.Towar).ToList();
            
    
            var ilosc = new Dictionary<int, int>();

            foreach (var p in pozycja)
            {
                ilosc[p.TowarId] = 0;
            }
            foreach (var p in pozycja)
            {
                ilosc[p.TowarId] += p.Ilosc * p.Dokument.GetZnak();
            }
            foreach(var il in ilosc)
            {
                int num =1;
                pozyc.Add(new Pozycja { DokumentId = 0, NrPozycji = num, TowarId = il.Key, Ilosc = il.Value });
                num++;
            }


            return View(pozyc);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}