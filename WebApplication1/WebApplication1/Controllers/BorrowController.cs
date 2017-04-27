using System;
using System.Collections;
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
        public ActionResult GetKsiazki(string k)
        {
            var ksiazki = from i in biblioDB.AutorzyKsiazki
                          select i;

            if (!String.IsNullOrEmpty(k))
            {
                ksiazki = from i in biblioDB.AutorzyKsiazki
                          where i.Ksiazki.nazwa.Contains(k)
                          select i;
            }

            return View(ksiazki.ToList());
        }

        public ActionResult getEgzemplarze(int id)
        {
            var details = biblioDB.Egzemplarze.Where(a => a.id_ksiazka == id);

            return View(details);

            
        }

        public ActionResult Wypozycz(int id)
        {
            int? id_czyt = (int?)Session["id"];
            var details = biblioDB.Wypozyczenia.Where(p => p.id_czytelnik == id_czyt).FirstOrDefault();
            if(details == null)
            {
                var egz = biblioDB.Egzemplarze.Where(p => p.id_egzemplarz == id).FirstOrDefault();
                if (egz.id_status == 1)
                {
                    var wyp = new Wypozyczenia { id_czytelnik = id_czyt };
                    biblioDB.Wypozyczenia.Add(wyp);
                    var wypK = new WypozyczeniaKsiazki { id_wypozyczenie = wyp.id_wypozyczenie, id_egzemplarza = id, do_kiedy = DateTime.Now.AddDays(50), czy_spozniona = 0, czy_uszkodzona = 0 };
                    egz.id_status = 3;
                    biblioDB.WypozyczeniaKsiazki.Add(wypK);
                    //biblioDB.Egzemplarze.Add(egz);
                    biblioDB.SaveChanges();
                }
            }
            else
            {
                
                //var wyp = new Wypozyczenia { id_czytelnik = (int?)Session["id"] };
                var wyp = biblioDB.Wypozyczenia.Where(p => p.id_czytelnik == id_czyt).FirstOrDefault();
         
                var wypK = new WypozyczeniaKsiazki { id_wypozyczenie = wyp.id_wypozyczenie, id_egzemplarza = id, do_kiedy = DateTime.Now.AddDays(30), czy_spozniona = 0, czy_uszkodzona = 0 };
                var egz = biblioDB.Egzemplarze.Where(p => p.id_egzemplarz == id).FirstOrDefault();
                if (egz.id_status == 1)
                    egz.id_status = 3;
                biblioDB.WypozyczeniaKsiazki.Add(wypK);
                
                biblioDB.SaveChanges();
                return RedirectToAction("getEgzemplarze", "Borrow", new { id = egz.id_ksiazka });
            }

            return View();
        }
       
        public ActionResult getWypozyczone()
        {
            var details = biblioDB.WypozyczeniaKsiazki.Where(p => p.Wypozyczenia.id_czytelnik == 1).ToList();

            return View(details);
        }
    }
}