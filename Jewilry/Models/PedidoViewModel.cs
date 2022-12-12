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
        [Required(ErrorMessage = "Debe indicar un Estado para el pedido")]
        [StringLength(maximumLength:200, ErrorMessage = "El Estado no puede tener mas de 200 caracteres")]
        public EstadoPedidoEnum Estado { get; set; }

        [Display(Prompt = "Fecha del pedido", Description = "Fecha del pedido", Name = "Fecha")]
        [Required(ErrorMessage = "Debe indicar un Fecha para el pedido")]
        public DateTime? Fecha { get; set; }

        [Display(Prompt = "Direccion del pedido", Description = "Direccion del pedido", Name = "Direccion")]
        [Required(ErrorMessage = "Debe indicar un Direccion para el pedido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Direccion no puede tener mas de 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Prompt = "Localidad del pedido", Description = "Localidad del pedido", Name = "Localidad")]
        [Required(ErrorMessage = "Debe indicar un Localidad para el pedido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Tallas no puede tener mas de 200 caracteres")]
        public string Localidad { get; set; }

        [Display(Prompt = "Provincia del pedido", Description = "Provincia del pedido", Name = "Provincia")]
        [Required(ErrorMessage = "Debe indicar un Provincia para el pedido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Provincia no puede tener mas de 200 caracteres")]
        public string Provincia { get; set; }

        [Display(Prompt = "CodigoPostal del pedido", Description = "CodigoPostal del pedido", Name = "CodigoPostal")]
        [Required(ErrorMessage = "Debe indicar una CodigoPostal para el pedido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El CodigoPostal no puede tener mas de 200 caracteres")]
        public string CodigoPostal { get; set; }

        [Display(Prompt = "TipoPago del pedido", Description = "TipoPago del pedido", Name = "TipoPago")]
        [Required(ErrorMessage = "Debe indicar una TipoPago para el pedido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El TipoPago no puede tener mas de 200 caracteres")]
        public string TipoPago { get; set; }

        [Display(Prompt = "TipoTarjeta del pedido", Description = "TipoTarjeta del pedido", Name = "TipoTarjeta")]
        [Required(ErrorMessage = "Debe indicar una TipoTarjeta para el pedido")]
        [StringLength(maximumLength: 200, ErrorMessage = "El TipoTarjeta no puede tener mas de 200 caracteres")]
        public string TipoTarjeta { get; set; }

        [Display(Prompt = "NumeroTarjeta del pedido", Description = "NumeroTarjeta del pedido", Name = "NumeroTarjeta")]
        [Required(ErrorMessage = "Debe indicar un NumeroTarjeta para el pedido")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El NumeroTarjeta debe ser mayor que 0 y menor que 10000")]
        public long NumeroTarjeta { get; set; }

        [Display(Prompt = "Total del pedido", Description = "Total del pedido", Name = "Total")]
        [Required(ErrorMessage = "Debe indicar un Total para el pedido")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El Total debe ser mayor que 0 y menor que 10000")]
        public float Total { get; set; }

    }
}