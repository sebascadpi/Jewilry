

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
 *      Definition of the class ArticuloCEN
 *
 */
public partial class ArticuloCEN
{
private IArticuloCAD _IArticuloCAD;

public ArticuloCEN()
{
        this._IArticuloCAD = new ArticuloCAD ();
}

public ArticuloCEN(IArticuloCAD _IArticuloCAD)
{
        this._IArticuloCAD = _IArticuloCAD;
}

public IArticuloCAD get_IArticuloCAD ()
{
        return this._IArticuloCAD;
}

public int CrearArticulo (float p_precio, string p_nombre, string p_descripcion, string p_material, string p_marca, int p_stock, string p_foto, int p_categoria, string p_tallas, float p_valoracionMedia)
{
        ArticuloEN articuloEN = null;
        int oid;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Precio = p_precio;

        articuloEN.Nombre = p_nombre;

        articuloEN.Descripcion = p_descripcion;

        articuloEN.Material = p_material;

        articuloEN.Marca = p_marca;

        articuloEN.Stock = p_stock;

        articuloEN.Foto = p_foto;


        if (p_categoria != -1) {
                // El argumento p_categoria -> Property categoria es oid = false
                // Lista de oids id
                articuloEN.Categoria = new JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN ();
                articuloEN.Categoria.Id = p_categoria;
        }

        articuloEN.Tallas = p_tallas;

        articuloEN.ValoracionMedia = p_valoracionMedia;

        //Call to ArticuloCAD

        oid = _IArticuloCAD.CrearArticulo (articuloEN);
        return oid;
}

public void ModificarArticulo (int p_Articulo_OID, float p_precio, string p_nombre, string p_descripcion, string p_material, string p_marca, int p_stock, string p_foto, string p_tallas, float p_valoracionMedia)
{
        ArticuloEN articuloEN = null;

        //Initialized ArticuloEN
        articuloEN = new ArticuloEN ();
        articuloEN.Id = p_Articulo_OID;
        articuloEN.Precio = p_precio;
        articuloEN.Nombre = p_nombre;
        articuloEN.Descripcion = p_descripcion;
        articuloEN.Material = p_material;
        articuloEN.Marca = p_marca;
        articuloEN.Stock = p_stock;
        articuloEN.Foto = p_foto;
        articuloEN.Tallas = p_tallas;
        articuloEN.ValoracionMedia = p_valoracionMedia;
        //Call to ArticuloCAD

        _IArticuloCAD.ModificarArticulo (articuloEN);
}

public void BorrarArticulo (int id
                            )
{
        _IArticuloCAD.BorrarArticulo (id);
}

public ArticuloEN DameArticulo (int id
                                )
{
        ArticuloEN articuloEN = null;

        articuloEN = _IArticuloCAD.DameArticulo (id);
        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> DameArticulos (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> list = null;

        list = _IArticuloCAD.DameArticulos (first, size);
        return list;
}
public void AsignarCategoria (int p_Articulo_OID, int p_categoria_OID)
{
        //Call to ArticuloCAD

        _IArticuloCAD.AsignarCategoria (p_Articulo_OID, p_categoria_OID);
}
public void DesasignarCategoria (int p_Articulo_OID, int p_categoria_OID)
{
        //Call to ArticuloCAD

        _IArticuloCAD.DesasignarCategoria (p_Articulo_OID, p_categoria_OID);
}
public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> ArticuloLista (int p_idLista)
{
        return _IArticuloCAD.ArticuloLista (p_idLista);
}
public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> ArticuloPedido (int p_idPedido)
{
        return _IArticuloCAD.ArticuloPedido (p_idPedido);
}
}
}
