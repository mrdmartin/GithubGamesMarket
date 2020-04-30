using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginCompleted()
        {
            int a = 1;
            if (a == 2)
            {
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Help()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser()
        {
            //asdasd
            int a = 1;
            if (a == 2)
            {
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return View();
            }
        }
    }
}