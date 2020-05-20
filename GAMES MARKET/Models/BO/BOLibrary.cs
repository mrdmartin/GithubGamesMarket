using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models.BO
{
    public class BOLibrary
    {
        public List<buysLibraryModel> getBuysLibraryByIdUsuario(int id)
        {
            List<buysLibraryModel> listaBuysLibrary = new List<buysLibraryModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaBuysLibrary = (from ventas in bd.ventas
                                    where ventas.id_usuario == id

                                    join claves in bd.claves
                                    on ventas.id_clave equals claves.id_clave
                                    where claves.estado == false

                                    join juegos in bd.juegos
                                    on claves.id_juego equals juegos.id_juego

                                    join plataformas in bd.plataformas
                                    on juegos.id_plataforma equals plataformas.id_plataforma
                                    orderby ventas.fecha_venta descending

                                    select new buysLibraryModel
                                    {
                                        nombre_juego = juegos.nombre,
                                        nombre_plataforma = plataformas.nombre,
                                        clave = claves.codigo
                                    }).ToList();
            }
            return listaBuysLibrary;
        }
        public Boolean checkWishList(int id_usuario, int id_juego)
        {
            Boolean check = new Boolean();
            check = true;
            using (var bd = new Games_MarketEntities())
            {
                deseados odeseados = bd.deseados.Where(p => p.id_usuario.Equals(id_usuario) & p.id_juego.Equals(id_juego)).FirstOrDefault();
                if (odeseados is null)
                {
                    check = false;
                }
            }
            return check;
        }

        public void addToWish(int id_usuario, int id_juego)
        {
            using (var bd = new Games_MarketEntities())
            {
                deseados odeseados = new deseados();
                odeseados.id_usuario = id_usuario;
                odeseados.id_juego = id_juego;
                bd.deseados.Add(odeseados);
                bd.SaveChanges();
            }
        }
        public void removeFromWish(int id_usuario, int id_juego)
        {
            using (var bd = new Games_MarketEntities())
            {
                deseados odeseados = bd.deseados.Where(p => p.id_usuario.Equals(id_usuario) & p.id_juego.Equals(id_juego)).FirstOrDefault();
                bd.deseados.Remove(odeseados);
                bd.SaveChanges();
            }
        }

    }
}