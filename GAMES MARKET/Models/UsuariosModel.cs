using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models
{
    public class UsuariosModel
    {
        [Required]
        public int id_usuario { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidos { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string contrasena { get; set; }
        [Required]
        public string contrasena2 { get; set; }
        public string token { get; set; }
    }
}