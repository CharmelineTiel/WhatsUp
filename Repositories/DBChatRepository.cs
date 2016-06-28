using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class DBChatRepository : IChatRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        //haal alle chats op
        public IEnumerable<Bericht> HaalAlleChatsOp(int accountID)
        {
            IEnumerable<Bericht> alleChats = ctx.Chats.Where(a => a.VerstuurderID == accountID || a.OntvangerID == accountID
 
                );
            return alleChats;
        }

        public void AddChat(Bericht chat)
        {
            ctx.Chats.Add(chat);
            ctx.SaveChanges();
        }

    }
}