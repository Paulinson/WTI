//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Pracownicy
    {
        [Key]
        public int id_pracownik { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string profesja { get; set; }
        public Nullable<int> id_biblio { get; set; }
    
        public virtual Biblioteka Biblioteka { get; set; }
    }
}
