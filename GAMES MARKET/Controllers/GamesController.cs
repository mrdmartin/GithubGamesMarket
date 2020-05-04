using GAMES_MARKET.Controllers.BO;
using GAMES_MARKET.Models;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class GamesController : Controller
    {
        // GET: Game
        public ActionResult Game(int? id)
        {
            juegos juego = new juegos();
            if (id == null)
            {
                id = 1;
            }
            using (var bd = new Games_MarketEntities())
            {
                
                juego = bd.juegos.Find(id);
            }
            if(juego == null)
            {
                id = 1;
            }
            juegosModel juegoasd = new juegosModel();
            BOJuegos oBOjuego = new BOJuegos();

            juegoasd = oBOjuego.getJuegoById(id.Value);
            return View(juegoasd);
        }
        public ActionResult List()
        {
            ViewData["Title"] = "GamesList";
            ViewData["PageName"] = "Lista de juegos";
            BOJuegos oBOJuego = new BOJuegos();

            List<juegosModel> listaJuegos = oBOJuego.getFullList();
            ViewData["Lista"] = listaJuegos;

            return View();
        }
    }
}