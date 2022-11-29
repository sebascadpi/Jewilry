
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



/*PROTECTED REGION ID(usingJewilryGenNHibernate.CP.JoyeriaJewirly_LineaPedido_crearLinea) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace JewilryGenNHibernate.CP.JoyeriaJewirly
{
public partial class LineaPedidoCP : BasicCP
{
public JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN CrearLinea (int p_articulo, int p_pedido, int p_unidades, int p_precio)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CP.JoyeriaJewirly_LineaPedido_crearLinea) ENABLED START*/

        ILineaPedidoCAD lineaPedidoCAD = null;
        LineaPedidoCEN lineaPedidoCEN = null;
        PedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;

        JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                lineaPedidoCAD = new LineaPedidoCAD (session);
                lineaPedidoCEN = new  LineaPedidoCEN (lineaPedidoCAD);


                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new PedidoCEN (pedidoCAD);

                int oid;
                //Initialized LineaPedidoEN
                LineaPedidoEN lineaPedidoEN;
                lineaPedidoEN = new LineaPedidoEN ();

                if (p_articulo != -1) {
                        lineaPedidoEN.Articulo = new JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN ();
                        lineaPedidoEN.Articulo.Id = p_articulo;
                }


                if (p_pedido != -1) {
                        lineaPedidoEN.Pedido = new JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN ();
                        lineaPedidoEN.Pedido.Id = p_pedido;
                }

                lineaPedidoEN.Unidades = p_unidades;

                lineaPedidoEN.Precio = p_precio;

                //Call to LineaPedidoCAD

                oid = lineaPedidoCAD.CrearLinea (lineaPedidoEN);
                result = lineaPedidoCAD.ReadOIDDefault (oid);

                PedidoEN pedidoEN = pedidoCEN.DamePedido (lineaPedidoEN.Pedido.Id);
                pedidoEN.Total += lineaPedidoEN.Unidades * lineaPedidoEN.Articulo.Precio;

                pedidoCAD.ModifyDefault (pedidoEN);

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
        return result;


        /*PROTECTED REGION END*/
}
}
}
