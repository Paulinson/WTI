using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WypozyczoneView
    {
        public IEnumerable<WebApplication1.Models.Autorzy> autorzy { get; set; }
        public IEnumerable<WebApplication1.Models.WypozyczeniaKsiazki> wypozyczone { get; set; }
        public IEnumerable<WebApplication1.Models.Egzemplarze> egzemplarze { get; set; }
    }
}