//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAMES_MARKET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class valoraciones
    {
        public int id_juego { get; set; }
        public int id_usuario { get; set; }
        public int valoracion { get; set; }
    
        public virtual juegos juegos { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
