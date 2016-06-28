using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace WhatsUp.Models
{

    [Table("Accounts")]
    public class Account
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Naam")]
        public string Naam { get; set; }

        [Required]
        [Display(Name = "Nummer")]
        public string Nummer { get; set; }

        [Required]
        [Display(Name = "Wachtwoord")]
        public string Wachtwoord { get; set; }


        //lijst met contacten
        public virtual ICollection<Contact> Contacten { get; set; }

        public Account(){

            this.Contacten = new HashSet<Contact>();
        }

    }


}
