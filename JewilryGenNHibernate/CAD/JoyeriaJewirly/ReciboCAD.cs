
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
 * Clase Recibo:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class ReciboCAD : BasicCAD, IReciboCAD
{
public ReciboCAD() : base ()
{
}

public ReciboCAD(ISession sessionAux) : base (sessionAux)
{
}



public ReciboEN ReadOIDDefault (int id
                                )
{
        ReciboEN reciboEN = null;

        try
        {
                SessionInitializeTransaction ();
                reciboEN = (ReciboEN)session.Get (typeof(ReciboEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ReciboCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reciboEN;
}

public System.Collections.Generic.IList<ReciboEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ReciboEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ReciboEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ReciboEN>();
                        else
                                result = session.CreateCriteria (typeof(ReciboEN)).List<ReciboEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ReciboCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ReciboEN recibo)
{
        try
        {
                SessionInitializeTransaction ();
                ReciboEN reciboEN = (ReciboEN)session.Load (typeof(ReciboEN), recibo.Id);

                reciboEN.Descripcion = recibo.Descripcion;


                reciboEN.Codigo = recibo.Codigo;


                session.Update (reciboEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ReciboCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearRecibo (ReciboEN recibo)
{
        try
        {
                SessionInitializeTransaction ();
                if (recibo.Pedido != null) {
                        // Argumento OID y no colección.
                        recibo.Pedido = (JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.PedidoEN), recibo.Pedido.Id);

                        recibo.Pedido.Recibo
                                = recibo;
                }

                session.Save (recibo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ReciboCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return recibo.Id;
}

public void BorrarRecibo (int id
                          )
{
        try
        {
                SessionInitializeTransaction ();
                ReciboEN reciboEN = (ReciboEN)session.Load (typeof(ReciboEN), id);
                session.Delete (reciboEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ReciboCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameRecibo
//Con e: ReciboEN
public ReciboEN DameRecibo (int id
                            )
{
        ReciboEN reciboEN = null;

        try
        {
                SessionInitializeTransaction ();
                reciboEN = (ReciboEN)session.Get (typeof(ReciboEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ReciboCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return reciboEN;
}

public System.Collections.Generic.IList<ReciboEN> DameRecibos (int first, int size)
{
        System.Collections.Generic.IList<ReciboEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ReciboEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ReciboEN>();
                else
                        result = session.CreateCriteria (typeof(ReciboEN)).List<ReciboEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ReciboCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
