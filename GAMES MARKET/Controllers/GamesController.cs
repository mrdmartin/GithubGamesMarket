using GAMES_MARKET.Controllers.BO;
using GAMES_MARKET.Models;
using GAMES_MARKET.Models.BO;
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
            ViewData["Title"] = "Juego";
            ViewData["PageName"] = "Game";
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

            BOComentarios oBOComentarios = new BOComentarios();
            List<ComentariosModel> listaComentarios = oBOComentarios.getComments(id.Value);
            ViewData["comentarios"] = listaComentarios;

            BOClaves oBOClaves = new BOClaves();
            ViewBag.stock = oBOClaves.checkStockClaveByid_juego(id.Value);

            BOLogin oBOLOgin = new BOLogin();
            if (Session["log"] != null)
            {
                String userEmail = Session["log"].ToString();
                usuarios usuario = oBOLOgin.getUsuarioByEmail(userEmail);

                BOLibrary oBOLibrary = new BOLibrary();
                ViewBag.wish = oBOLibrary.checkWishList(usuario.id_usuario, id.Value);
            }

            return View(juegosModel);
        }

        [HttpPost]
        public ActionResult Game(int? id, String comment)
        {
            ViewData["Title"] = "Juego";
            ViewData["PageName"] = "Game";
            if (Session["Log"] == null)
            {
                return RedirectToAction("/Login/Login");
            }
            if (id == null)
            {
                id = 1;
            }
            juegos juego = new juegos();
            using (var bd = new Games_MarketEntities())
            {

                juego = bd.juegos.Find(id);
            }
            if (juego == null)
            {
                id = 1;
            }

            BOJuegos oBOjuego = new BOJuegos();
            JuegosModel juegosModel = oBOjuego.getJuegoById(id.Value);

            List<CapturasModel> listaCapturas = oBOjuego.GetCapturasList(id.Value);
            ViewData["capturas"] = listaCapturas;

            BOComentarios oBOComentarios = new BOComentarios();
            if (comment != "")
            {
                String email = Session["log"].ToString();
                oBOComentarios.Post(id.Value, email, comment);
            }
            List<ComentariosModel> listaComentarios = oBOComentarios.getComments(id.Value);
            ViewData["comentarios"] = listaComentarios;


            return View(juegosModel);
        }
        public ActionResult List()
        {
            ViewData["Title"] = "Lista de juegos";
            ViewData["PageName"] = "List";
            BOJuegos oBOJuego = new BOJuegos();

            List<JuegosModel> listaJuegos = oBOJuego.getFullList();
            ViewData["Lista"] = listaJuegos;

            List<JuegosModel> listaGeneros = oBOJuego.getGenereFullList();
            ViewData["GeneroLista"] = listaGeneros;

            List<JuegosModel> listaPlataformas = oBOJuego.getPlatformFullList();
            ViewData["PlataformaLista"] = listaPlataformas;

            return View(listaJuegos);
        }
    }
}