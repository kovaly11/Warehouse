using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class Adres
    {
        [Required]
        [Display(Name = "Id")]
        public int AdresId { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string Ulica { get; set; }
        [Required]
        [Display(Name = "Numer Budynku")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "To pole musi mieć od 1 do 10 znaków")]
        public string NrBudynku { get; set; }
        [Display(Name = "Kod Pocztowy")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "To pole musi mieć od 1 do 10 znaków")]
        public string KodPocztowy { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string Miasto { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string Kraj { get; set; }

        [Display(Name = "Adres")]
        public string GetAdres
        {
            get
            {
                return "ul." + Ulica + " " + NrBudynku + ", " + Kraj;
            }
        }
        public virtual ICollection<Firma> Firma { get; set; }

    }
}