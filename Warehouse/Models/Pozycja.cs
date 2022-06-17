using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class Pozycja
    {
        [Key, Column(Order = 1)]
        public int DokumentId { get; set; }
        [Key, Column(Order = 2)]
        public int NrPozycji { get; set; }
        [Required]
        public int TowarId { get; set; }
        [Required]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Ilość musi być dodatnia")]
        public int Ilosc { get; set; }
        public virtual Towar Towar { get; set; }
        public virtual Dokument Dokument { get; set; }
    }
}