using GAMES_MARKET.Models;
using GAMES_MARKET.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuariosModel usuariosModel)
        {
            if (usuariosModel.email == null)
            {
                ViewBag.error = "Falta el correo electrónico";
                return View();
            }
            if(usuariosModel.contrasena == null)
            {
                ViewBag.error = "Falta la contraseña";
                return View();
            }
            BOLogin oBOLogin = new BOLogin();
            usuariosModel = oBOLogin.Login(usuariosModel);
            if (usuariosModel.nombre != null)
            {
                Session["Log"] = usuariosModel.email;
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Register(UsuariosModel oregisterModel)
        {
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
    }
}