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
            var query = biblioDB.AutorzyKsiazki.GroupBy(b => b.Ksiazki.nazwa).Select(g => new { nazwa = g.Key, Count = g.Count() }).Where(g => g.Count > 1).ToList();
            
            /*
            var query = from a in biblioDB.AutorzyKsiazki
                        join au in biblioDB.Autorzy on a.id_autor equals au.id_autor
                        join k in biblioDB.Ksiazki on a.id_ksiazka equals k.id_ksiazka
                        where k.nazwa == (from b in biblioDB.AutorzyKsiazki
                                          join ks in biblioDB.Ksiazki on b.id_ksiazka equals ks.id_ksiazka
                                        group b by ks.nazwa into g
                                        where g.Count() > 1
                                        select new { nazwa = g.Key}).ToString()
                        select new { imie = au.imie, nazwisko=au.nazwisko };
            */
            //var query = biblioDB.AutorzyKsiazki.GroupBy(b => b.id_ksiazka).Select(g => new { ksiazka = g.Key, count = g.Count() }).Where(g => g.count > 1).ToList();
          // var query = biblioDB.AutorzyKsiazki.Select(g => new { imie = g.Autorzy.imie, nazwisko = g.Autorzy.nazwisko }).ToList();

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
            var details = biblioDB.Wypozyczenia.Where(p => p.id_czytelnik ==(int?)Session["id"]);
            var czytelnik = biblioDB.Czytelnik.Where(p => p.id_czytelnik == (int?)Session["id"]);
            if(details != null)
            {
                var wyp = new Wypozyczenia { id_czytelnik = (int?)Session["id"] };
                biblioDB.Wypozyczenia.Add(wyp);
                var wypK = new WypozyczeniaKsiazki { id_wypozyczenie = wyp.id_wypozyczenie, id_egzemplarza = id, do_kiedy = DateTime.Now.AddDays(50), czy_spozniona = 0, czy_uszkodzona = 0 };
                var egz = biblioDB.Egzemplarze.Where(p => p.id_egzemplarz == id).FirstOrDefault();
                if (egz.id_status == 1)
                    egz.id_status = 3;
                biblioDB.WypozyczeniaKsiazki.Add(wypK);
                biblioDB.Egzemplarze.Add(egz);
                biblioDB.SaveChanges();
            }
            else
            {
                var wyp = new Wypozyczenia { id_czytelnik = (int?)Session["id"] };
                var egz = new Egzemplarze();
                var wypK = new WypozyczeniaKsiazki { id_wypozyczenie = wyp.id_wypozyczenie, id_egzemplarza = id, do_kiedy = DateTime.Now.AddDays(50), czy_spozniona = 0, czy_uszkodzona = 0 };
                if (wypK.Egzemplarze.id_status == 1)
                {
                    wypK.Egzemplarze.id_status = 3;
                    egz.id_status = 3;
                }
                biblioDB.WypozyczeniaKsiazki.Add(wypK);
                biblioDB.SaveChanges();
            }

            return View(biblioDB.WypozyczeniaKsiazki.ToList());
        }
       
        public ActionResult getWypozyczone()
        {
            var details = biblioDB.WypozyczeniaKsiazki.Where(p => p.Wypozyczenia.id_czytelnik == 1).ToList();

            return View(details);
        }
    }
}