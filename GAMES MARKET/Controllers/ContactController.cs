using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Contact()
        {
            ViewData["Title"] = "Contacto";
            ViewData["PageName"] = "Contact";
            return View();
        }
    }
}