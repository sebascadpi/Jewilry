
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;



/*PROTECTED REGION ID(usingJewilryGenNHibernate.CP.JoyeriaJewirly_Pedido_damePedido2) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CP.JoyeriaJewirly
{
public partial class PedidoCP : BasicCP
{
public void DamePedido2 (int p_oid)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CP.JoyeriaJewirly_Pedido_damePedido2) ENABLED START*/

        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new  PedidoCEN (pedidoCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method DamePedido2() not yet implemented.");



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
