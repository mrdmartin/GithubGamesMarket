using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class CookiesController : Controller
    {
        // GET: Cookies
        public ActionResult Cookies()
        {
            ViewData["Title"] = "Política de cookies";
            ViewData["PageName"] = "Cookies";
            return View();
        }
    }
}