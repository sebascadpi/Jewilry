
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
 * Clase LineaPedido:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class LineaPedidoCAD : BasicCAD, ILineaPedidoCAD
{
public LineaPedidoCAD() : base ()
{
}

public LineaPedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaPedidoEN ReadOIDDefault (int id
                                     )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaPedidoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaPedidoEN)).List<LineaPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoEN lineaPedidoEN = (LineaPedidoEN)session.Load (typeof(LineaPedidoEN), lineaPedido.Id);



                lineaPedidoEN.Unidades = lineaPedido.Unidades;


                lineaPedidoEN.Precio = lineaPedido.Precio;

                session.Update (lineaPedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearLinea (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaPedido.Articulo != null) {
                        // Argumento OID y no colección.
                        lineaPedido.Articulo = (JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN), lineaPedido.Articulo.Id);

                        lineaPedido.Articulo.LineaPedido
                        .Add (lineaPedido);
                }
                if (lineaPedido.Pedido != null) {
                        // Argumento OID y no colección.
                        lineaPedido.Pedido = (JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN), lineaPedido.Pedido.Id);

                        lineaPedido.Pedido.LineaPedido
                        .Add (lineaPedido);
                }

                session.Save (lineaPedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedido.Id;
}

public void ModificarLinea (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoEN lineaPedidoEN = (LineaPedidoEN)session.Load (typeof(LineaPedidoEN), lineaPedido.Id);

                lineaPedidoEN.Unidades = lineaPedido.Unidades;


                lineaPedidoEN.Precio = lineaPedido.Precio;

                session.Update (lineaPedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarLinea (int id
                         )
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoEN lineaPedidoEN = (LineaPedidoEN)session.Load (typeof(LineaPedidoEN), id);
                session.Delete (lineaPedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameLinea
//Con e: LineaPedidoEN
public LineaPedidoEN DameLinea (int id
                                )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> DameLineas (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaPedidoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                else
                        result = session.CreateCriteria (typeof(LineaPedidoEN)).List<LineaPedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> LineasPedido (int p_idPedido)
{
        System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LineaPedidoEN self where select lin FROM LineaPedidoEN as lin inner join lin.Pedido as ped where ped.Id = :p_idPedido";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LineaPedidoENlineasPedidoHQL");
                query.SetParameter ("p_idPedido", p_idPedido);

                result = query.List<JewilryGenNHibernate.EN.JoyeriaJewirly.LineaPedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
