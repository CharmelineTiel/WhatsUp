using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WhatsUp.Models
{
    //haal (contact)data uit de database
    public class DBContactRepository : IContactRepository
    {

        private WhatsUpContext ctx = new WhatsUpContext();


        public IEnumerable<Contact> HaalAlleContactenOp(int accountID)
        {
            IEnumerable<Contact> alleContacten = ctx.Contacten.Where(a => a.OwnerAccountID == accountID);
            return alleContacten;
        }

        public Contact HaalContactOp(int id)
        {
            return ctx.Contacten.SingleOrDefault(c => c.ID == id);
        }

        public void VoegContactToe(Contact contact)
        {
            bool BestaandeAccount = ctx.Accounts.Any(c => c.Nummer == contact.Nummer);

            if (BestaandeAccount.Equals(contact))
            {
               //???????
            }
            ctx.Contacten.Add(contact);
        }

        public void Opslaan()
        {
            ctx.SaveChanges();
        }

        public void Update(Contact contact)
        {
            ctx.Entry(contact).State = EntityState.Modified;
        }

        public void VerwijderContact(int id)
        {
            Contact contact = ctx.Contacten.Find(id);
            ctx.Contacten.Remove(contact);
 
        }

    }
}