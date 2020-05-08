using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAMES_MARKET.Models;

namespace GAMES_MARKET.Controllers.BO
{
    public class BOJuegos : Controller
    {
        public List<JuegosModel> getGenereFullList()
        {
            List<JuegosModel> listaGeneros = new List<JuegosModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaGeneros = (from generos in bd.generos
                                select new JuegosModel
                                {
                                    id_genero = generos.id_genero,
                                    nombre_genero = generos.nombre
                                }).ToList();
            }
            return listaGeneros;
        }
        public List<JuegosModel> getPlatformFullList()
        {
            List<JuegosModel> listaPlataformas = new List<JuegosModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaPlataformas = (from plataformas in bd.plataformas
                                    select new JuegosModel
                                    {
                                        id_plataforma = plataformas.id_plataforma,
                                        nombre_plataforma = plataformas.nombre,
                                        img_rutaPlataforma = plataformas.img_ruta
                                    }).ToList();
            }
            return listaPlataformas;
        }
        public JuegosModel getJuegoById(int pId)
        {
            JuegosModel oJuegoModel = new JuegosModel();
            using (var bd = new Games_MarketEntities())
            {
                juegos oJuegos = bd.juegos.Where(p => p.id_juego.Equals(pId)).First();
                plataformas oPlataformas = bd.plataformas.Where(p => p.id_plataforma.Equals(oJuegos.id_plataforma)).First();

                oJuegoModel.id_juego = oJuegos.id_juego;
                oJuegoModel.nombre = oJuegos.nombre;
                oJuegoModel.id_plataforma = oJuegos.id_plataforma;
                oJuegoModel.precio = oJuegos.precio;
                oJuegoModel.img_ruta = oJuegos.img_ruta;
                oJuegoModel.trailer_url = oJuegos.trailer_url;
                oJuegoModel.distribuidora = oJuegos.distribuidora;
                oJuegoModel.descripcion = oJuegos.descripcion;
                oJuegoModel.fecha_lanzamiento = oJuegos.fecha_lanzamiento;
                oJuegoModel.img_rutaPlataforma = oPlataformas.img_ruta;
            }
            return oJuegoModel;
        }
        public List<JuegosModel> getOfertas()
        {
            List<JuegosModel> listaJuegos = new List<JuegosModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaJuegos = (from juegos in bd.juegos
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
            }
            return listaJuegos;
        }
        public List<JuegosModel> getJuegosDestacados()
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
                                    descuento = descuentos.descuento
                                }).ToList();

                listaJuegos = (from juegos in bd.juegos
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
                                   nombre_plataforma = plataformas.nombre,
                                   img_rutaPlataforma = plataformas.img_ruta,
                                   descuento = 0

                               }).ToList();

                listaJuegos = (listaJuegos.Concat(listaOfertas)).OrderByDescending(i => i.fecha_lanzamiento).ToList();

            }
            return listaJuegos;
        }
        public List<JuegosModel> getFullList()
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

                listaJuegos = (listaJuegos.Concat(listaOfertas).ToList());

            }
            return listaJuegos;
        }

        public List<CapturasModel> GetCapturasList(int id)
        {
            List<CapturasModel> listaCapturas = new List<CapturasModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaCapturas = (from capturas in bd.capturas
                                 join juegos in bd.juegos
                                 on capturas.id_juego equals juegos.id_juego
                                 where capturas.id_juego == id

                                 select new CapturasModel
                                 {
                                     id_captura = capturas.id_captura,
                                     id_juego = juegos.id_juego,
                                     img_ruta = capturas.img_ruta
                                 }).ToList();
            }
            return listaCapturas;
        }
    }
}