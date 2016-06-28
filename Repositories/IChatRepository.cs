using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    interface IChatRepository
    {
        IEnumerable<Bericht> HaalAlleChatsOp(int accountID);
        void AddChat(Bericht chat);
    }
}