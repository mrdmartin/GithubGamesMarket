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
            List<JuegosModel> listaJuegos = new List<JuegosModel>();
            List<JuegosModel> listaOfertas = new List<JuegosModel>();

            if (ofilter.id_genero != 0 && ofilter.id_plataforma != 0)
            {
                using (var bd = new Games_MarketEntities())
                {
                    listaOfertas = (from juegos in bd.juegos
                                    where (juegos.nombre.Contains(ofilter.nombre))
                                    join plataformas in bd.plataformas
                                    on juegos.id_plataforma equals plataformas.id_plataforma
                                    where plataformas.id_plataforma == ofilter.id_plataforma
                                    join generos_juegos in bd.generos_juegos
                                    on juegos.id_juego equals generos_juegos.id_juego
                                    join generos in bd.generos
                                    on generos_juegos.id_genero equals generos.id_genero
                                    where generos.id_genero == ofilter.id_genero
                                    join descuentos in bd.descuentos
                                    on juegos.id_juego equals descuentos.id_juego
                                    where (DateTime.Now > descuentos.inicio) && (DateTime.Now < descuentos.fin)
                                    orderby descuentos.descuento descending

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
                                        nombre_plataforma = plataformas.nombre,
                                        img_rutaPlataforma = plataformas.img_ruta,
                                        descuento = descuentos.descuento
                                    }).ToList();

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
                                   join descuentos in bd.descuentos
                                   on juegos.id_juego equals descuentos.id_juego into todas
                                   from descuentos in todas.DefaultIfEmpty()
                                   where descuentos == null || ((DateTime.Now < descuentos.inicio) && (DateTime.Now > descuentos.fin))
                                   orderby juegos.fecha_lanzamiento descending

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


                    listaJuegos = listaOfertas.Concat(listaJuegos).OrderByDescending(i => i.descuento).ToList();

                    foreach (var item in listaJuegos)
                    {
                        item.fecha_lanzamiento_string = item.fecha_lanzamiento.ToShortDateString();
                        item.precio = item.precio - (item.precio * item.descuento / 100);
                        item.precio = Math.Round(item.precio, 2);
                    }
                    return listaJuegos;
                }
            }
            if (ofilter.id_genero != 0 && ofilter.id_plataforma == 0)
            {
                using (var bd = new Games_MarketEntities())
                {
                    listaOfertas = (from juegos in bd.juegos
                                    where (juegos.nombre.Contains(ofilter.nombre))
                                    join plataformas in bd.plataformas
                                    on juegos.id_plataforma equals plataformas.id_plataforma
                                    join generos_juegos in bd.generos_juegos
                                    on juegos.id_juego equals generos_juegos.id_juego
                                    join generos in bd.generos
                                    on generos_juegos.id_genero equals generos.id_genero
                                    where generos.id_genero == ofilter.id_genero
                                    join descuentos in bd.descuentos
                                    on juegos.id_juego equals descuentos.id_juego
                                    where (DateTime.Now > descuentos.inicio) && (DateTime.Now < descuentos.fin)
                                    orderby descuentos.descuento descending

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
                                        nombre_plataforma = plataformas.nombre,
                                        img_rutaPlataforma = plataformas.img_ruta,
                                        descuento = descuentos.descuento
                                    }).ToList();

                    listaJuegos = (from juegos in bd.juegos
                                   where (juegos.nombre.Contains(ofilter.nombre))
                                   join plataformas in bd.plataformas
                                   on juegos.id_plataforma equals plataformas.id_plataforma
                                   join generos_juegos in bd.generos_juegos
                                   on juegos.id_juego equals generos_juegos.id_juego
                                   join generos in bd.generos
                                   on generos_juegos.id_genero equals generos.id_genero
                                   where generos.id_genero == ofilter.id_genero
                                   join descuentos in bd.descuentos
                                   on juegos.id_juego equals descuentos.id_juego into todas
                                   from descuentos in todas.DefaultIfEmpty()
                                   where descuentos == null || ((DateTime.Now < descuentos.inicio) && (DateTime.Now > descuentos.fin))
                                   orderby juegos.fecha_lanzamiento descending

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

                    listaJuegos = listaOfertas.Concat(listaJuegos).OrderByDescending(i => i.descuento).ToList();

                    foreach (var item in listaJuegos)
                    {
                        item.fecha_lanzamiento_string = item.fecha_lanzamiento.ToShortDateString();
                        item.precio = item.precio - (item.precio * item.descuento / 100);
                        item.precio = Math.Round(item.precio, 2);
                    }
                    return listaJuegos;
                }
            }
            if (ofilter.id_genero == 0 && ofilter.id_plataforma != 0)
            {
                using (var bd = new Games_MarketEntities())
                {
                    listaOfertas = (from juegos in bd.juegos
                                    where (juegos.nombre.Contains(ofilter.nombre))
                                    join plataformas in bd.plataformas
                                    on juegos.id_plataforma equals plataformas.id_plataforma
                                    where plataformas.id_plataforma == ofilter.id_plataforma
                                    join descuentos in bd.descuentos
                                    on juegos.id_juego equals descuentos.id_juego
                                    where (DateTime.Now > descuentos.inicio) && (DateTime.Now < descuentos.fin)
                                    orderby descuentos.descuento descending

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
                                        nombre_plataforma = plataformas.nombre,
                                        img_rutaPlataforma = plataformas.img_ruta,
                                        descuento = descuentos.descuento
                                    }).ToList();

                    listaJuegos = (from juegos in bd.juegos
                                   where (juegos.nombre.Contains(ofilter.nombre))
                                   join plataformas in bd.plataformas
                                   on juegos.id_plataforma equals plataformas.id_plataforma
                                   where plataformas.id_plataforma == ofilter.id_plataforma
                                   join descuentos in bd.descuentos
                                   on juegos.id_juego equals descuentos.id_juego into todas
                                   from descuentos in todas.DefaultIfEmpty()
                                   where descuentos == null || ((DateTime.Now < descuentos.inicio) && (DateTime.Now > descuentos.fin))
                                   orderby juegos.fecha_lanzamiento descending
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

                    listaJuegos = listaOfertas.Concat(listaJuegos).OrderByDescending(i => i.descuento).ToList();

                    foreach (var item in listaJuegos)
                    {
                        item.fecha_lanzamiento_string = item.fecha_lanzamiento.ToShortDateString();
                        item.precio = item.precio - (item.precio * item.descuento / 100);
                        item.precio = Math.Round(item.precio, 2);
                    }
                    return listaJuegos;
                }
            }
            else
            {
                using (var bd = new Games_MarketEntities())
                {
                    listaOfertas = (from juegos in bd.juegos
                                    where (juegos.nombre.Contains(ofilter.nombre))
                                    join plataformas in bd.plataformas
                                    on juegos.id_plataforma equals plataformas.id_plataforma
                                    join descuentos in bd.descuentos
                                    on juegos.id_juego equals descuentos.id_juego
                                    where (DateTime.Now > descuentos.inicio) && (DateTime.Now < descuentos.fin)
                                    orderby descuentos.descuento descending

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
                                        nombre_plataforma = plataformas.nombre,
                                        img_rutaPlataforma = plataformas.img_ruta,
                                        descuento = descuentos.descuento
                                    }).ToList();

                    listaJuegos = (from juegos in bd.juegos
                                   where (juegos.nombre.Contains(ofilter.nombre))
                                   join plataformas in bd.plataformas
                                   on juegos.id_plataforma equals plataformas.id_plataforma
                                   join descuentos in bd.descuentos
                                   on juegos.id_juego equals descuentos.id_juego into todas
                                   from descuentos in todas.DefaultIfEmpty()
                                   where descuentos == null || ((DateTime.Now < descuentos.inicio) && (DateTime.Now > descuentos.fin))
                                   orderby juegos.fecha_lanzamiento descending

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

                    listaJuegos = listaOfertas.Concat(listaJuegos).OrderByDescending(i => i.descuento).ToList();

                    foreach (var item in listaJuegos)
                    {
                        item.fecha_lanzamiento_string = item.fecha_lanzamiento.ToShortDateString();
                        item.precio = item.precio - (item.precio * item.descuento / 100);
                        item.precio = Math.Round(item.precio, 2);
                    }
                    return listaJuegos;
                }
            }
        }
    }
}
