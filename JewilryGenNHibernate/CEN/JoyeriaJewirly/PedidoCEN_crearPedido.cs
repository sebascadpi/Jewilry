
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


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_crearPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class PedidoCEN
{
public int CrearPedido (int p_cliente)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_crearPedido_customized) ENABLED START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();

        if (p_cliente != -1) {
                pedidoEN.Cliente = new JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN ();
                pedidoEN.Cliente.Id = p_cliente;
        }
        pedidoEN.Estado = Enumerated.JoyeriaJewirly.EstadoPedidoEnum.carrito;

        //Call to PedidoCAD

        oid = _IPedidoCAD.CrearPedido (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
