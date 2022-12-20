using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using Jewilry.Models;

namespace Jewilry.Assemblers
{
    public class ArticuloAssembler
    {
        public ArticuloViewModel ConvertENToModelUI(ArticuloEN en)
        {
            ArticuloViewModel art = new ArticuloViewModel();
            art.Id = en.Id;
            art.Nombre = en.Nombre;
            art.Precio = en.Precio;
            art.Stock = en.Stock;
            art.Foto = en.Foto;
            art.Descripcion = en.Descripcion;
            art.ValoracionMedia = en.ValoracionMedia;
            art.Marca = en.Marca;
            art.Material = en.Material;
            art.Tallas = en.Tallas;
            art.NombreCategoria = en.Categoria.Nombre;
            art.IdCategoria = en.Categoria.Id;




            return art;
        }

        public IList<ArticuloViewModel> ConvertListENToModel(IList<ArticuloEN> ens)
        {
            IList<ArticuloViewModel> arts = new List<ArticuloViewModel>();

            foreach(ArticuloEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}