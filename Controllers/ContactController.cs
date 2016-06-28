using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;

namespace WhatsUp.Controllers
{
    public class ContactController : Controller
    {

        private IContactRepository contactRepository = new DBContactRepository();


        [Authorize]
        public ActionResult Index()
        {
            Account account =(Account)Session["loggedIn_Account"];
            
            if (account != null)
            {
                IEnumerable<Contact> alleContacten = contactRepository.HaalAlleContactenOp(account.ID);
                return View(alleContacten.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        //Contact/VoegContactToe
        [Authorize]
        public ActionResult VoegContactToe()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult VoegContactToe(Contact contact)
        {
            Account account = (Account)Session["loggedIn_Account"];

            contact = new Contact { 
                    
                            Naam = contact.Naam,
                            Nummer = contact.Nummer,
                            OwnerAccountID = account.ID
                    };

                if (ModelState.IsValid)
                {
                    contactRepository.VoegContactToe(contact);
                    contactRepository.Opslaan();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("error", "Er is iets misgegaan");
                }

            return View(contact);
        }

        //Contact/WijzigContact
        [Authorize]
        [HttpGet]
        public ActionResult WijzigContact(int id)
        {
            Contact contact = contactRepository.HaalContactOp(id);

            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [Authorize]
        [HttpPost]
        public ActionResult WijzigContact(Contact contact)
        {
            Account account = (Account)Session["loggedIn_Account"];

            contact.Naam = contact.Naam;
            contact.Nummer = contact.Nummer;
            contact.OwnerAccountID = account.ID;

            if (ModelState.IsValid)
            {
                contactRepository.Update(contact);
                contactRepository.Opslaan();
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("error", "Er is iets misgegaan");
            }

            return View(contact);
        }


        //Contact/VerwijderContact
        [Authorize]
        public ActionResult VerwijderContact(int id)
        {
            Contact contact = contactRepository.HaalContactOp(id);
            return View(contact);
        }
        [Authorize]
        [HttpPost]
        public ActionResult VerwijderContact(Contact contact)
        {

            if (ModelState.IsValid)
            {
                contactRepository.VerwijderContact(contact.ID);
                contactRepository.Opslaan();        
            }
            else
            {
                ModelState.AddModelError("error", "Er is iets misgegaan..");
            }

            return RedirectToAction("Index", "Contact");
        }
    }
}
