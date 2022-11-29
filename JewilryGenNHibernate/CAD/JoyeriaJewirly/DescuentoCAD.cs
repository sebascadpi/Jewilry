
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
 * Clase Descuento:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class DescuentoCAD : BasicCAD, IDescuentoCAD
{
public DescuentoCAD() : base ()
{
}

public DescuentoCAD(ISession sessionAux) : base (sessionAux)
{
}



public DescuentoEN ReadOIDDefault (int id
                                   )
{
        DescuentoEN descuentoEN = null;

        try
        {
                SessionInitializeTransaction ();
                descuentoEN = (DescuentoEN)session.Get (typeof(DescuentoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in DescuentoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return descuentoEN;
}

public System.Collections.Generic.IList<DescuentoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DescuentoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DescuentoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<DescuentoEN>();
                        else
                                result = session.CreateCriteria (typeof(DescuentoEN)).List<DescuentoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in DescuentoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DescuentoEN descuento)
{
        try
        {
                SessionInitializeTransaction ();
                DescuentoEN descuentoEN = (DescuentoEN)session.Load (typeof(DescuentoEN), descuento.Id);

                descuentoEN.Cupon = descuento.Cupon;


                descuentoEN.Descuento = descuento.Descuento;


                session.Update (descuentoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in DescuentoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearDescuento (DescuentoEN descuento)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (descuento);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in DescuentoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return descuento.Id;
}

public void ModificarDescuento (DescuentoEN descuento)
{
        try
        {
                SessionInitializeTransaction ();
                DescuentoEN descuentoEN = (DescuentoEN)session.Load (typeof(DescuentoEN), descuento.Id);

                descuentoEN.Cupon = descuento.Cupon;


                descuentoEN.Descuento = descuento.Descuento;

                session.Update (descuentoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in DescuentoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarDescuento (int id
                             )
{
        try
        {
                SessionInitializeTransaction ();
                DescuentoEN descuentoEN = (DescuentoEN)session.Load (typeof(DescuentoEN), id);
                session.Delete (descuentoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in DescuentoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameDescuento
//Con e: DescuentoEN
public DescuentoEN DameDescuento (int id
                                  )
{
        DescuentoEN descuentoEN = null;

        try
        {
                SessionInitializeTransaction ();
                descuentoEN = (DescuentoEN)session.Get (typeof(DescuentoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in DescuentoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return descuentoEN;
}

public System.Collections.Generic.IList<DescuentoEN> DameDescuentos (int first, int size)
{
        System.Collections.Generic.IList<DescuentoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DescuentoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<DescuentoEN>();
                else
                        result = session.CreateCriteria (typeof(DescuentoEN)).List<DescuentoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in DescuentoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
