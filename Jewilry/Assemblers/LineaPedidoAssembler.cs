using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using Jewilry.Models;

namespace Jewilry.Assemblers
{
    public class LineaPedidoAssembler
    {
        public LineaPedidoViewModel ConvertENToModelUI(LineaPedidoEN en)
        {
            LineaPedidoViewModel art = new LineaPedidoViewModel();
            art.Id = en.Id;
            art.Unidades = en.Unidades;
            art.Precio = en.Precio;






            return art;
        }

        public IList<LineaPedidoViewModel> ConvertListENToModel(IList<LineaPedidoEN> ens)
        {
            IList<LineaPedidoViewModel> arts = new List<LineaPedidoViewModel>();

            foreach(LineaPedidoEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}