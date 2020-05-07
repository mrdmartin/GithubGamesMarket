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
            if (id == null)
            {
                id = 1;
            }
            juegos juego = new juegos();
            using (var bd = new Games_MarketEntities())
            {
                
                juego = bd.juegos.Find(id);
            }
            if(juego == null)
            {
                id = 1;
            }
            
            BOJuegos oBOjuego = new BOJuegos();
            JuegosModel juegosModel = oBOjuego.getJuegoById(id.Value);

            List<CapturasModel> listaCapturas = oBOjuego.GetCapturasList(id.Value);
            ViewData["capturas"] = listaCapturas;

            return View(juegosModel);
        }
        public ActionResult List()
        {
            ViewData["Title"] = "GamesList";
            ViewData["PageName"] = "Lista de juegos";
            BOJuegos oBOJuego = new BOJuegos();

            List<JuegosModel> listaJuegos = oBOJuego.getFullList();
            ViewData["Lista"] = listaJuegos;

            List<JuegosModel> listaGeneros = oBOJuego.getGenereFullList();
            ViewData["GeneroLista"] = listaGeneros;

            List<JuegosModel> listaPlataformas = oBOJuego.getPlatformFullList();
            ViewData["PlataformaLista"] = listaPlataformas;

            return View();
        }
    }
}