using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class DBAccountRepository : IAccountRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public Account HaalAccountOp(string naam, string wachtwoord)
        {
            return ctx.Accounts.Where(a => a.Naam == naam && a.Wachtwoord == wachtwoord).FirstOrDefault();
        }

        public Account RegistrerenAccount(Account nieuwAccount)
        {
            ctx.Accounts.Add(nieuwAccount);
            ctx.SaveChanges();
            return nieuwAccount;
        }
    }
}