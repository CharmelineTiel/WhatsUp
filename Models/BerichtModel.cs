using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    [Table("Berichten")]
    public class Bericht
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Bericht")]
        public string ChatBericht { get; set; }

        [Required]
        [Display(Name = "Ontvanger")]
        public int OntvangerID { get; set; }

        [Required]
        [Display(Name = "Verstuurder")]
        public int VerstuurderID { get; set; }


        [Required]
        [Display(Name = "Tijd / Datum")]
        public DateTime DatumTijd { get; set; }  
    }
}