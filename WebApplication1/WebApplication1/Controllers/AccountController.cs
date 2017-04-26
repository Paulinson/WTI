using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.ComponentModel;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        BibliotekaEntities2 biblioDB = new BibliotekaEntities2();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Czytelnik czyt)
        {
            if(ModelState.IsValid)
            {
                var detailsUser = biblioDB.Czytelnik.Where(p => p.kod == czyt.kod).FirstOrDefault();
                if (detailsUser == null)
                {
                    biblioDB.Czytelnik.Add(czyt);
                    biblioDB.SaveChanges();
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Czytelnik czyt)
        {
            #region RemoveModelState
            ModelState.Remove("imie");
            ModelState.Remove("nazwisko");
            ModelState.Remove("email");
            ModelState.Remove("kod_pocztowy");
            ModelState.Remove("miasto");
            ModelState.Remove("ulica");
            ModelState.Remove("nr_domu");
            ModelState.Remove("nr_mieszkania");
            ModelState.Remove("wojewodztwo");
            #endregion
            if (ModelState.IsValid)
            {
                var details = biblioDB.Czytelnik.Where(a => a.kod.Equals(czyt.kod) && a.pesel.Equals(czyt.pesel)).FirstOrDefault();
                if(details != null)
                {
                    Session["id"] = details.id_czytelnik;
                    Session["imie"] = details.imie;
                    Session["nazwisko"] = details.nazwisko;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Niepoprawne dane!");
                }
            }
            return View();
        }
    }
}