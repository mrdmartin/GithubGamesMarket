﻿using System;
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
            List<JuegosModel> listaOfertas = oBOJuego.getOfertas();
            ViewData["Ofertas"] = listaOfertas;

            List<JuegosModel> listaJuegos = oBOJuego.getJuegosDestacados();
            ViewData["juego"] = listaJuegos;

            return View();
        }
    }
}