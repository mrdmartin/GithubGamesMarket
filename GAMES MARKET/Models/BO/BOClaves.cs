using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Models.BO
{
    public class BOClaves : Controller
    {
        // GET: BOClaves
        public claves getClaveByid_juego(int id_juego)
        {
            claves oClaves = new claves();
            using (var bd = new Games_MarketEntities())
            {
                oClaves = bd.claves.Where(p => p.id_juego.Equals(id_juego)).Where(p => p.estado.Equals(true)).FirstOrDefault();
            }
            return oClaves;
        }
        public Boolean checkStockClaveByid_juego(int id_juego)
        {
            claves oClaves = new claves();
            using (var bd = new Games_MarketEntities())
            {
                oClaves = bd.claves.Where(p => p.id_juego.Equals(id_juego)).Where(p => p.estado.Equals(true)).FirstOrDefault();
            }
            if(oClaves != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public claves getClaveByid_clave(int id_clave)
        {
            claves oClaves = new claves();
            using (var bd = new Games_MarketEntities())
            {
                oClaves = bd.claves.Where(p => p.id_clave.Equals(id_clave)).FirstOrDefault();
            }
            return oClaves;
        }
    }
}