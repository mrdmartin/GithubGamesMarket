using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAMES_MARKET.Models;
using System.Net.Mail;
using GAMES_MARKET.Models.BO;

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
        [HttpPost]
        public ActionResult Contact(ContactModel oContactModel)
        {
            ViewData["Title"] = "Contacto";
            ViewData["PageName"] = "Contact";

            MailMessage oMailMessage = new MailMessage("gamesmarket20@gmail.com", "gamesmarket20@gmail.com", "¡Nueva consulta! de " + oContactModel.email,
            "<p>De: " + oContactModel.nombre + " " + oContactModel.apellidos + "</p> <p> con correo electronico: " + oContactModel.email + "</p> " + oContactModel.consulta);

            BOMail oBOMail = new BOMail();
            oBOMail.sendEmail(oMailMessage);

            return View("EmailThanks");
        }
        public ActionResult EmailThanks(ContactModel oContactModel)
        {
            ViewData["Title"] = "Gracias por contactar";
            ViewData["PageName"] = "EmailThanks";

            return View();

        }
    }
}