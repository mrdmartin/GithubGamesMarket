using System.Collections.Generic;
using System.Web.Mvc;
using GAMES_MARKET.Controllers.BO;
using GAMES_MARKET.Models;

namespace GAMES_MARKET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            BOJuegos oBOJuego = new BOJuegos();
            List<JuegosModel> listaOfertas = oBOJuego.getJuegosOferta();
            ViewData["Ofertas"] = listaOfertas;

            List<JuegosModel> listaJuegos = oBOJuego.getJuegosDestacados();
            ViewData["juego"] = listaJuegos;

            return View();
        }
    }
}