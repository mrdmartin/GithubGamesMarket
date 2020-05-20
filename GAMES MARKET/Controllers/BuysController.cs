using GAMES_MARKET.Controllers.BO;
using GAMES_MARKET.Models;
using GAMES_MARKET.Models.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Controllers
{
    public class BuysController : Controller
    {
        // GET: Buys
        public ActionResult Buy(int? id)
        {
            BOClaves oBOClaves = new BOClaves();
            if (id is null)
            {
                return RedirectToAction("../Home");
            }
            if (oBOClaves.checkStockClaveByid_juego(id.Value) is false)
            {
                return RedirectToAction("../Games/Game/"+id);
            }

            ViewData["Title"] = "Comprar";
            ViewData["PageName"] = "Buy";

            BOJuegos oBOJuegos = new BOJuegos();
            JuegosModel ojuegosModel = oBOJuegos.getJuegoById(id.Value);
            return View(ojuegosModel);
        }
        [HttpPost]
        public ActionResult Buy(VentasModel oventasModel)
        {
            BOClaves oBOClaves = new BOClaves();
            BOJuegos oBOJuegos = new BOJuegos();
            JuegosModel ojuegosModel = oBOJuegos.getJuegoById(oventasModel.id_juego);
            if (oBOClaves.checkStockClaveByid_juego(oventasModel.id_juego) == false)
            {
                return RedirectToAction("../Games/Game/" + oventasModel.id_juego);
            }
            if (oventasModel.tarj is null || oventasModel.tarj.Length != 16)
            {
                ViewBag.Error = "Número de la tarjeta erróneo.";
                return View(ojuegosModel);
            }
            if (oventasModel.tarj_mes is null || oventasModel.tarj_mes.Length != 2)
            {
                ViewBag.Error = "Número del mes de la tarjeta erróneo.";
                return View(ojuegosModel);
            }
            if (oventasModel.tarj_ano is null || oventasModel.tarj_ano.Length != 2)
            {
                ViewBag.Error = "Número del año de la tarjeta erróneo.";
                return View(ojuegosModel);
            }
            if (oventasModel.cod_seg is null || oventasModel.cod_seg.Length != 3)
            {
                ViewBag.Error = "Número del código de seguridad de la tarjeta erróneo.";
                return View(ojuegosModel);
            }
            if(Session["log"] is null)
            {
                return RedirectToAction("../Login/Login");
            }

            ViewData["Title"] = "Compra completada";
            ViewData["PageName"] = "BuyCompleted";

            BOLogin oBOLogin = new BOLogin();
            String text = Session["log"].ToString();
            usuarios ousuario = oBOLogin.getUsuarioByEmail(text);
            oventasModel.id_usuario = ousuario.id_usuario;

            BOVentas oBOVentas = new BOVentas();
            ventas oventa = oBOVentas.addVenta(oventasModel);

            claves oclaves = oBOClaves.getClaveByid_clave(oventa.id_clave);

            MailMessage oMailMessage = new MailMessage("gamesmarket20@gmail.com", ousuario.email, "¡Gracias por comprar en GamesMarket!",
            "<p>Hola " + ousuario.nombre +" " + ousuario.apellidos + "</p>" + "<p>La Key del juego " + ojuegosModel.nombre + " comprado el " + oventa.fecha_venta + " es: </p>" +
            "<h2>" + oclaves.codigo + "</h2>" +
            "<p>¡Gracias y esperamos que sigas comprando en GamesMarket!<p>" +
            "<p>No olvides que puedes consultar la key también iniciando sesión en nuestra web: www.GamesMarket.com </p>");

            BOMail oBOMail = new BOMail();
            oBOMail.sendEmail(oMailMessage);

            return RedirectToAction("../Buys/BuyCompleted");
        }
        public ActionResult BuyCompleted()
        {
            return View();
        }
    }
}