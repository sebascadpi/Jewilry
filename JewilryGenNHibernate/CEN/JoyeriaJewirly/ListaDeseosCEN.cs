

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
 *      Definition of the class ListaDeseosCEN
 *
 */
public partial class ListaDeseosCEN
{
private IListaDeseosCAD _IListaDeseosCAD;

public ListaDeseosCEN()
{
        this._IListaDeseosCAD = new ListaDeseosCAD ();
}

public ListaDeseosCEN(IListaDeseosCAD _IListaDeseosCAD)
{
        this._IListaDeseosCAD = _IListaDeseosCAD;
}

public IListaDeseosCAD get_IListaDeseosCAD ()
{
        return this._IListaDeseosCAD;
}

public int CrearLista (int p_cliente)
{
        ListaDeseosEN listaDeseosEN = null;
        int oid;

        //Initialized ListaDeseosEN
        listaDeseosEN = new ListaDeseosEN ();

        if (p_cliente != -1) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                listaDeseosEN.Cliente = new JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN ();
                listaDeseosEN.Cliente.Id = p_cliente;
        }

        //Call to ListaDeseosCAD

        oid = _IListaDeseosCAD.CrearLista (listaDeseosEN);
        return oid;
}

public void ModificarLista (int p_ListaDeseos_OID)
{
        ListaDeseosEN listaDeseosEN = null;

        //Initialized ListaDeseosEN
        listaDeseosEN = new ListaDeseosEN ();
        listaDeseosEN.Id = p_ListaDeseos_OID;
        //Call to ListaDeseosCAD

        _IListaDeseosCAD.ModificarLista (listaDeseosEN);
}

public void BorrarLista (int id
                         )
{
        _IListaDeseosCAD.BorrarLista (id);
}

public ListaDeseosEN DameLista (int id
                                )
{
        ListaDeseosEN listaDeseosEN = null;

        listaDeseosEN = _IListaDeseosCAD.DameLista (id);
        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> DameListas (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> list = null;

        list = _IListaDeseosCAD.DameListas (first, size);
        return list;
}
public void AnadirArticulo (int p_ListaDeseos_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
{
        //Call to ListaDeseosCAD

        _IListaDeseosCAD.AnadirArticulo (p_ListaDeseos_OID, p_articulo_OIDs);
}
public void QuitarArticulo (int p_ListaDeseos_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
{
        //Call to ListaDeseosCAD

        _IListaDeseosCAD.QuitarArticulo (p_ListaDeseos_OID, p_articulo_OIDs);
}
}
}
