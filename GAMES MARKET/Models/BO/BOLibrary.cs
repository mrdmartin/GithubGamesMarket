using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models.BO
{
    public class BOLibrary
    {
        public List<BuysLibraryModel> getBuysLibrary(int id)
        {
            List<BuysLibraryModel> listaBuysLibrary = new List<BuysLibraryModel>();
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

                                    select new BuysLibraryModel
                                    {
                                        nombre_juego = juegos.nombre,
                                        nombre_plataforma = plataformas.nombre,
                                        clave = claves.codigo
                                    }).ToList();
            }
            return listaBuysLibrary;
        }
        public List<JuegosModel> getWishLibrary(int id_usuario)
        {
            List<JuegosModel> listaJuegos = new List<JuegosModel>();
            List<JuegosModel> listaOfertas = new List<JuegosModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaOfertas = (from juegos in bd.juegos

                                join plataformas in bd.plataformas
                                on juegos.id_plataforma equals plataformas.id_plataforma

                                join descuentos in bd.descuentos
                                on juegos.id_juego equals descuentos.id_juego
                                where (DateTime.Now > descuentos.inicio) && (DateTime.Now < descuentos.fin)

                                join deseados in bd.deseados
                                on juegos.id_juego equals deseados.id_juego
                                where deseados.id_usuario == id_usuario

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

                               join plataformas in bd.plataformas
                               on juegos.id_plataforma equals plataformas.id_plataforma

                               join descuentos in bd.descuentos
                               on juegos.id_juego equals descuentos.id_juego into todas
                               from descuentos in todas.DefaultIfEmpty()
                               where descuentos == null || ((DateTime.Now < descuentos.inicio) && (DateTime.Now > descuentos.fin))

                               join deseados in bd.deseados
                               on juegos.id_juego equals deseados.id_juego
                               where deseados.id_usuario == id_usuario

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
                                   nombre_plataforma = plataformas.nombre,
                                   img_rutaPlataforma = plataformas.img_ruta,
                                   descuento = 0

                               }).ToList();

                listaJuegos = listaOfertas.Concat(listaJuegos).OrderByDescending(i => i.descuento).ToList();
                foreach (var item in listaJuegos)
                {
                    item.precio = item.precio - (item.precio * item.descuento / 100);
                    item.precio = Math.Round(item.precio, 2);
                }
            }
            return listaJuegos;
        }
        public Boolean checkWishList(int id_usuario, int id_juego)
        {
            Boolean check = true;
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