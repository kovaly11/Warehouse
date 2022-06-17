using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class Towar
    {
        [Required]
        [Display(Name = "Id")]
        public int TowarId { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 40 znaków")]
        public string Nazwa { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 20 znaków")]
        public string  NrSerijny { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 20 znaków")]
        public string Wymiary { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "To pole musi mieć od 2 do 20 znaków")]
        public string Producent { get; set; }
        [Display(Name = "Ilosc")]
        public virtual int GetIlosc( int il)
        {
            return il;

        }
        public virtual ICollection<Pozycja> Pozycja { get; set; }
    }
}