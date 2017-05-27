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
    
    public partial class Ksiazki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ksiazki()
        {
            this.AutorzyKsiazki = new HashSet<AutorzyKsiazki>();
            this.Egzemplarze = new HashSet<Egzemplarze>();
        }
        [Key]
        [Display(Name = "ID Ksi��ka")]

        public int id_ksiazka { get; set; }
        [Display(Name = "Nazwa")]
        public string nazwa { get; set; }
        [Display(Name = "Opis")]
        public string opis { get; set; }
        [Display(Name = "ISBN")]
        public string isbn { get; set; }
        [Display(Name = "ID Biblioteki")]
        public Nullable<int> id_biblio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutorzyKsiazki> AutorzyKsiazki { get; set; }
        public virtual Biblioteka Biblioteka { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egzemplarze> Egzemplarze { get; set; }
    }
}
