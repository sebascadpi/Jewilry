using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JewilryGenNHibernate.Enumerated.JoyeriaJewirly;
using System.Linq;
using System.Web;

namespace Jewilry.Models
{
    public class PedidoViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Display(Prompt = "Estado del pedido", Description = "Estado del pedido", Name = "Estado")]
        public EstadoPedidoEnum Estado { get; set; }

        [Display(Prompt = "Fecha del pedido", Description = "Fecha del pedido", Name = "Fecha")]
        public DateTime? Fecha { get; set; }

        [Display(Prompt = "Direccion del pedido", Description = "Direccion del pedido", Name = "Direccion")]
        [Required(ErrorMessage = "Debe indicar un Direccion para el pedido")]
        public string Direccion { get; set; }

        [Display(Prompt = "Localidad del pedido", Description = "Localidad del pedido", Name = "Localidad")]
        [Required(ErrorMessage = "Debe indicar un Localidad para el pedido")]
        public string Localidad { get; set; }

        [Display(Prompt = "Provincia del pedido", Description = "Provincia del pedido", Name = "Provincia")]
        [Required(ErrorMessage = "Debe indicar un Provincia para el pedido")]
        public string Provincia { get; set; }

        [Display(Prompt = "CodigoPostal del pedido", Description = "CodigoPostal del pedido", Name = "CodigoPostal")]
        [Required(ErrorMessage = "Debe indicar una CodigoPostal para el pedido")]
        public string CodigoPostal { get; set; }

        [Display(Prompt = "TipoPago del pedido", Description = "TipoPago del pedido", Name = "TipoPago")]
        [Required(ErrorMessage = "Debe indicar una TipoPago para el pedido")]
        public string TipoPago { get; set; }

        [Display(Prompt = "TipoTarjeta del pedido", Description = "TipoTarjeta del pedido", Name = "TipoTarjeta")]
        [Required(ErrorMessage = "Debe indicar una TipoTarjeta para el pedido")]
        public string TipoTarjeta { get; set; }

        [Display(Prompt = "NumeroTarjeta del pedido", Description = "NumeroTarjeta del pedido", Name = "NumeroTarjeta")]
        [Required(ErrorMessage = "Debe indicar un NumeroTarjeta para el pedido")]
        [Range(minimum: 1000000000000000, maximum: 9999999999999999, ErrorMessage = "La tarjeta tiene que tener una longitud de 16 digitos")]
        public long NumeroTarjeta { get; set; }

        [Display(Prompt = "Total del pedido", Description = "Total del pedido", Name = "Total")]
        public float Total { get; set; }

    }
}