using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Voer een naam in")]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voer een nummer in")]
        [Display(Name = "Nummer")]
        public string Nummer { get; set; }

        [Required(ErrorMessage = "Voer een wachtwoord in")]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        [Required(ErrorMessage = "Voer opnieuw uw wachtwoord in")]
        [Display(Name = "Opnieuw Wachtwoord")]
        [DataType(DataType.Password)]
        [Compare("Wachtwoord", ErrorMessage="Wachtwoord komt niet overeen")]
        public string ValideerWachtwoord { get; set; }


    }
}