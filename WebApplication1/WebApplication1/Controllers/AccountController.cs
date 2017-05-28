﻿using System;
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
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult LoginPrac(Pracownicy prac)
        {
            #region RemoveModelState
            ModelState.Remove("imie");
            ModelState.Remove("nazwisko");
            ModelState.Remove("profesja");
            ModelState.Remove("id_biblio");

            #endregion
            if (ModelState.IsValid)
            {
                var details = biblioDB.Pracownicy.Where(a => a.nick.Equals(prac.nick) && a.haslo.Equals(prac.haslo)).FirstOrDefault();
                if (details != null)
                {
                    Session["idPrac"] = details.id_pracownik;
                    Session["imie"] = details.imie;
                    Session["nazwisko"] = details.nazwisko;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult kontoCzytelnika(int id)
        {
           // int id = (int)Session["id"];

            var result = biblioDB.Czytelnik.Where(p => p.id_czytelnik == id).FirstOrDefault();
            return View(result);
        }
    }
}