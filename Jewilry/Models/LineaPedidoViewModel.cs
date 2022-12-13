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

        [ScaffoldColumn(false)]
        [Display(Prompt = "Articulo del LineaPedido", Description = "Articulo del LineaPedido", Name = "Foto")]
        public string FotoArticulo { get; set; }

        [ScaffoldColumn(false)]
        [Display(Prompt = "Nombre del LineaPedido", Description = "Nombre del LineaPedido", Name = "Nombre")]
        public string NombreArticulo { get; set; }

        [Display(Prompt = "Valor del LineaPedido", Description = "Valor del LineaPedido", Name = "Unidades")]
        [Required(ErrorMessage = "Debe indicar un Valor para el LineaPedido")]
        public int Unidades { get; set; }

        [Display(Prompt = "Valor del LineaPedido", Description = "Valor del LineaPedido", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un Valor para el LineaPedido")]
        public float Precio { get; set; }

        



    }
}