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
    
    public partial class Ksiazki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ksiazki()
        {
            this.AutorzyKsiazki = new HashSet<AutorzyKsiazki>();
            this.WypozyczeniaKsiazki = new HashSet<WypozyczeniaKsiazki>();
        }
    
        public int id_ksiazka { get; set; }
        public Nullable<int> id_autor { get; set; }
        public string nazwa { get; set; }
        public string opis { get; set; }
        public string isbn { get; set; }
        public Nullable<int> id_biblio { get; set; }
    
        public virtual Autorzy Autorzy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutorzyKsiazki> AutorzyKsiazki { get; set; }
        public virtual Biblioteka Biblioteka { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WypozyczeniaKsiazki> WypozyczeniaKsiazki { get; set; }
    }
}
