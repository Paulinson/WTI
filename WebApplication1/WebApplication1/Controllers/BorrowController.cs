using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BorrowController : Controller
    {
        BibliotekaEntities2 biblioDB = new BibliotekaEntities2();
        // GET: Borrow
        public ActionResult Index()
        {
            return View();
        }

 
        public ActionResult Czytelnicy()
        {
            return View(biblioDB.Czytelnik.ToList());
        }

        public ActionResult Wypozyczenie(Czytelnik czyt, Wypozyczenia wyp)
        { 
            return View();
        }
        public ActionResult GetKsiazki()
        {                                        
          return View(biblioDB.AutorzyKsiazki.ToList());
        }
    }
}