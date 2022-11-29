

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
 *      Definition of the class ReciboCEN
 *
 */
public partial class ReciboCEN
{
private IReciboCAD _IReciboCAD;

public ReciboCEN()
{
        this._IReciboCAD = new ReciboCAD ();
}

public ReciboCEN(IReciboCAD _IReciboCAD)
{
        this._IReciboCAD = _IReciboCAD;
}

public IReciboCAD get_IReciboCAD ()
{
        return this._IReciboCAD;
}

public int CrearRecibo (string p_descripcion, int p_codigo, int p_pedido)
{
        ReciboEN reciboEN = null;
        int oid;

        //Initialized ReciboEN
        reciboEN = new ReciboEN ();
        reciboEN.Descripcion = p_descripcion;

        reciboEN.Codigo = p_codigo;


        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids id
                reciboEN.Pedido = new JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN ();
                reciboEN.Pedido.Id = p_pedido;
        }

        //Call to ReciboCAD

        oid = _IReciboCAD.CrearRecibo (reciboEN);
        return oid;
}

public void BorrarRecibo (int id
                          )
{
        _IReciboCAD.BorrarRecibo (id);
}

public ReciboEN DameRecibo (int id
                            )
{
        ReciboEN reciboEN = null;

        reciboEN = _IReciboCAD.DameRecibo (id);
        return reciboEN;
}

public System.Collections.Generic.IList<ReciboEN> DameRecibos (int first, int size)
{
        System.Collections.Generic.IList<ReciboEN> list = null;

        list = _IReciboCAD.DameRecibos (first, size);
        return list;
}
}
}
