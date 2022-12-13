
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
 * Clase Pedido:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class PedidoCAD : BasicCAD, IPedidoCAD
{
public PedidoCAD() : base ()
{
}

public PedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PedidoEN ReadOIDDefault (int id
                                )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);



                pedidoEN.Estado = pedido.Estado;



                pedidoEN.Fecha = pedido.Fecha;


                pedidoEN.Direccion = pedido.Direccion;


                pedidoEN.Localidad = pedido.Localidad;


                pedidoEN.Provincia = pedido.Provincia;


                pedidoEN.CodigoPostal = pedido.CodigoPostal;


                pedidoEN.TipoPago = pedido.TipoPago;


                pedidoEN.TipoTarjeta = pedido.TipoTarjeta;


                pedidoEN.NumeroTarjeta = pedido.NumeroTarjeta;



                pedidoEN.Total = pedido.Total;

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearPedido (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (pedido.Cliente != null) {
                        // Argumento OID y no colección.
                        pedido.Cliente = (JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN), pedido.Cliente.Id);

                        pedido.Cliente.Pedido
                        .Add (pedido);
                }

                session.Save (pedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedido.Id;
}

public void ModificarPedido (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);

                pedidoEN.Estado = pedido.Estado;

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPedido (int id
                          )
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), id);
                session.Delete (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePedido
//Con e: PedidoEN
public PedidoEN DamePedido (int id
                            )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> DamePedidos (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void TotalDescuento (int p_Pedido_OID, int p_descuento_OID)
{
        JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);
                pedidoEN.Descuento = (JewilryGenNHibernate.EN.JoyeriaJewirly.DescuentoEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.DescuentoEN), p_descuento_OID);

                pedidoEN.Descuento.Pedido.Add (pedidoEN);



                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> PedidosCliente (int p_idCliente)
{
        System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where Select ped FROM PedidoEN as ped inner join ped.Cliente as cli where cli.Id = :p_idCliente and ped.Estado != 1 ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENpedidosClienteHQL");
                query.SetParameter ("p_idCliente", p_idCliente);

                result = query.List<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> PedidosTodosCliente(int p_idCliente)
{
    System.Collections.Generic.IList<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN> result;
    try
    {
        SessionInitializeTransaction();
        //String sql = @"FROM PedidoEN self where Select ped FROM PedidoEN as ped inner join ped.Cliente as cli where cli.Id = :p_idCliente";
        //IQuery query = session.CreateQuery(sql);
        IQuery query = (IQuery)session.GetNamedQuery("TodosPedidoENpedidosClienteHQL");
        query.SetParameter("p_idCliente", p_idCliente);

        result = query.List<JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN>();
        SessionCommit();
    }

    catch (Exception ex)
    {
        SessionRollBack();
        if (ex is JewilryGenNHibernate.Exceptions.ModelException)
            throw ex;
        throw new JewilryGenNHibernate.Exceptions.DataLayerException("Error in PedidoCAD.", ex);
    }


    finally
    {
        SessionClose();
    }

    return result;
}
    }
}
