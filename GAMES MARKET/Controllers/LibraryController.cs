using GAMES_MARKET.Models;
using GAMES_MARKET.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class LibraryController : Controller
    {
        // GET: Library
        public ActionResult buysLibrary()
        {
            if (Session["log"] is null)
            {
                return RedirectToAction("../Home/home");
            }
            String text = Session["log"].ToString();
            BOLogin oBOLogin = new BOLogin();
            usuarios usuario = oBOLogin.getUsuarioByEmail(text);

            BOLibrary oBOLibrary = new BOLibrary();
            List<buysLibraryModel> listBuysLibraryModel = oBOLibrary.getBuysLibraryByIdUsuario(usuario.id_usuario);

            return View(listBuysLibraryModel);
        }
        public ActionResult wishList()
        {
            return View();
        }
        public ActionResult addWish(int id)
        {
            String userEmail = Session["log"].ToString();
            BOLogin oBOLogin = new BOLogin();
            usuarios user = oBOLogin.getUsuarioByEmail(userEmail);

            BOLibrary oBOLibrary = new BOLibrary();
            oBOLibrary.addToWish(user.id_usuario, id);

            return RedirectToAction("../Games/Game/" + id);
        }
        public ActionResult delWish(int id)
        {
            String userEmail = Session["log"].ToString();
            BOLogin oBOLogin = new BOLogin();
            usuarios user = oBOLogin.getUsuarioByEmail(userEmail);

            BOLibrary oBOLibrary = new BOLibrary();
            oBOLibrary.removeFromWish(user.id_usuario, id);

            return RedirectToAction("../Games/Game/" + id);
        }
    }
}