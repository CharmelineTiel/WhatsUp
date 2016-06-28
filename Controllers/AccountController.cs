using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WhatsUp.Models;

namespace WhatsUp.Controllers
{
    public class AccountController : Controller
    {

        private IAccountRepository accountRepository = new DBAccountRepository();


        //Inloggen
        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                Account account = accountRepository.HaalAccountOp(model.Naam, model.Wachtwoord);

                if (account != null)
                {
                    FormsAuthentication.SetAuthCookie(account.Wachtwoord, false);

                    //account onthouden
                    Session["loggedIn_account"] = account;

                    //
                    return RedirectToAction("index", "Contact");
                }
                else
                {
                    //
                }
            }
            else
            {
                ModelState.AddModelError("login_error", "naam of wachtwoord incorrect");
            }

            return View(model);
        }

        //registreren
        public ActionResult Registreren()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registreren(RegisterModel model)
        {

            model = new RegisterModel
            {
                Naam = model.Naam,
                Nummer = model.Nummer,
                Wachtwoord = model.Wachtwoord
            };

            if (ModelState.IsValid)
            {   
                Account account = new Account();
                account.Nummer = model.Nummer;
                account.Naam = model.Naam;
                account.Wachtwoord = model.Wachtwoord;

                accountRepository.RegistrerenAccount(account);
                return RedirectToAction("Geregistreerd", "Account");

            }
            else
            {
                ModelState.AddModelError("login_error", "Er is iets misgegaan");
            }
            return View(model);
        }
        //geregistreerd success
        public ActionResult Geregistreerd()
        {
            return View();
        }

        //uitloggen
        public ActionResult LogUit()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
