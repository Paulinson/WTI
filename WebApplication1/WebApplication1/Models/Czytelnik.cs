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
    
    public partial class Czytelnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Czytelnik()
        {
            this.Wypozyczenia = new HashSet<Wypozyczenia>();
            this.Egzemplarze = new HashSet<Egzemplarze>();
        }
    
        public int id_czytelnik { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string kod { get; set; }
        public string pesel { get; set; }
        public string email { get; set; }
        public string kod_pocztowy { get; set; }
        public string miasto { get; set; }
        public string ulica { get; set; }
        public Nullable<int> nr_domu { get; set; }
        public Nullable<int> nr_mieszkania { get; set; }
        public string wojewodztwo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wypozyczenia> Wypozyczenia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egzemplarze> Egzemplarze { get; set; }
    }
}
