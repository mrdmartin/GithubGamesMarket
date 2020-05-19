using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Models.BO
{
    public class BOMail : Controller
    {
        // GET: BOMail
        public void sendEmail(MailMessage oMailMessage)
        {
            String EmailEmpresa = "gamesmarket20@gmail.com";
            String contrasena = "gamesm20+";

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oMailMessage.IsBodyHtml = true;
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailEmpresa, contrasena);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();
        }
    }
}