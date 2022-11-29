
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
using JewilryGenNHibernate.Enumerated.JoyeriaJewirly;

/*PROTECTED REGION ID(usingJewilryGenNHibernate.CEN.JoyeriaJewirly_Cliente_cancelarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
public partial class ClienteCEN
{
public void CancelarPedido (int p_oid, int p_ped)
{
            ClienteEN cliEN = _IClienteCAD.ReadOIDDefault(p_oid);

            PedidoEN pedEN = new PedidoCAD().ReadOIDDefault(p_ped);

            if (!(pedEN.Estado != EstadoPedidoEnum.pendiente))
                throw new ModelException("El pedido ya no se puede cancelar");

            pedEN.Estado = EstadoPedidoEnum.rechazado;

        /*PROTECTED REGION END*/
}
}
}
