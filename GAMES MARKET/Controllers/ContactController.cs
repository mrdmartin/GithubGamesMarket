using System.Web.Mvc;
using GAMES_MARKET.Models;
using System.Net.Mail;
using GAMES_MARKET.Models.BO;

namespace GAMES_MARKET.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel oContactModel)
        {
            if (oContactModel.email == null || oContactModel.nombre == null || oContactModel.apellidos == null || oContactModel.consulta == null)
            {
                ViewBag.error = "Hay un campo vacío, rellénalo";
            }
            else
            {
                MailMessage oMailMessage = new MailMessage("gamesmarket20@gmail.com", "gamesmarket20@gmail.com", "¡Nueva consulta! de " + oContactModel.email,
                          "<p>De: " + oContactModel.nombre + " " + oContactModel.apellidos + "</p> <p> con correo electronico: " + oContactModel.email + "</p> " + oContactModel.consulta);

                BOMail oBOMail = new BOMail();
                oBOMail.sendEmail(oMailMessage);

                return View("EmailThanks");
            }
            return View();
        }
        public ActionResult EmailThanks()
        {
            return View();
        }
    }
}