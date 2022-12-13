using JewilryGenNHibernate.EN.JoyeriaJewirly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jewilry.Models
{
    public class LineaPedidoViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Display(Prompt = "Valor del articulo", Description = "Valor del articulo", Name = "Unidades")]
        [Required(ErrorMessage = "Debe indicar un Valor para el articulo")]
        public int Unidades { get; set; }

        [Display(Prompt = "Valor del articulo", Description = "Valor del articulo", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un Valor para el articulo")]
        public float Precio { get; set; }

        



    }
}