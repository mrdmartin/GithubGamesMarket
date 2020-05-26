using GAMES_MARKET.Controllers.BO;
using GAMES_MARKET.Models;
using GAMES_MARKET.Models.BO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class GamesController : Controller
    {
        public ActionResult Game(int? id)
        {
            //Control de errores
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

            //Encuentra los datos del juego
            BOJuegos oBOjuego = new BOJuegos();
            JuegosModel juegosModel = oBOjuego.getJuegoById(id.Value);
            
            //Encuentra los generos del juego
            List<GenerosModel> oGenerosModel = oBOjuego.GetGenerosById_juegosList(id.Value);
            string generos = "";
            foreach (var item in oGenerosModel)
            {
                generos += " " + @item.nombre;
            }
            ViewBag.generos = generos;

            //Encuentra las capturas del juego
            List<CapturasModel> listaCapturas = oBOjuego.GetCapturasList(id.Value);
            ViewData["capturas"] = listaCapturas;
            
            //Encuentra los comentarios
            BOComentarios oBOComentarios = new BOComentarios();
            List<ComentariosModel> listaComentarios = oBOComentarios.getComments(id.Value);
            ViewData["comentarios"] = listaComentarios;
            if (listaComentarios.Count != 0)
            {
                ViewBag.checkComments = true;
            }

            //Comprueba si hay stock
            BOClaves oBOClaves = new BOClaves();
            ViewBag.stock = oBOClaves.checkStockClaveByid_juego(id.Value);

            //Comprueba si el usuario lo tiene en lista de deseados
            BOLogin oBOLogin = new BOLogin();
            if (Session["log"] != null)
            {
                usuarios usuario = oBOLogin.getUsuarioById((int) Session["Log"]);
                BOLibrary oBOLibrary = new BOLibrary();
                ViewBag.wish = oBOLibrary.checkWishList(usuario.id_usuario, id.Value);
            }
            return View(juegosModel);
        }

        [HttpPost]
        public ActionResult Game(int? id, String comment)
        {
            //Control de errores
            if (Session["Log"] == null)
            {
                return RedirectToAction("/Login/Login");
            }
            if (id == null)
            {
                return RedirectToAction("../Games/Game/" + id);
            }
            juegos juego = new juegos();
            using (var bd = new Games_MarketEntities())
            {

                juego = bd.juegos.Find(id);
            }
            if (juego == null || comment == "")
            {
                return RedirectToAction("/Game");
            }
            //Encuentra los datos del juego
            BOJuegos oBOjuego = new BOJuegos();
            JuegosModel juegosModel = oBOjuego.getJuegoById(id.Value);

            //Encuentra los generos del juego
            List<GenerosModel> oGenerosModel = oBOjuego.GetGenerosById_juegosList(id.Value);
            string generos = "";
            foreach (var item in oGenerosModel)
            {
                generos += " " + @item.nombre;
            }
            ViewBag.generos = generos;

            //Encuentra las capturas del juego
            List<CapturasModel> listaCapturas = oBOjuego.GetCapturasList(id.Value);
            ViewData["capturas"] = listaCapturas;

            //Añade el comentario
            BOComentarios oBOComentarios = new BOComentarios();
            if (comment != "")
            {
                oBOComentarios.Post(id.Value, (int)Session["Log"], comment);
            }
            //Encuentra los comentarios
            List<ComentariosModel> listaComentarios = oBOComentarios.getComments(id.Value);
            ViewData["comentarios"] = listaComentarios;

            if(listaComentarios.Count != 0)
            {
                ViewBag.checkComments = true;
            }

            //Comprueba si hay stock
            BOClaves oBOClaves = new BOClaves();
            ViewBag.stock = oBOClaves.checkStockClaveByid_juego(id.Value);

            //Comprueba si el usuario lo tiene en lista de deseados
            if (Session["log"] != null)
            {
                BOLogin oBOLogin = new BOLogin();
                usuarios usuario = oBOLogin.getUsuarioById((int)Session["Log"]);
                BOLibrary oBOLibrary = new BOLibrary();
                ViewBag.wish = oBOLibrary.checkWishList(usuario.id_usuario, id.Value);
            }

            return View(juegosModel);
        }
        public ActionResult List()
        {
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