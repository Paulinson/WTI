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
    
    public partial class Biblioteka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biblioteka()
        {
            this.Ksiazki = new HashSet<Ksiazki>();
            this.Pracownicy = new HashSet<Pracownicy>();
            this.Egzemplarze = new HashSet<Egzemplarze>();
        }
    
        public int id_biblio { get; set; }
        public Nullable<int> id_adres { get; set; }
        public string nazwa { get; set; }
    
        public virtual AdresyBiblio AdresyBiblio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ksiazki> Ksiazki { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pracownicy> Pracownicy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egzemplarze> Egzemplarze { get; set; }
    }
}
