using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Voer uw naam in")]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Voer een wachtwoord in")]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]        
        public string Wachtwoord { get; set; }
    }
}