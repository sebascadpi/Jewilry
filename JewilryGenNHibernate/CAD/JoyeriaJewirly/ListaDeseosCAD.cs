
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
 * Clase ListaDeseos:
 *
 */

namespace JewilryGenNHibernate.CAD.JoyeriaJewirly
{
public partial class ListaDeseosCAD : BasicCAD, IListaDeseosCAD
{
public ListaDeseosCAD() : base ()
{
}

public ListaDeseosCAD(ISession sessionAux) : base (sessionAux)
{
}



public ListaDeseosEN ReadOIDDefault (int id
                                     )
{
        ListaDeseosEN listaDeseosEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaDeseosEN = (ListaDeseosEN)session.Get (typeof(ListaDeseosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaDeseosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaDeseosEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaDeseosEN)).List<ListaDeseosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ListaDeseosEN listaDeseos)
{
        try
        {
                SessionInitializeTransaction ();
                ListaDeseosEN listaDeseosEN = (ListaDeseosEN)session.Load (typeof(ListaDeseosEN), listaDeseos.Id);


                session.Update (listaDeseosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearLista (ListaDeseosEN listaDeseos)
{
        try
        {
                SessionInitializeTransaction ();
                if (listaDeseos.Cliente != null) {
                        // Argumento OID y no colección.
                        listaDeseos.Cliente = (JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.ClienteEN), listaDeseos.Cliente.Id);

                        listaDeseos.Cliente.ListaDeseos
                                = listaDeseos;
                }

                session.Save (listaDeseos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseos.Id;
}

public void ModificarLista (ListaDeseosEN listaDeseos)
{
        try
        {
                SessionInitializeTransaction ();
                ListaDeseosEN listaDeseosEN = (ListaDeseosEN)session.Load (typeof(ListaDeseosEN), listaDeseos.Id);
                session.Update (listaDeseosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarLista (int id
                         )
{
        try
        {
                SessionInitializeTransaction ();
                ListaDeseosEN listaDeseosEN = (ListaDeseosEN)session.Load (typeof(ListaDeseosEN), id);
                session.Delete (listaDeseosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DameLista
//Con e: ListaDeseosEN
public ListaDeseosEN DameLista (int id
                                )
{
        ListaDeseosEN listaDeseosEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaDeseosEN = (ListaDeseosEN)session.Get (typeof(ListaDeseosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> DameListas (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ListaDeseosEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ListaDeseosEN>();
                else
                        result = session.CreateCriteria (typeof(ListaDeseosEN)).List<ListaDeseosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnadirArticulo (int p_ListaDeseos_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
{
        JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN listaDeseosEN = null;
        try
        {
                SessionInitializeTransaction ();
                listaDeseosEN = (ListaDeseosEN)session.Load (typeof(ListaDeseosEN), p_ListaDeseos_OID);
                JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articuloENAux = null;
                if (listaDeseosEN.Articulo == null) {
                        listaDeseosEN.Articulo = new System.Collections.Generic.List<JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN>();
                }

                foreach (int item in p_articulo_OIDs) {
                        articuloENAux = new JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN ();
                        articuloENAux = (JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN), item);
                        articuloENAux.ListaDeseos.Add (listaDeseosEN);

                        listaDeseosEN.Articulo.Add (articuloENAux);
                }


                session.Update (listaDeseosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarArticulo (int p_ListaDeseos_OID, System.Collections.Generic.IList<int> p_articulo_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                JewilryGenNHibernate.EN.JoyeriaJewirly.ListaDeseosEN listaDeseosEN = null;
                listaDeseosEN = (ListaDeseosEN)session.Load (typeof(ListaDeseosEN), p_ListaDeseos_OID);

                JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN articuloENAux = null;
                if (listaDeseosEN.Articulo != null) {
                        foreach (int item in p_articulo_OIDs) {
                                articuloENAux = (JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN)session.Load (typeof(JewilryGenNHibernate.EN.JoyeriaJewirly.ArticuloEN), item);
                                if (listaDeseosEN.Articulo.Contains (articuloENAux) == true) {
                                        listaDeseosEN.Articulo.Remove (articuloENAux);
                                        articuloENAux.ListaDeseos.Remove (listaDeseosEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_articulo_OIDs you are trying to unrelationer, doesn't exist in ListaDeseosEN");
                        }
                }

                session.Update (listaDeseosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is JewilryGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new JewilryGenNHibernate.Exceptions.DataLayerException ("Error in ListaDeseosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
