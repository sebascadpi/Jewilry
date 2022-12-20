
using System;
using System.Text;
using JewilryGenNHibernate.CEN.JoyeriaJewirly;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using JewilryGenNHibernate.EN.JoyeriaJewirly;
using JewilryGenNHibernate.Exceptions;


/*
 * Clase Articulo:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class ArticuloCAD : BasicCAD, IArticuloCAD
{
public ArticuloCAD() : base ()
{
}

public ArticuloCAD(ISession sessionAux) : base (sessionAux)
{
}



public ArticuloEN ReadOIDDefault (int id
                                  )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ArticuloEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                        else
                                result = session.CreateCriteria (typeof(ArticuloEN)).List<ArticuloEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloEN articuloEN = (ArticuloEN)session.Load (typeof(ArticuloEN), articulo.Id);

                articuloEN.Precio = articulo.Precio;


                articuloEN.Nombre = articulo.Nombre;


                articuloEN.Descripcion = articulo.Descripcion;


                articuloEN.Material = articulo.Material;


                articuloEN.Marca = articulo.Marca;


                articuloEN.Stock = articulo.Stock;


                articuloEN.Foto = articulo.Foto;






                articuloEN.Tallas = articulo.Tallas;


                articuloEN.ValoracionMedia = articulo.ValoracionMedia;

                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearArticulo (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                if (articulo.Categoria != null) {
                        // Argumento OID y no colección.
                        articulo.Categoria = (JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN), articulo.Categoria.Id);

                        articulo.Categoria.Articulo
                        .Add (articulo);
                }

                session.Save (articulo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articulo.Id;
}

public void ModificarArticulo (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloEN articuloEN = (ArticuloEN)session.Load (typeof(ArticuloEN), articulo.Id);

                articuloEN.Precio = articulo.Precio;


                articuloEN.Nombre = articulo.Nombre;


                articuloEN.Descripcion = articulo.Descripcion;


                articuloEN.Material = articulo.Material;


                articuloEN.Marca = articulo.Marca;


                articuloEN.Stock = articulo.Stock;


                articuloEN.Foto = articulo.Foto;


                articuloEN.Tallas = articulo.Tallas;


                articuloEN.ValoracionMedia = articulo.ValoracionMedia;

                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarArticulo (int id
                            )
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloEN articuloEN = (ArticuloEN)session.Load (typeof(ArticuloEN), id);
                session.Delete (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameArticulo
//Con e: ArticuloEN
public ArticuloEN DameArticulo (int id
                                )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> DameArticulos (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ArticuloEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                else
                        result = session.CreateCriteria (typeof(ArticuloEN)).List<ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AsignarCategoria (int p_Articulo_OID, int p_categoria_OID)
{
        JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articuloEN = null;
        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Load (typeof(ArticuloEN), p_Articulo_OID);
                articuloEN.Categoria = (JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.CategoriaEN), p_categoria_OID);

                articuloEN.Categoria.Articulo.Add (articuloEN);



                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasignarCategoria (int p_Articulo_OID, int p_categoria_OID)
{
        try
        {
                SessionInitializeTransaction ();
                JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articuloEN = null;
                articuloEN = (ArticuloEN)session.Load (typeof(ArticuloEN), p_Articulo_OID);

                if (articuloEN.Categoria.Id == p_categoria_OID) {
                        articuloEN.Categoria = null;
                }
                else
                        throw new ModelException ("The identifier " + p_categoria_OID + " in p_categoria_OID you are trying to unrelationer, doesn't exist in ArticuloEN");

                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> ArticuloLista (int p_idLista)
{
        System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloEN self where select art FROM ArticuloEN as art inner join art.ListaDeseos as lista inner join lista.Cliente as cli where lista is not empty and cli.Id = :p_idLista ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloENarticuloListaHQL");
                query.SetParameter ("p_idLista", p_idLista);

                result = query.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> ArticuloPedido (int p_idPedido)
{
    System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> result;
    try
    {
            SessionInitializeTransaction ();
            //String sql = @"FROM ArticuloEN self where select art FROM ArticuloEN as art inner join art.LineaPedido as linea inner join linea.Pedido as ped where ped.Id = :p_idPedido";
            //IQuery query = session.CreateQuery(sql);
            IQuery query = (IQuery)session.GetNamedQuery ("ArticuloENarticuloPedidoHQL");
            query.SetParameter ("p_idPedido", p_idPedido);

            result = query.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN>();
            SessionCommit ();
    }

    catch (Exception ex) {
            SessionRollBack ();
            if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                    throw ex;
            throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ArticuloCAD.", ex);
    }


    finally
    {
            SessionClose ();
    }

    return result;
}

public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> ArticuloCategoria(int p_idPedido)
{
    System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN> result;
    try
    {
        SessionInitializeTransaction();
                //String sql = @"FROM ArticuloEN self where select art FROM ArticuloEN as art where art.Categoria.Id = :p_idPedido";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery("ArticuloENarticuloCategoriaHQL");
        query.SetParameter("p_idPedido", p_idPedido);

        result = query.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN>();
        SessionCommit();
    }

    catch (Exception ex)
    {
        SessionRollBack();
        if (ex is JewilryGenNHibernate.Exceptions.ModelException)
            throw ex;
        throw new JewilryGenNHibernate.Exceptions.DataLayerException("Error in ArticuloCAD.", ex);
    }


    finally
    {
        SessionClose();
    }

    return result;
}
}
}
