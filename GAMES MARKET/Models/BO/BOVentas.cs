using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
                using (var dbContextTransaction = bd.Database.BeginTransaction())
                {
                    try
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

                        dbContextTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();

                        BOLogin oBOUsuarios = new BOLogin();

                        usuarios ousuario = oBOUsuarios.getUsuarioById(oventasModel.id_usuario);

                        MailMessage oMailMessage = new MailMessage("gamesmarket20@gmail.com", "gamesmarket20@gmail.com", "Error al comprar",
                        "<p>El usuario " + ousuario.email + " ha intentado comprar el juego con id " + oventasModel.id_juego + "y se ha producido el siguiente error:</p>" + e);

                        BOMail oBOMail = new BOMail();
                        oBOMail.sendEmail(oMailMessage);
                        oventas.id_clave = 0;
                    }
                }
            }
            return oventas;
        }
    }
}