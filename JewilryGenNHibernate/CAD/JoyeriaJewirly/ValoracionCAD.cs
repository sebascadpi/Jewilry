
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
 * Clase Valoracion:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class ValoracionCAD : BasicCAD, IValoracionCAD
{
public ValoracionCAD() : base ()
{
}

public ValoracionCAD(ISession sessionAux) : base (sessionAux)
{
}



public ValoracionEN ReadOIDDefault (int id
                                    )
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionEN)).List<ValoracionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionEN valoracionEN = (ValoracionEN)session.Load (typeof(ValoracionEN), valoracion.Id);

                valoracionEN.Comentario = valoracion.Comentario;


                valoracionEN.Valor = valoracion.Valor;



                session.Update (valoracionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearValoracion (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                if (valoracion.Articulo != null) {
                        // Argumento OID y no colección.
                        valoracion.Articulo = (JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN), valoracion.Articulo.Id);

                        valoracion.Articulo.Valoracion
                        .Add (valoracion);
                }
                if (valoracion.Cliente != null) {
                        // Argumento OID y no colección.
                        valoracion.Cliente = (JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN), valoracion.Cliente.Id);

                        valoracion.Cliente.Valoracion
                        .Add (valoracion);
                }

                session.Save (valoracion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracion.Id;
}

public void ModificarValoracion (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionEN valoracionEN = (ValoracionEN)session.Load (typeof(ValoracionEN), valoracion.Id);

                valoracionEN.Comentario = valoracion.Comentario;


                valoracionEN.Valor = valoracion.Valor;

                session.Update (valoracionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarValoracion (int id
                              )
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionEN valoracionEN = (ValoracionEN)session.Load (typeof(ValoracionEN), id);
                session.Delete (valoracionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameValoracion
//Con e: ValoracionEN
public ValoracionEN DameValoracion (int id
                                    )
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> DameValoraciones (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ValoracionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                else
                        result = session.CreateCriteria (typeof(ValoracionEN)).List<ValoracionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public double CalcularMedia (int p_idArticulo)
{
        double result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ValoracionEN self where Select avg(va.Valor) FROM ValoracionEN as va inner join va.Articulo as ar where ar.Id = :p_idArticulo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ValoracionENcalcularMediaHQL");
                query.SetParameter ("p_idArticulo", p_idArticulo);


                result = query.UniqueResult<double>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ValoracionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
