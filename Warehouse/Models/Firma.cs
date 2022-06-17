using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class Firma
    {
        [Required]
        public int FirmaId {get; set;}
        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string Nazwa { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string NIP { get; set; }
        [Display(Name = "Osoba Kontaktowa")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string OsobaKontaktowa { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string Telefon { get; set; }
        [Display(Name = "Stona Internetowa")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string StonaInternetowa { get; set; }
        [Required]
        public int AdresId{ get; set; }
        public  Adres Adres { get; set; }
        public virtual ICollection<Dokument> Dokument { get; set; }
    }
}