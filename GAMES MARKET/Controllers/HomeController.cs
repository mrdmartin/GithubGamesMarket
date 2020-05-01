using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAMES_MARKET.Controllers.BO;
using GAMES_MARKET.Models;

namespace GAMES_MARKET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Inici";
            ViewData["PageName"] = "home";
            BOJuegos oBOJuego = new BOJuegos();


            List<juegosModel> listaJuegos = oBOJuego.getJuegosDestacados();


            ViewData["juego"] = listaJuegos;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}