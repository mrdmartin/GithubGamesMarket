﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult About()
        {
            ViewData["Title"] = "Sobre nosotros";
            ViewData["PageName"] = "About";
            return View();
        }
    }
}