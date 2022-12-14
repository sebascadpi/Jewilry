

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
 *      Definition of the class LineaPedidoCEN
 *
 */
public partial class LineaPedidoCEN
{
private ILineaPedidoCAD _ILineaPedidoCAD;

public LineaPedidoCEN()
{
        this._ILineaPedidoCAD = new LineaPedidoCAD ();
}

public LineaPedidoCEN(ILineaPedidoCAD _ILineaPedidoCAD)
{
        this._ILineaPedidoCAD = _ILineaPedidoCAD;
}

public ILineaPedidoCAD get_ILineaPedidoCAD ()
{
        return this._ILineaPedidoCAD;
}

public void ModificarLinea (int p_LineaPedido_OID, int p_unidades, float p_precio)
{
        LineaPedidoEN lineaPedidoEN = null;

        //Initialized LineaPedidoEN
        lineaPedidoEN = new LineaPedidoEN ();
        lineaPedidoEN.Id = p_LineaPedido_OID;
        lineaPedidoEN.Unidades = p_unidades;
        lineaPedidoEN.Precio = p_precio;
        //Call to LineaPedidoCAD

        _ILineaPedidoCAD.ModificarLinea (lineaPedidoEN);
}

public void BorrarLinea (int id
                         )
{
        _ILineaPedidoCAD.BorrarLinea (id);
}

public LineaPedidoEN DameLinea (int id
                                )
{
        LineaPedidoEN lineaPedidoEN = null;

        lineaPedidoEN = _ILineaPedidoCAD.DameLinea (id);
        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> DameLineas (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> list = null;

        list = _ILineaPedidoCAD.DameLineas (first, size);
        return list;
}
public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> LineasPedido (int p_idPedido)
{
        return _ILineaPedidoCAD.LineasPedido (p_idPedido);
}
}
}
