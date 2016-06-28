using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;

namespace WhatsUp.Controllers
{
    public class ChatController : Controller
    {

        private IChatRepository chatRepository = new DBChatRepository();

        //bericht versturen
        [Authorize]
        public ActionResult AddChat()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddChat(int id, Bericht bericht)
        {         
            Account account = (Account)Session["loggedIn_Account"];

            Contact contact = new Contact
            {
                ContactAccountID = id
            };
            bericht = new Bericht
            {
                ChatBericht = bericht.ChatBericht,
                OntvangerID = contact.ContactAccountID,
                VerstuurderID = account.ID,
                DatumTijd = DateTime.Now
            };

            if (ModelState.IsValid)
            {          
                    chatRepository.AddChat(bericht);
                    return RedirectToAction("Index", "Contact");
            }else{

                    ModelState.AddModelError("error", "Er is iets misgegaan..");
                }
 
            return View(bericht);
        }

        //bekijk berichten per contact
        [Authorize]
        [HttpGet]
        public ActionResult BekijkAccountChat(int AccountID)
        {
            Account account = (Account)Session["loggedIn_Account"];

            IEnumerable<Bericht> alleChats = chatRepository.HaalAlleChatsOp(account.ID).Where(
                a => a.OntvangerID == AccountID || a.VerstuurderID == AccountID
                );

            return View(alleChats);
        }

    }
    
}
