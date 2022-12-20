
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
public partial class PedidoCEN :BasicCAD
{
public void RealizarPedido (int p_oid)
{
        /*PROTECTED REGION ID(JewilryGenNHibernate.CEN.JoyeriaJewirly_Pedido_realizarPedido) ENABLED START*/
                SessionInitializeTransaction ();
            
        


        PedidoEN en = _IPedidoCAD.ReadOIDDefault (p_oid);

        if (!(en.Estado == EstadoPedidoEnum.carrito))
                throw new ModelException ("El pedido no se puede realizar");

        LineaPedidoCAD linPedCAD2 = new LineaPedidoCAD(session);
        LineaPedidoCEN linpedCEN2 = new LineaPedidoCEN(linPedCAD2);
        IList<LineaPedidoEN> lineaarticulos = linpedCEN2.LineasPedido(p_oid);


       

        int oid;
        //Initialized LineaPedidoEN
        LineaPedidoEN lineaPedidoEN;
        lineaPedidoEN = new LineaPedidoEN();

        ArticuloEN articuloEN = new ArticuloEN();
        foreach (var item in lineaarticulos)
        {
            int idart;
            LineaPedidoCAD linPedCAD = new LineaPedidoCAD();
            LineaPedidoCEN linpedCEN = new LineaPedidoCEN(linPedCAD2);
            LineaPedidoEN linpedEN = linpedCEN.DameLinea(item.Id);

            ArticuloCAD articuloCAD = new ArticuloCAD();
            ArticuloCEN articuloCEN = new ArticuloCEN(articuloCAD);

            idart = linpedEN.Articulo.Id;

            articuloEN = articuloCEN.DameArticulo(idart);
            articuloEN.Stock -= item.Unidades;
            articuloCAD.ModifyDefault(articuloEN);


        }

            DateTime fecha = DateTime.Now;
        System.Diagnostics.Debug.WriteLine(fecha);
        en.Estado = EstadoPedidoEnum.pendiente;
        en.Fecha = fecha;

            _IPedidoCAD.ModifyDefault (en);
            SessionClose();

            /*PROTECTED REGION END*/
        }
}
}
