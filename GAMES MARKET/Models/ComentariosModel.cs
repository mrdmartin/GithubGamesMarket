using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models
{
    public class ComentariosModel
    {
        public int id_comentario { get; set; }
        public int id_juego { get; set; }
        public int id_usuario { get; set; }
        public string nombre_usuario { get; set; }
        public string comentario { get; set; }
        public System.DateTime fecha { get; set; }
    }
}