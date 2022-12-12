using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using Jewilry.Models;

namespace Jewilry.Assemblers
{
    public class PedidoAssembler
    {
        public PedidoViewModel ConvertENToModelUI(PedidoEN en)
        {
            PedidoViewModel art = new PedidoViewModel();
            art.Id = en.Id;
            art.Estado = en.Estado;
            art.Fecha = en.Fecha;
            art.Direccion = en.Direccion;
            art.Localidad = en.Localidad;
            art.Provincia = en.Provincia;
            art.CodigoPostal = en.CodigoPostal;
            art.TipoPago = en.TipoPago;
            art.TipoTarjeta = en.TipoTarjeta;
            art.NumeroTarjeta = en.NumeroTarjeta;
            art.Total = en.Total;




            return art;
        }

        public IList<PedidoViewModel> ConvertListENToModel(IList<PedidoEN> ens)
        {
            IList<PedidoViewModel> arts = new List<PedidoViewModel>();

            foreach(PedidoEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}