using JewilryGenNHibernate.EN.JoyeriaJewirly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jewilry.Models
{
    public class ValoracionViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Display(Prompt = "Comentario del articulo", Description = "Nombre del articulo", Name = "Comentario")]
        [Required(ErrorMessage = "Debe indicar un Comentario para el articulo")]
        [StringLength(maximumLength:200, ErrorMessage = "El Comentario no puede tener mas de 200 caracteres")]
        public string Comentario { get; set; }

        [Display(Prompt = "Valor del articulo", Description = "Valor del articulo", Name = "Valor")]
        [Required(ErrorMessage = "Debe indicar un Valor para el articulo")]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "La valoración tiene que ser entre 0 y 5")]
        public int Valor { get; set; }

        [Display(Prompt = "Articulo del articulo", Description = "Articulo del articulo", Name = "Articulo")]
        [Required(ErrorMessage = "Debe indicar un Articulo para el articulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Articulo no puede tener mas de 200 caracteres")]
        public ArticuloEN Articulo { get; set; }

        [Display(Prompt = "Cliente del articulo", Description = "Cliente del articulo", Name = "Cliente")]
        [Required(ErrorMessage = "Debe indicar un Cliente para el articulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Cliente no puede tener mas de 200 caracteres")]
        public ClienteEN Cliente { get; set; }



    }
}