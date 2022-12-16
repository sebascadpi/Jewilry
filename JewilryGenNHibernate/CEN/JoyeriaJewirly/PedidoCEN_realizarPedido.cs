
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using JewilryGenNHibernate.Exceptions;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_realizarPedido) ENABLED START*/
using JewilryGenNHibernate.Enumerated.JoyeriaJewirly;
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class PedidoCEN
{
public void RealizarPedido (int p_oid)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_realizarPedido) ENABLED START*/



        PedidoEN en = _IPedidoCAD.ReadOIDDefault (p_oid);

        if (!(en.Estado == EstadoPedidoEnum.carrito))
                throw new ModelException ("El pedido no se puede realizar");

        DateTime fecha = DateTime.Now;
            System.Diagnostics.Debug.WriteLine(fecha);
        en.Estado = EstadoPedidoEnum.pendiente;
        en.Fecha = fecha;

            _IPedidoCAD.ModifyDefault (en);


        /*PROTECTED REGION END*/
}
}
}
