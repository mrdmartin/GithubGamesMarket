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
        public Boolean addVenta(VentasModel oventasModel)
        {
            using (var bd = new Games_MarketEntities())
            {

                BOClaves oBOClaves = new BOClaves();
                claves oclaves = oBOClaves.getClaveByid_juego(oventasModel.id_juego);

                ventas oventas = new ventas();
                oclaves.estado = false;

                oventas.id_clave = oclaves.id_clave;
                oventas.id_usuario = oventasModel.id_usuario;
                oventas.fecha_venta = DateTime.Now;
                oventas.tarj = oventasModel.tarj;
                oventas.tarj_mes = oventasModel.tarj_mes;
                oventas.tarj_ano = oventasModel.tarj_ano;
                oventas.cod_seg = oventasModel.cod_seg;

                bd.ventas.Add(oventas);
                bd.SaveChanges();
            }
            return true;
        }
    }
}