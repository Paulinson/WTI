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
    
    public partial class Wypozyczenia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wypozyczenia()
        {
            this.WypozyczeniaKsiazki = new HashSet<WypozyczeniaKsiazki>();
        }
    
        public int id_wypozyczenie { get; set; }
        public Nullable<int> id_czytelnik { get; set; }
        public Nullable<System.DateTime> do_kiedy { get; set; }
        public Nullable<int> czy_oddana { get; set; }
        public Nullable<int> czy_spozniona { get; set; }
        public Nullable<int> czy_uszkodzona { get; set; }
    
        public virtual Czytelnik Czytelnik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WypozyczeniaKsiazki> WypozyczeniaKsiazki { get; set; }
    }
}