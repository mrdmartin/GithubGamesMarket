using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class GamesListController : Controller
    {
        // GET: GamesList
        public ActionResult Index()
        {
            return View();
        }
    }
}