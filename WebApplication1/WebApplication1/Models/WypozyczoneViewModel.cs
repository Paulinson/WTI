using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WypozyczoneViewModel
    {
        [Key]
        int id { get; set; }
        Czytelnik czytelnik { get; set; }
        WypozyczeniaKsiazki wypK { get; set; }
    }
}