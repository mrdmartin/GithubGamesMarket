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
        [HttpPost]
        public ActionResult Help(UsuariosModel ousuariosmodel)
        {
            ViewData["Title"] = "Ayuda";
            ViewData["PageName"] = "Help";

            BOLogin oBOLogin = new BOLogin();
            String token = oBOLogin.randomPassword();

            using (Games_MarketEntities db = new Games_MarketEntities())
            {
                var oUsuario = db.usuarios.Where(d => d.email == ousuariosmodel.email).FirstOrDefault();
                if (oUsuario != null)
                {
                    oUsuario.token = token;
                    db.SaveChanges();

                    String Dominio = "https://localhost:44327/";
                    String url = Dominio + "Login/CambioContrasena/?token=" + token;

                    MailMessage oMailMessage = new MailMessage("gamesmarket20@gmail.com", ousuariosmodel.email, "Restaurar contraseña GamesMarket",
                        "<p>Correo de recuperación que falta tunear el html </p><br>" +
                        "<a href='" + url + "'>Click para recuperar</a>");

                    BOMail oBOMail = new BOMail();
                    oBOMail.sendEmail(oMailMessage);

                    return View("CorrectSend");
                }
                else
                {
                    ViewBag.error = "El correo no corresponde con ninguno registrado en la web. Revisa tus credenciales.";
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            ViewData["Title"] = "Registro";
            ViewData["PageName"] = "Register";
            return View();
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
            if (oBOLogin.getUsuarioByEmail(oregisterModel.email) != null)
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
                    if (model.contrasena == null || model.contrasena2 == null)
                    {
                        ViewBag.error = "Contraseña no puede estar vacia";
                    }
                    else if (model.contrasena != model.contrasena2)
                    {
                        ViewBag.error = "Las contraseñas no coinciden";
                    }
                    else
                    {
                        oUsuario.contrasena = model.contrasena;
                        oUsuario.token = null;
                        db.SaveChanges();
                        return View("passChanged");
                    }
                }
                else
                {
                    ViewBag.error = "Contaseña provisional expirada";
                }
            }
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
        public ActionResult CorrectSend()
        {

            ViewData["Title"] = "Correo enviado";
            ViewData["PageName"] = "CorrectSend";

            return View();
        }
        public ActionResult passChanged(UsuariosModel model)
        {
            ViewData["Title"] = "Contraseña Cambiada";
            ViewData["PageName"] = "passChanged";
            return View();
        }
        public ActionResult logOut()
        {
            Session["Log"] = null;
            return RedirectToAction("/Login/Login");
        }
    }
}