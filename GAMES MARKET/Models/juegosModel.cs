using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GAMES_MARKET.Models
{    
    public partial class juegosModel
    {
        [Display(Name = "ID Juego")]
        [Required]
        public int id_juego { get; set; }
        [Display(Name = "Nombre juego")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "ID plataforma")]
        [Required]
        public int id_plataforma { get; set; }
        [Display(Name = "Precio")]
        [Required]
        public decimal precio { get; set; }
        [Display(Name = "Ruta carátula")]
        [Required]
        public string img_ruta { get; set; }
        [Display(Name = "Link tráiler")]
        [Required]
        public string trailer_url { get; set; }
        [Display(Name = "Distribuidora")]
        [Required]
        public string distribuidora { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        public string descripcion { get; set; }
        [Display(Name = "Fecha de lanzamiento")]
        [Required]
        public System.DateTime fecha_lanzamiento { get; set; }
        [Display(Name = "Plataforma")]
        [Required]
        public string nombre_plataforma { get; set; }
        public string img_rutaPlataforma { get; set; }
    }
}
