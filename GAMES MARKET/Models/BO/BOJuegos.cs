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
        // GET: BOCadena
        public juegosModel getJuegoById(int pId)
        {
            juegosModel oJuegoModel = new juegosModel();
            using (var bd = new Games_MarketEntities())
            {
                juegos oJuegos = bd.juegos.Where(p => p.id_juego.Equals(pId)).First();
                oJuegoModel.id_juego = oJuegos.id_juego;
                oJuegoModel.nombre = oJuegos.nombre;
                oJuegoModel.id_plataforma = oJuegos.id_plataforma;
                oJuegoModel.precio = oJuegos.precio;
                oJuegoModel.img_ruta = oJuegos.img_ruta;
                oJuegoModel.trailer_url = oJuegos.trailer_url;
                oJuegoModel.distribuidora = oJuegos.distribuidora;
                oJuegoModel.descripcion = oJuegos.descripcion;
                oJuegoModel.fecha_lanzamiento = oJuegos.fecha_lanzamiento;
            }
            return oJuegoModel;
        }
        public List<juegosModel> getOfertas()
        {
            List<juegosModel> listaJuegos = new List<juegosModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaJuegos = (from juegos in bd.juegos
                               join plataformas in bd.plataformas
                              on juegos.id_plataforma equals plataformas.id_plataforma
                              join descuentos in bd.descuentos
                              on juegos.id_juego equals descuentos.id_juego
                               where (DateTime.Now > descuentos.inicio) && (DateTime.Now < descuentos.fin)
                               orderby descuentos.descuento descending

                               select new juegosModel
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
        public List<juegosModel> getJuegosDestacados()
        {
            List<juegosModel> listaOfertas = new List<juegosModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaOfertas = (from juegos in bd.juegos
                               join plataformas in bd.plataformas
                               on juegos.id_plataforma equals plataformas.id_plataforma
                               orderby juegos.fecha_lanzamiento descending

                               select new juegosModel
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
                                   img_rutaPlataforma = plataformas.img_ruta
                               }).ToList();
            }
            return listaOfertas;
        }

        public List<juegosModel> getFullList()
        {
            List<juegosModel> listaJuegos = new List<juegosModel>();
            List<juegosModel> listaOfertas = new List<juegosModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaOfertas = (from juegos in bd.juegos
                                join plataformas in bd.plataformas
                               on juegos.id_plataforma equals plataformas.id_plataforma
                                join descuentos in bd.descuentos
                                on juegos.id_juego equals descuentos.id_juego
                                where (DateTime.Now > descuentos.inicio) && (DateTime.Now < descuentos.fin)
                                orderby descuentos.descuento descending

                                select new juegosModel
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

                               select new juegosModel
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
    }
}