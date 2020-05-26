using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAMES_MARKET.Models.BO
{
    public class BOComentarios : Controller
    {
        public List<ComentariosModel> getComments(int id)
        {
            List<ComentariosModel> listaComentarios = new List<ComentariosModel>();
            using (var bd = new Games_MarketEntities())
            {
                listaComentarios = (from comentarios in bd.comentarios
                                    join juegos in bd.juegos
                                    on comentarios.id_juego equals juegos.id_juego
                                    join usuarios in bd.usuarios
                                    on comentarios.id_usuario equals usuarios.id_usuario
                                    where comentarios.id_juego == id
                                    orderby comentarios.fecha descending
                                    select new ComentariosModel
                                {
                                    id_comentario = comentarios.id_comentario,
                                    id_juego = comentarios.id_juego,
                                    id_usuario = comentarios.id_usuario,
                                    nombre_usuario = usuarios.nombre,
                                    comentario = comentarios.comentario,
                                    fecha = comentarios.fecha
                                }).ToList();
            }
            return listaComentarios;
        }
        public void post(int id_juego, int id_usuario, string comment)
        {
            using (var bd = new Games_MarketEntities())
            {

                comentarios ocomentarios = new comentarios();
                ocomentarios.id_juego = id_juego;
                ocomentarios.id_usuario = id_usuario;
                ocomentarios.comentario = comment;
                ocomentarios.fecha = DateTime.Now;
                bd.comentarios.Add(ocomentarios);
                bd.SaveChanges();
            }
        }
    }
}