using GAMES_MARKET.Models;
using GAMES_MARKET.Models.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace GAMES_MARKET.Controllers
{
    public class LoginController : Controller
    {
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
            if (oBOLogin.Login(usuariosModel) != null)
            {
                usuariosModel = oBOLogin.Login(usuariosModel);
                Session["Log"] = usuariosModel.email;
                return RedirectToAction("../Home/Index");
            }
            else
            {
                ViewBag.error = "usuario o contraseña incorrecta";
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