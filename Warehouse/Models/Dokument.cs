using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Warehouse.Models
{
    public class Dokument
    {
        [Required]
        public int DokumentId { get; set; }
        [Required]
        public int PracownikId { get; set; }
        [Required]
        public int FirmaId { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DokumentDate { get; set; }
        [Required]
        [RegularExpression("(PT)|(RT)|(IW)|(IN)",ErrorMessage = "Tee dokumentu musi pasować do jednej z wartości: PT RT IW IN")]
        public string Typ { get; set; }
        public virtual ICollection<Pozycja> Pozycja { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public virtual Firma Firma { get; set; }
        [Display(Name ="GetZnak")]
        public virtual int GetZnak()
        {
                if (Typ == "PT" || Typ == "IW")
                    return 1;
                else
                    return -1;

        }

    }
}