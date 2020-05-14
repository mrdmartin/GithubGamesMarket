using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAMES_MARKET.Models;

namespace GAMES_MARKET.Models.BO
{
    public class BOApi : Controller
    {
        public List<JuegosModel> getGameslist(JuegosModel ofilter)
        {
            List<JuegosModel> listaJuegos = null;

            if (ofilter.id_genero != 0 && ofilter.id_plataforma != 0)
            {
                using (var bd = new Games_MarketEntities())
                {
                    listaJuegos = (from juegos in bd.juegos
                                   where (juegos.nombre.Contains(ofilter.nombre))
                                   join generos_juegos in bd.generos_juegos
                                   on juegos.id_juego equals generos_juegos.id_juego
                                   join generos in bd.generos
                                   on generos_juegos.id_genero equals generos.id_genero
                                   where generos.id_genero == ofilter.id_genero
                                   join plataformas in bd.plataformas
                                    on juegos.id_plataforma equals plataformas.id_plataforma
                                   where plataformas.id_plataforma == ofilter.id_plataforma

                                   select new JuegosModel
                                   {
                                       id_juego = juegos.id_juego,
                                       nombre = juegos.nombre,
                                       id_plataforma = juegos.id_plataforma,
                                       precio = juegos.precio,
                                       img_ruta = juegos.img_ruta,
                                       trailer_url = juegos.trailer_url,
                                       distribuidora = juegos.distribuidora,
                                       descripcion = juegos.descripcion,
                                       fecha_lanzamiento = juegos.fecha_lanzamiento,
                                       img_rutaPlataforma = plataformas.img_ruta
                                   }).ToList();
                    return listaJuegos;
                }
            }

            if (ofilter.id_genero != 0 && ofilter.id_plataforma == 0)
            {
                using (var bd = new Games_MarketEntities())
                {
                    listaJuegos = (from juegos in bd.juegos
                                   where (juegos.nombre.Contains(ofilter.nombre))
                                   join plataformas in bd.plataformas
                                   on juegos.id_plataforma equals plataformas.id_plataforma
                                   join generos_juegos in bd.generos_juegos
                                   on juegos.id_juego equals generos_juegos.id_juego
                                   join generos in bd.generos
                                   on generos_juegos.id_genero equals generos.id_genero
                                   where generos.id_genero == ofilter.id_genero

                                   select new JuegosModel
                                   {
                                       id_juego = juegos.id_juego,
                                       nombre = juegos.nombre,
                                       id_plataforma = juegos.id_plataforma,
                                       precio = juegos.precio,
                                       img_ruta = juegos.img_ruta,
                                       trailer_url = juegos.trailer_url,
                                       distribuidora = juegos.distribuidora,
                                       descripcion = juegos.descripcion,
                                       fecha_lanzamiento = juegos.fecha_lanzamiento,
                                       img_rutaPlataforma = plataformas.img_ruta
                                   }).ToList();
                    return listaJuegos;
                }
            }
            if (ofilter.id_genero == 0 && ofilter.id_plataforma != 0)
            {
                using (var bd = new Games_MarketEntities())
                {
                    listaJuegos = (from juegos in bd.juegos
                                   where (juegos.nombre.Contains(ofilter.nombre))
                                   join plataformas in bd.plataformas
                                    on juegos.id_plataforma equals plataformas.id_plataforma
                                   where plataformas.id_plataforma == ofilter.id_plataforma
                                   select new JuegosModel
                                   {
                                       id_juego = juegos.id_juego,
                                       nombre = juegos.nombre,
                                       id_plataforma = juegos.id_plataforma,
                                       precio = juegos.precio,
                                       img_ruta = juegos.img_ruta,
                                       trailer_url = juegos.trailer_url,
                                       distribuidora = juegos.distribuidora,
                                       descripcion = juegos.descripcion,
                                       fecha_lanzamiento = juegos.fecha_lanzamiento,
                                       img_rutaPlataforma = plataformas.img_ruta
                                   }).ToList();
                    return listaJuegos;
                }
            }
            else
            {
                using (var bd = new Games_MarketEntities())
                {
                    listaJuegos = (from juegos in bd.juegos
                                   where (juegos.nombre.Contains(ofilter.nombre))
                                   join plataformas in bd.plataformas
                                   on juegos.id_plataforma equals plataformas.id_plataforma

                                   select new JuegosModel
                                   {
                                       id_juego = juegos.id_juego,
                                       nombre = juegos.nombre,
                                       id_plataforma = juegos.id_plataforma,
                                       precio = juegos.precio,
                                       img_ruta = juegos.img_ruta,
                                       trailer_url = juegos.trailer_url,
                                       distribuidora = juegos.distribuidora,
                                       descripcion = juegos.descripcion,
                                       fecha_lanzamiento = juegos.fecha_lanzamiento,
                                       img_rutaPlataforma = plataformas.img_ruta
                                   }).ToList();
                    return listaJuegos;
                }
            }
        }
    }
}
