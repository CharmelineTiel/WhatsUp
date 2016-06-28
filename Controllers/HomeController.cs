using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;

namespace WhatsUp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "WhatsUp WebApplication";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacten";

            return View("~/Views/Contact/index.cshtml");   

        }
    }
}
