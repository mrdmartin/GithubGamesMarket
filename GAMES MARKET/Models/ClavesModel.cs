using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models
{
    public class ClavesModel
    {
        public int id_clave { get; set; }
        public int id_juego { get; set; }
        public String codigo { get; set; }
        public bool estado { get; set; }
    }
}