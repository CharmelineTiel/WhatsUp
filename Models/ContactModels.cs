using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsUp.Models
{
    [Table("Contacten")]
    public class Contact
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Voer een naam in")]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voer een nummer in")]
        [Display(Name = "Nummer")]
        public string Nummer { get; set; }

        public int ContactAccountID { get; set; }

        public int OwnerAccountID { get; set; }
        public virtual Account OwnerAccount { get; set; }

    }

}