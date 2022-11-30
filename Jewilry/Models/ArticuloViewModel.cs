using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jewilry.Models
{
    public class ArticuloViewModel
    {
        [ScaffoldColumn(false)]

        public int Id { get; set; }

        [Display(Prompt = "Nombre del articulo", Description = "Nombre del articulo", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el articulo")]
        [StringLength(maximumLength:200, ErrorMessage = "El nombre no puede tener mas de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Material del articulo", Description = "Material del articulo", Name = "Material")]
        [Required(ErrorMessage = "Debe indicar un Material para el articulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Material no puede tener mas de 200 caracteres")]
        public string Material { get; set; }

        [Display(Prompt = "Marca del articulo", Description = "Marca del articulo", Name = "Marca")]
        [Required(ErrorMessage = "Debe indicar un Marca para el articulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Marca no puede tener mas de 200 caracteres")]
        public string Marca { get; set; }

        [Display(Prompt = "Tallas del articulo", Description = "Tallas del articulo", Name = "Tallas")]
        [Required(ErrorMessage = "Debe indicar un Tallas para el articulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Tallas no puede tener mas de 200 caracteres")]
        public string Tallas { get; set; }

        [Display(Prompt = "Descripcion del articulo", Description = "Descripcion del articulo", Name = "Descripcion")]
        [Required(ErrorMessage = "Debe indicar un Descripcion para el articulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Descripcion no puede tener mas de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Foto del articulo", Description = "Foto del articulo", Name = "Foto")]
        [Required(ErrorMessage = "Debe indicar una Foto para el articulo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El Foto no puede tener mas de 200 caracteres")]
        public string Foto { get; set; }

        [Display(Prompt = "Precio del articulo", Description = "Precio del articulo", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un precio para el articulo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numerico")]
        [Range(minimum:0, maximum:10000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 10000")]
        public double Precio { get; set; }

        [Display(Prompt = "Stock del articulo", Description = "Stock del articulo", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar un Stock para el articulo")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El Stock debe ser mayor que 0 y menor que 10000")]
        public int Stock { get; set; }

        [Display(Prompt = "ValoracionMedia del articulo", Description = "ValoracionMedia del articulo", Name = "ValoracionMedia")]
        [Required(ErrorMessage = "Debe indicar un ValoracionMedia para el articulo")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "El ValoracionMedia debe ser mayor que 0 y menor que 10000")]
        public float ValoracionMedia { get; set; }

    }
}