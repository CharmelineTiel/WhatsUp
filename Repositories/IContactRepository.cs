using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    //interface (tussenlaag) voor het communiceren met database 
    interface IContactRepository
    {
        IEnumerable<Contact> HaalAlleContactenOp(int accountID);
        Contact HaalContactOp(int id);
        void VoegContactToe(Contact contact);
        void Opslaan();
        void Update(Contact contact);
        void VerwijderContact(int id);
    }
}