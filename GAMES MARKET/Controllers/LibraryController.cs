using GAMES_MARKET.Models;
using GAMES_MARKET.Models.BO;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class LibraryController : Controller
    {
        public ActionResult buysLibrary()
        {
            if (Session["log"] is null)
            {
                return RedirectToAction("../Home/home");
            }

            BOLogin oBOLogin = new BOLogin();
            usuarios usuario = oBOLogin.getUsuarioById((int)Session["Log"]);

            BOLibrary oBOLibrary = new BOLibrary();
            List<BuysLibraryModel> listBuysLibraryModel = oBOLibrary.getBuysLibrary(usuario.id_usuario);

            return View(listBuysLibraryModel);
        }
        public ActionResult wishLibrary()
        {
            if (Session["log"] is null)
            {
                return RedirectToAction("../Login/Login");
            }

            BOLogin oBOLogin = new BOLogin();
            usuarios usuario = oBOLogin.getUsuarioById((int)Session["Log"]);

            BOLibrary oBOLibrary = new BOLibrary();
            List<JuegosModel> listaJuegos = oBOLibrary.getWishLibrary(usuario.id_usuario);

            return View(listaJuegos);
        }
        public ActionResult addWish(int id)
        {
            BOLogin oBOLogin = new BOLogin();
            usuarios user = oBOLogin.getUsuarioById((int) Session["Log"]);

            BOLibrary oBOLibrary = new BOLibrary();
            oBOLibrary.addToWish(user.id_usuario, id);

            return RedirectToAction("../Games/Game/" + id);
        }
        public ActionResult delWish(int id)
        {
            BOLogin oBOLogin = new BOLogin();
            usuarios user = oBOLogin.getUsuarioById((int) Session["Log"]);

            BOLibrary oBOLibrary = new BOLibrary();
            oBOLibrary.removeFromWish(user.id_usuario, id);

            return RedirectToAction("../Games/Game/" + id);
        }
    }
}