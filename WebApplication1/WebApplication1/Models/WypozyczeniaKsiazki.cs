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
    
    public partial class WypozyczeniaKsiazki
    {
        public int id_wypozyczeniaKsiazki { get; set; }
        public Nullable<int> id_wypozyczenie { get; set; }
        public Nullable<System.DateTime> do_kiedy { get; set; }
        public Nullable<int> czy_spozniona { get; set; }
        public Nullable<int> czy_uszkodzona { get; set; }
        public Nullable<int> id_egzemplarza { get; set; }
    
        public virtual Wypozyczenia Wypozyczenia { get; set; }
        public virtual Egzemplarze Egzemplarze { get; set; }
    }
}
