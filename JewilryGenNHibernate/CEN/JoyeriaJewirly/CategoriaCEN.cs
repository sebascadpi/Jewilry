

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
 *      Definition of the class CategoriaCEN
 *
 */
public partial class CategoriaCEN
{
private ICategoriaCAD _ICategoriaCAD;

public CategoriaCEN()
{
        this._ICategoriaCAD = new CategoriaCAD ();
}

public CategoriaCEN(ICategoriaCAD _ICategoriaCAD)
{
        this._ICategoriaCAD = _ICategoriaCAD;
}

public ICategoriaCAD get_ICategoriaCAD ()
{
        return this._ICategoriaCAD;
}

public int CrearCategoria (string p_nombre)
{
        CategoriaEN categoriaEN = null;
        int oid;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.Nombre = p_nombre;

        //Call to CategoriaCAD

        oid = _ICategoriaCAD.CrearCategoria (categoriaEN);
        return oid;
}

public void ModificarCategoria (int p_Categoria_OID, string p_nombre)
{
        CategoriaEN categoriaEN = null;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.Id = p_Categoria_OID;
        categoriaEN.Nombre = p_nombre;
        //Call to CategoriaCAD

        _ICategoriaCAD.ModificarCategoria (categoriaEN);
}

public void BorrarCategoria (int id
                             )
{
        _ICategoriaCAD.BorrarCategoria (id);
}

public CategoriaEN DameCategoria (int id
                                  )
{
        CategoriaEN categoriaEN = null;

        categoriaEN = _ICategoriaCAD.DameCategoria (id);
        return categoriaEN;
}

public System.Collections.Generic.IList<CategoriaEN> DameCategorias (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> list = null;

        list = _ICategoriaCAD.DameCategorias (first, size);
        return list;
}
public void AnadirSuperCategoria (int p_Categoria_OID, int p_categoria_OID)
{
        //Call to CategoriaCAD

        _ICategoriaCAD.AnadirSuperCategoria (p_Categoria_OID, p_categoria_OID);
}
public void QuitarSuperCategoria (int p_Categoria_OID, int p_categoria_OID)
{
        //Call to CategoriaCAD

        _ICategoriaCAD.QuitarSuperCategoria (p_Categoria_OID, p_categoria_OID);
}
}
}
