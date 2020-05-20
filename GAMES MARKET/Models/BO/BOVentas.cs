using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Models.BO
{
    public class BOVentas : Controller
    {
        // GET: BOVentas
        public ventas addVenta(VentasModel oventasModel)
        {
            ventas oventas = new ventas();
            using (var bd = new Games_MarketEntities())
            {

                BOClaves oBOClaves = new BOClaves();
                claves oclaves = oBOClaves.getClaveByid_juego(oventasModel.id_juego);

                oclaves.estado = false;

                oventas.id_clave = oclaves.id_clave;
                oventas.id_usuario = oventasModel.id_usuario;
                oventas.fecha_venta = DateTime.Now;
                oventas.tarj = oventasModel.tarj;
                oventas.tarj_mes = oventasModel.tarj_mes;
                oventas.tarj_ano = oventasModel.tarj_ano;

                bd.ventas.Add(oventas);
                bd.SaveChanges();
            }
            return oventas;
        }
    }
}