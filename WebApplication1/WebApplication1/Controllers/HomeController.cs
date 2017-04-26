using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        BibliotekaEntities2 biblioDb = new BibliotekaEntities2();
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Search(string k)
        {
            var ksiazki = from i in biblioDb.Ksiazki
                          select i;

            if(!String.IsNullOrEmpty(k))
            {
                ksiazki = from i in biblioDb.Ksiazki
                          where i.nazwa.Contains(k)
                          select i;
            }

            return View(ksiazki.ToList());
        }
    }
}