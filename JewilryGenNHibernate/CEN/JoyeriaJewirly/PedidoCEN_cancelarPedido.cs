
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


/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_cancelarPedido) ENABLED START*/
using JewilryGenNHibernate.Enumerated.JoyeriaJewirly;
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class PedidoCEN
{
public void CancelarPedido (int p_oid)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_cancelarPedido) ENABLED START*/

        PedidoEN en = _IPedidoCAD.ReadOIDDefault (p_oid);

        if (en.Estado == EstadoPedidoEnum.enviado || en.Estado == EstadoPedidoEnum.recibido)
                throw new ModelException ("El pedido no se puede cancelar");

        en.Estado = EstadoPedidoEnum.rechazado;
        _IPedidoCAD.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
