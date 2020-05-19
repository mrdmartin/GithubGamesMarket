using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models
{
    public class VentasModel
    {
        public int id_venta { get; set; }
        public int id_juego { get; set; }
        public int id_clave { get; set; }
        public int id_usuario { get; set; }
        public DateTime fecha_venta { get; set; }
        [Required]
        public string tarj { get; set; }
        [Required]
        public string tarj_mes { get; set; }
        [Required]
        public string tarj_ano { get; set; }
        [Required]
        public string cod_seg { get; set; }
    }
}