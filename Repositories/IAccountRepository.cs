using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    interface IAccountRepository 
    {
       Account HaalAccountOp(string naam, string wachtwoord);
       Account RegistrerenAccount(Account nieuwAccount);
    }
}