using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models
{
    public class CapturasModel
    {
        public int id_captura { get; set; }
        public int id_juego { get; set; }
        public string img_ruta { get; set; }
    }
}