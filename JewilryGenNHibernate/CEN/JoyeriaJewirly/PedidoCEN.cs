

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using JewilryGenNHibernate.Exceptions;

using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.CAD.JoyeriaJewirly;


namespace JewilryGenNHibernate.CEN.JoyeriaJewirly
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public void ModificarPedido (int p_Pedido_OID, JewilryGenNHibernate.Enumerated.JoyeriaJewirly.EstadoPedidoEnum p_estado)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Estado = p_estado;
        //Call to PedidoCAD

        _IPedidoCAD.ModificarPedido (pedidoEN);
}

public void BorrarPedido (int id
                          )
{
        _IPedidoCAD.BorrarPedido (id);
}

public PedidoEN DamePedido (int id
                            )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoCAD.DamePedido (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> DamePedidos (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoCAD.DamePedidos (first, size);
        return list;
}
public void TotalDescuento (int p_Pedido_OID, int p_descuento_OID)
{
        //Call to PedidoCAD

        _IPedidoCAD.TotalDescuento (p_Pedido_OID, p_descuento_OID);
}
public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> PedidosCliente (int p_idCliente)
{
        return _IPedidoCAD.PedidosCliente (p_idCliente);
}
}
}
