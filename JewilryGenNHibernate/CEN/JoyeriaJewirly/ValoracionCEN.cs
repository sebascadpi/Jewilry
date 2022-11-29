

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
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionCAD _IValoracionCAD;

public ValoracionCEN()
{
        this._IValoracionCAD = new ValoracionCAD ();
}

public ValoracionCEN(IValoracionCAD _IValoracionCAD)
{
        this._IValoracionCAD = _IValoracionCAD;
}

public IValoracionCAD get_IValoracionCAD ()
{
        return this._IValoracionCAD;
}

public int CrearValoracion (string p_comentario, int p_valor, int p_articulo, int p_cliente)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Comentario = p_comentario;

        valoracionEN.Valor = p_valor;


        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids id
                valoracionEN.Articulo = new JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN ();
                valoracionEN.Articulo.Id = p_articulo;
        }


        if (p_cliente != -1) {
                // El argumento p_cliente -> Property cliente es oid = false
                // Lista de oids id
                valoracionEN.Cliente = new JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN ();
                valoracionEN.Cliente.Id = p_cliente;
        }

        //Call to ValoracionCAD

        oid = _IValoracionCAD.CrearValoracion (valoracionEN);
        return oid;
}

public void ModificarValoracion (int p_Valoracion_OID, string p_comentario, int p_valor)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id = p_Valoracion_OID;
        valoracionEN.Comentario = p_comentario;
        valoracionEN.Valor = p_valor;
        //Call to ValoracionCAD

        _IValoracionCAD.ModificarValoracion (valoracionEN);
}

public void BorrarValoracion (int id
                              )
{
        _IValoracionCAD.BorrarValoracion (id);
}

public ValoracionEN DameValoracion (int id
                                    )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionCAD.DameValoracion (id);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> DameValoraciones (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionCAD.DameValoraciones (first, size);
        return list;
}
public double CalcularMedia (int p_idArticulo)
{
        return _IValoracionCAD.CalcularMedia (p_idArticulo);
}
}
}
