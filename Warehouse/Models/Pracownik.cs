using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class Pracownik
    {
        [Required]
        [Display(Name ="Id")]
        [ForeignKey("Dokument")]
        public int PracownikId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 20 znaków")]
        public string Imie { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 20 znaków")]
        public string Nazwisko { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 20 znaków")]
        public string Telefon { get; set; }
        [Display(Name = "Pracownik")]
        public string FullName
        {
            get
            {
                return Imie + " " + Nazwisko;
            }
        }
        public virtual ICollection<Dokument> Dokument { get; set; }

    }
}