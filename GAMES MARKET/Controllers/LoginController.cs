using GAMES_MARKET.Models;
using GAMES_MARKET.Models.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace GAMES_MARKET.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            ViewData["Title"] = "Iniciar sesión";
            ViewData["PageName"] = "Login";
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuariosModel usuariosModel)
        {
            ViewData["Title"] = "Iniciar sesión";
            ViewData["PageName"] = "Login";
            if (usuariosModel.email == null)
            {
                ViewBag.error = "Falta el correo electrónico";
                return View();
            }
            if (usuariosModel.contrasena == null)
            {
                ViewBag.error = "Falta la contraseña";
                return View();
            }
            BOLogin oBOLogin = new BOLogin();
            if (oBOLogin.Login(usuariosModel) != null)
            {
                usuariosModel = oBOLogin.Login(usuariosModel);
                Session["Log"] = usuariosModel.email;
                return RedirectToAction("../Home/Home");
            }
            else
            {
                ViewBag.error = "Email o contraseña incorrecta";
                return View();
            }

        }

        public ActionResult Help()
        {
            ViewData["Title"] = "Ayuda";
            ViewData["PageName"] = "Help";
            return View();
        }

        public ActionResult Register()
        {
            ViewData["Title"] = "Registro";
            ViewData["PageName"] = "Register";
            return View();
        }
        public ActionResult UserData()
        {
            ViewData["Title"] = "Perfil de usuario";
            ViewData["PageName"] = "Profile";
            BOLogin oBOLogin = new BOLogin();
            String text = Session["log"].ToString();
            usuarios usuario = oBOLogin.getUsuarioByEmail(text);
            UsuariosModel usuariosModel = new UsuariosModel();
            usuariosModel.email = usuario.email;
            usuariosModel.nombre = usuario.nombre;
            usuariosModel.apellidos = usuario.apellidos;

            return View(usuariosModel);
        }

        private void EnviarEmail(string EmailCliente, String token)
        {
            String EmailEmpresa = "gamesmarket20@gmail.com";
            String contrasena = "gamesm20+";
            string Dominio = "https://localhost:44327/";
            String url = Dominio + "Login/CambioContrasena/?token=" + token;

            MailMessage oMailMessage = new MailMessage(EmailEmpresa, EmailCliente, "Restaurar contraseña GamesMarket",
                "<p>Correo de recuperación que falta tunear el html </p><br>" +
                "<a href='" + url + "'>Click para recuperar</a>");

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oMailMessage.IsBodyHtml = true;
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailEmpresa, contrasena);
            oSmtpClient.Send(oMailMessage);
            oSmtpClient.Dispose();
        }
        private String randomPassword(string randompas)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            randompas = new String(stringChars);
            return randompas;
        }
        [HttpPost]
        public ActionResult Register(UsuariosModel oregisterModel)
        {
            ViewData["Title"] = "Registro";
            ViewData["PageName"] = "Register";
            BOLogin oBOLogin = new BOLogin();

            if (!ModelState.IsValid)
            {
                ViewBag.error = "Faltan campos por rellenar.";
                return View(oregisterModel);
            }
            if (oBOLogin.getUsuarioByEmail(oregisterModel.email)!= null)
            {
                ViewBag.error = "El email ya ha sido registrado previamente";
                return View(oregisterModel);
            }
            if (oregisterModel.contrasena != oregisterModel.contrasena2)
            {
                ViewBag.error = "Las contraseñas no son iguales";
                return View(oregisterModel);
            }
            else
            {
                oBOLogin.addUser(oregisterModel);
                return RedirectToAction("../Home/Index");
            }
        }
        
        [HttpPost]
        public ActionResult Help(UsuariosModel model)
        {
            ViewData["Title"] = "Ayuda";
            ViewData["PageName"] = "Help";

            string token = randomPassword(Guid.NewGuid().ToString());
            using (Games_MarketEntities db = new Games_MarketEntities())
            {
                var oUsuario = db.usuarios.Where(d => d.email == model.email).FirstOrDefault();
                if (oUsuario != null)
                {
                    oUsuario.token = token;
                    db.SaveChanges();
                    //envia mail
                    EnviarEmail(oUsuario.email, token);
                }
            }
            return View();
        }
        public ActionResult CambioContrasena(String token)
        {
            UsuariosModel model = new UsuariosModel();
            using (Games_MarketEntities db = new Games_MarketEntities())
            {

                if (token == null)
                {
                    return View("Index");
                }
                var oUsuario = db.usuarios.Where(d => d.token == model.token).FirstOrDefault();
                if (oUsuario == null)
                {
                    ViewBag.Error = "Contaseña provisional expirada";
                    return View("Index");
                }
            }
            model.token = token;

            return View(model);
        }
        [HttpPost]
        public ActionResult CambioContrasena(UsuariosModel model)
        {
            using (Games_MarketEntities db = new Games_MarketEntities())
            {
                var oUsuario = db.usuarios.Where(d => d.token == model.token).FirstOrDefault();

                if (oUsuario != null)
                {
                    oUsuario.contrasena = model.contrasena;
                    oUsuario.token = null;
                    db.Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Contraseña modificada con exito";
                }
                else
                {
                    ViewBag.Message = "Contaseña provisional expirada";
                }

            }

            return View();
        }
    }
}